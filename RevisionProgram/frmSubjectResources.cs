using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Net;

namespace RevisionProgram
{
    public partial class frmSubjectResources : Form
    {
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        public frmSubjectResources()
        {
            InitializeComponent();
            clbSubjectFilter.Visible = false;
            btnConfirm.Visible = false;
        }

        private void loadCheckedListBox() //Procedure to load the subjects into the checkedListBox
        {
            conn2.Open();
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataTable dt = new DataTable(); //DataTable used to hold the data from data adapter
            dt.Clear();
            string sqlSubjects = "SELECT DISTINCT TBLSubjects.subjectName FROM TBLSubjects INNER JOIN(TBLResources INNER JOIN TBLSubjectResources ON TBLResources.[resourceID] = TBLSubjectResources.[resourceID]) ON TBLSubjects.[subjectID] = TBLSubjectResources.[subjectID]"; //SQL Statement to select all subject names, but no duplicates
            da = new OleDbDataAdapter(sqlSubjects, conn2); //Retrieves all subjects stored in the database where subjectLevel has the value "GCSE"
            da.Fill(dt); //Fills datatable with data adapter
            try
            {
                clbSubjectFilter.DataSource = dt;
                clbSubjectFilter.DisplayMember = "subjectName";
                clbSubjectFilter.ValueMember = "subjectName";
            }
            //Set the checkedListBox datasources to the datatable
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            //Used for error checks
            conn2.Close();
        }

        private string getUserID(string username) //Function to get the userID
        {
            string getID = "SELECT userID FROM TBLUsers WHERE username = @Username";
            OleDbCommand cmdGetID = new OleDbCommand();
            cmdGetID = new OleDbCommand(getID, conn2);
            cmdGetID.Parameters.AddWithValue("@Username", username);
            string userID = Convert.ToString(cmdGetID.ExecuteScalar());
            return userID;
        }

        public string getResourceLocation(string resourceName)
        {
            conn2.Open();
            OleDbCommand cmdGetResourceLocation = new OleDbCommand();
            string getResourceLocationSQL = "SELECT resourceLocation FROM TBLResources WHERE resourceName = @resourceName"; //SQL to get the location of resource from database
            cmdGetResourceLocation = new OleDbCommand(getResourceLocationSQL, conn2);
            cmdGetResourceLocation.Parameters.AddWithValue("@resourceName", User.resourceName);
            string location = Convert.ToString(cmdGetResourceLocation.ExecuteScalar());
            conn2.Close();
            return location;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            conn2.Open();
            string userID = getUserID(User.Username);
            string getRoleSQL = "SELECT role FROM TBLUsers WHERE userID = @userID";
            OleDbCommand cmdGetRole = new OleDbCommand(getRoleSQL, conn2);
            cmdGetRole.Parameters.AddWithValue("@userID", userID);
            string role = Convert.ToString(cmdGetRole.ExecuteScalar());

            if (role.ToUpper() == "TEACHER")
            {
                frmTeacherMainMenu nf = new frmTeacherMainMenu();
                nf.Show();
                this.Hide();
            }
            else
            {
                frmStudentMainMenu nf = new frmStudentMainMenu();
                nf.Show();
                this.Hide();
            }
        }


        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }


        private void frmSubjectResources_Load(object sender, EventArgs e)
        {
            try
            {
                conn2.Open();
                string sqlSubjectResources = "SELECT TBLSubjects.subjectName, TBLResources.resourceName FROM TBLSubjects INNER JOIN(TBLResources INNER JOIN TBLSubjectResources ON TBLResources.[resourceID] = TBLSubjectResources.[resourceID]) ON TBLSubjects.[subjectID] = TBLSubjectResources.[subjectID] ORDER BY subjectName ASC";

                //SQL Query to return resourceID, file, resourceName
                OleDbDataAdapter daSubjectResources = new OleDbDataAdapter();
                OleDbCommand cmdSubjectResources = new OleDbCommand();
                DataSet dsSubjectResources = new DataSet();

                //Define dataset, command and data adapter
                daSubjectResources = new OleDbDataAdapter(sqlSubjectResources, conn2);
                daSubjectResources.Fill(dsSubjectResources, "dsSubjectResources");
                cmdSubjectResources = new OleDbCommand(sqlSubjectResources, conn2);
                
                int number = 0;
                OleDbDataReader drSubjectResources = cmdSubjectResources.ExecuteReader();
                while (drSubjectResources.Read())
                {
                    number++;
                }
                drSubjectResources.Close();
                conn2.Close();

                if(number != 0)
                {
                    dgvSubjectResources.Rows.Clear();
                    dgvSubjectResources.Refresh();
                    if(number != 1)
                    {
                        dgvSubjectResources.Rows.Add(number - 1);
                    }
                }
                //Code above uses data reader to read through all records/rows in the dataset, then increments an integer which keeps track of the total number of record in the dataset
                //Uses this number to add rows to the datagrid so that all records can be displayed
                //number-1 used so that an extra row is not added (0-base index)

                dgvSubjectResources.AutoResizeColumns();
                dgvSubjectResources.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //Used to autosize the columns so that if more data is added to a column, the data isnt cut off

                for (int i = 0; i < number; i++) //Iterates through rows
                {
                    for (int j = 0; j < 2; j++) //Iterates through columns
                    {
                        dgvSubjectResources.Rows[i].Cells[j].Value = dsSubjectResources.Tables["dsSubjectResources"].Rows[i].ItemArray[j].ToString();
                        //Populates datagrid using dataset and double for loop. Iterates through columns and rows to fill the datagrid in the same format as the dataset
                    }
                }
            }
            catch
            {
                MessageBox.Show("An error has occured");
            }
        }

        private void dgvSubjectResources_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string resourceName = "";
            int selectedColumnCount = dgvSubjectResources.GetCellCount(DataGridViewElementStates.Selected); //Gets number of cells selected
            if (selectedColumnCount > 0)
            {
                for (int i = 0; i < selectedColumnCount; i++)
                {
                    int row = Convert.ToInt32(dgvSubjectResources.SelectedCells[i].RowIndex.ToString());
                    resourceName = dgvSubjectResources.Rows[row].Cells[1].Value.ToString();
                    //gets row number, then sets column to be 0 to always get the username
                }
                User.resourceName = resourceName; //sets global class variable to the name of the resource the user clicked on
                string url = getResourceLocation(User.resourceName);
                WebRequest request = WebRequest.Create(url);
                WebResponse response;
                //using network variables to check to see if the web page is available or not
                try
                {
                    response = request.GetResponse(); //checks response of the web page
                    frmViewResources nf = new frmViewResources();
                    nf.Show();
                    this.Hide();
                }
                catch
                {
                    MessageBox.Show("Could not load PDF");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                conn2.Open();
                string sqlSearchSubjects = "SELECT TBLSubjects.subjectName, TBLResources.resourceName FROM TBLSubjects INNER JOIN(TBLResources INNER JOIN TBLSubjectResources ON TBLResources.[resourceID] = TBLSubjectResources.[resourceID]) ON TBLSubjects.[subjectID] = TBLSubjectResources.[subjectID] WHERE TBLResources.resourceName LIKE @userInput ORDER BY TBLSubjects.subjectName ASC";
                OleDbDataAdapter daSubjectResources = new OleDbDataAdapter();
                OleDbCommand cmdSearchSubjects = new OleDbCommand();
                DataSet dsSearchSubjects = new DataSet();
                //Defines dataset, data adapter and data command

                daSubjectResources = new OleDbDataAdapter(sqlSearchSubjects, conn2);
                daSubjectResources.SelectCommand.Parameters.AddWithValue("@userInput", "%" + tbSearchBar.Text + "%");
                daSubjectResources.Fill(dsSearchSubjects, "dsSearchSubjects");
                //Fills dataset using data adapter
                //Data adapter will bring back records the user has searched for

                cmdSearchSubjects = new OleDbCommand(sqlSearchSubjects, conn2);
                cmdSearchSubjects.Parameters.AddWithValue("@userInput", "%" + tbSearchBar.Text + "%");

                int number = 0;
                OleDbDataReader drViewStudents = cmdSearchSubjects.ExecuteReader();
                while (drViewStudents.Read())
                {
                    number++;
                }
                conn2.Close();
                drViewStudents.Close();

                if (number != 0)
                {
                    dgvSubjectResources.Rows.Clear();
                    dgvSubjectResources.Refresh();
                    if(number != 1)
                    {
                        dgvSubjectResources.Rows.Add(number - 1);
                    }
                    //Resets datagrid and refreshes it so changes can be seen

                    dgvSubjectResources.AutoResizeColumns();
                    dgvSubjectResources.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //Used to autosize the columns so that if more data is added to a column, the data isnt cut off

                    for (int i = 0; i < number; i++) //Iterates through columns
                    {
                        for (int j = 0; j < 2; j++) //Iterates through rows
                        {
                            dgvSubjectResources.Rows[i].Cells[j].Value = dsSearchSubjects.Tables["dsSearchSubjects"].Rows[i].ItemArray[j].ToString();
                            //Populates datagrid using dataset and double for loop. Iterates through columns and rows to fill the datagrid in the same format as the dataset
                        }
                    }
                    dsSearchSubjects.Clear();
                }
                else
                {
                    MessageBox.Show("No record in database");
                }
            }
            catch
            {
                MessageBox.Show("An error has occured");
                conn2.Close();
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            loadCheckedListBox();

            if (Convert.ToBoolean(btnFilter.Tag) == true)
            {
                btnFilter.Tag = false;
                clbSubjectFilter.Visible = false;
                btnConfirm.Visible = false;
            }
            else
            {
                btnFilter.Tag = true;
                clbSubjectFilter.Visible = true;
                btnConfirm.Visible = true;
            }
            //Opens/closes checked list box when button is clicked over and over again
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string resourceName = tbSearchBar.Text; //stores resourceName for SQL like command
            List<string> subjectFilter = new List<string>(); //List to hold subjects chosen in subject filter
            foreach (object itemChecked in clbSubjectFilter.CheckedItems)
            {
                string subject = clbSubjectFilter.GetItemText(itemChecked);
                subjectFilter.Add(subject);
            }
            //Adds subjects chosen in the checked list box to a list

            string subjectFilterSQL = "SELECT TBLSubjects.subjectName, TBLResources.resourceName FROM TBLSubjects INNER JOIN(TBLResources INNER JOIN TBLSubjectResources ON TBLResources.[resourceID] = TBLSubjectResources.[resourceID]) ON TBLSubjects.[subjectID] = TBLSubjectResources.[subjectID] WHERE TBLResources.resourceName LIKE @resourceName AND ";
            if (subjectFilter.Count != 0)
            {
                for (int i = 0; i < subjectFilter.Count; i++)
                {
                    subjectFilterSQL = subjectFilterSQL + "TBLSubjects.subjectName = @subjectName" + i.ToString() + " OR ";
                }
                conn2.Open();
                //For loop used to continually add parameters to SQL statement
                subjectFilterSQL = Regex.Replace(subjectFilterSQL, @"OR $", String.Empty);
                subjectFilterSQL = subjectFilterSQL + "ORDER BY TBLSubjects.subjectName ASC";

                OleDbDataAdapter daSubjectFilter = new OleDbDataAdapter();
                OleDbCommand cmdSubjectFilter = new OleDbCommand();
                DataSet dsSubjectFilter = new DataSet();
                //Define data variables needed

                daSubjectFilter = new OleDbDataAdapter(subjectFilterSQL, conn2);
                daSubjectFilter.SelectCommand.Parameters.AddWithValue("@resourceName", "%" + resourceName + "%"); //LIKE parameter
                //Define SQL dataset/data adapter
                for (int j = 0; j < subjectFilter.Count; j++)
                {
                    daSubjectFilter.SelectCommand.Parameters.AddWithValue("@subjectName" + j.ToString(), subjectFilter[j]);
                }
                //Iteration to add parameters over and over again
                daSubjectFilter.Fill(dsSubjectFilter, "dsSubjectFilter");

                cmdSubjectFilter = new OleDbCommand(subjectFilterSQL, conn2);
                cmdSubjectFilter.Parameters.AddWithValue("@resourceName", "%" + resourceName + "%"); //LIKE parameter
                for (int j = 0; j < subjectFilter.Count; j++)
                {
                    cmdSubjectFilter.Parameters.AddWithValue("@subjectName" + j.ToString(), subjectFilter[j]);
                }
                //Iteration to add parameters over and over again

                int number = 0;
                OleDbDataReader drViewStudents = cmdSubjectFilter.ExecuteReader();
                while (drViewStudents.Read())
                {
                    number++;
                }
                //data reader used to get number of rows in the dataset
                conn2.Close();
                drViewStudents.Close();

                if (number != 0)
                {
                    dgvSubjectResources.Rows.Clear();
                    dgvSubjectResources.Refresh();
                    if (number != 1)
                    {
                        dgvSubjectResources.Rows.Add(number - 1);
                    }
                    //Resets datagrid and refreshes it so changes can be seen

                    dgvSubjectResources.AutoResizeColumns();
                    dgvSubjectResources.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //Used to autosize the columns so that if more data is added to a column, the data isnt cut off

                    for (int i = 0; i < number; i++) //Iterates through columns
                    {
                        for (int j = 0; j < 2; j++) //Iterates through rows
                        {
                            dgvSubjectResources.Rows[i].Cells[j].Value = dsSubjectFilter.Tables["dsSubjectFilter"].Rows[i].ItemArray[j].ToString();
                            //Populates datagrid using dataset and double for loop. Iterates through columns and rows to fill the datagrid in the same format as the dataset
                        }
                    }
                    dsSubjectFilter.Clear();
                    //clear data set so no "old" data is in data grid view
                }
                else
                {
                    MessageBox.Show("No record in database");
                }
            }
            else
            {
                //Same code as loading the original view of the datagrid
                try
                {
                    conn2.Open();
                    string sqlSubjectResources = "SELECT TBLSubjects.subjectName, TBLResources.resourceName FROM TBLSubjects INNER JOIN(TBLResources INNER JOIN TBLSubjectResources ON TBLResources.[resourceID] = TBLSubjectResources.[resourceID]) ON TBLSubjects.[subjectID] = TBLSubjectResources.[subjectID] ORDER BY subjectName ASC";

                    //SQL Query to return resourceID, file, resourceName
                    OleDbDataAdapter daSubjectResources = new OleDbDataAdapter();
                    OleDbCommand cmdSubjectResources = new OleDbCommand();
                    DataSet dsSubjectResources = new DataSet();

                    //Define dataset, command and data adapter
                    daSubjectResources = new OleDbDataAdapter(sqlSubjectResources, conn2);
                    daSubjectResources.Fill(dsSubjectResources, "dsSubjectResources");
                    cmdSubjectResources = new OleDbCommand(sqlSubjectResources, conn2);

                    int number = 0;
                    OleDbDataReader drSubjectResources = cmdSubjectResources.ExecuteReader();
                    while (drSubjectResources.Read())
                    {
                        number++;
                    }
                    drSubjectResources.Close();
                    conn2.Close();

                    if (number != 0)
                    {
                        dgvSubjectResources.Rows.Clear();
                        dgvSubjectResources.Refresh();
                        if (number != 1)
                        {
                            dgvSubjectResources.Rows.Add(number - 1);
                        }
                    }
                    //Code above uses data reader to read through all records/rows in the dataset, then increments an integer which keeps track of the total number of record in the dataset
                    //Uses this number to add rows to the datagrid so that all records can be displayed
                    //number-1 used so that an extra row is not added (0-base index)

                    dgvSubjectResources.AutoResizeColumns();
                    dgvSubjectResources.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //Used to autosize the columns so that if more data is added to a column, the data isnt cut off

                    for (int i = 0; i < number; i++) //Iterates through rows
                    {
                        for (int j = 0; j < 2; j++) //Iterates through columns
                        {
                            dgvSubjectResources.Rows[i].Cells[j].Value = dsSubjectResources.Tables["dsSubjectResources"].Rows[i].ItemArray[j].ToString();
                            //Populates datagrid using dataset and double for loop. Iterates through columns and rows to fill the datagrid in the same format as the dataset
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("An error has occured");
                }
            }
        }
    }
}
