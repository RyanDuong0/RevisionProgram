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

namespace RevisionProgram
{
    public partial class frmViewStudents : Form
    {
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        public frmViewStudents()
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
            string sqlSubjects = "SELECT DISTINCT subjectName FROM TBLSubjects ORDER BY subjectName ASC"; //SQL Statement to select all subject names, but no duplicates
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

        private void frmViewStudents_Load(object sender, EventArgs e)
        {
            try
            {
                conn2.Open();
                string sqlViewStudents = "SELECT TBLUsers.username, TBLUsers.forename, TBLUsers.surname, TBLSubjects.subjectLevel, TBLSubjects.subjectName FROM TBLUsers INNER JOIN(TBLSubjects INNER JOIN TBLEntry ON TBLSubjects.[subjectID] = TBLEntry.[subjectID]) ON TBLUsers.[userID] = TBLEntry.[userID] ORDER BY username ASC, TBLSubjects.subjectName ASC";
                //SQL Query to return forename, surname, subjectLevel, subjectID and subjectName from the database
                OleDbDataAdapter daViewStudents = new OleDbDataAdapter();
                OleDbCommand cmdViewStudents = new OleDbCommand();
                DataSet dsViewStudents = new DataSet();
                DataTable dtViewStudents = new DataTable();
                //DataGridView dgvViewStudents = new GroupDataGrid();

                //Define dataset, command and data adapter
                daViewStudents = new OleDbDataAdapter(sqlViewStudents, conn2);
                daViewStudents.Fill(dsViewStudents, "dsViewStudents");
                daViewStudents.Fill(dtViewStudents);
                dsViewStudents.Tables[0].DefaultView.Sort = "username ASC";
                cmdViewStudents = new OleDbCommand(sqlViewStudents, conn2);
                //var grouper =
                int number = 0;
                OleDbDataReader drViewStudents = cmdViewStudents.ExecuteReader();
                while (drViewStudents.Read())
                {
                    number++;
                }
                drViewStudents.Close();
                conn2.Close();
                dgvViewStudents.Rows.Add(number - 1);
                //Code above uses data reader to read through all records/rows in the dataset, then increments an integer which keeps track of the total number of record in the dataset
                //Uses this number to add rows to the datagrid so that all records can be displayed
                //number-1 used so that an extra row is not added (0-base index)

                dgvViewStudents.AutoResizeColumns();
                dgvViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                //Used to autosize the columns so that if more data is added to a column, the data isnt cut off

                //dgvViewStudents.CellFormatting += ;
                for (int i = 0; i < number; i++) //Iterates through rows
                {
                    for (int j = 0; j < 5; j++) //Iterates through columns
                    {
                        dgvViewStudents.Rows[i].Cells[j].Value = dsViewStudents.Tables["dsViewStudents"].Rows[i].ItemArray[j].ToString();
                        //Populates datagrid using dataset and double for loop. Iterates through columns and rows to fill the datagrid in the same format as the dataset
                    }
                }

                /*
                int subjectCounter = 0;
                for(int i = 0; i < dtViewStudents.Rows.Count; i++)
                {
                    if(dtViewStudents.Rows[i][0].ToString() == dtViewStudents.Rows[i+1][0].ToString())
                    {
                        subjectCounter++;
                        MessageBox.Show(dtViewStudents.Rows[i][0].ToString());
                        MessageBox.Show(dtViewStudents.Rows[i+1][0].ToString());
                    }
                    else
                    {
                        MessageBox.Show(dtViewStudents.Rows[i][0].ToString());
                        MessageBox.Show(dtViewStudents.Rows[i + 1][0].ToString());
                    }
                }
                //For loop compares usernames in SORTED datatable, if index = index + 1, increment counter then compare next adjacent pairs
                //if not equal, still compare next adjacent pairs
                */
            }
            catch
            {
                MessageBox.Show("An error has occured");
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmTeacherMainMenu nf = new frmTeacherMainMenu();
            nf.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }

        private void dgvViewStudents_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string username = "";
            int selectedColumnCount = dgvViewStudents.GetCellCount(DataGridViewElementStates.Selected); //Gets number of cells selected
            if (selectedColumnCount > 0)
            {
                for (int i = 0; i < selectedColumnCount; i++)
                {
                    int row = Convert.ToInt32(dgvViewStudents.SelectedCells[i].RowIndex.ToString());
                    username = dgvViewStudents.Rows[row].Cells[0].Value.ToString();
                    //gets row number, then sets column to be 1 to always get the username
                }
                User.editAccountUsername = username;
                frmEditStudentAccount nf = new frmEditStudentAccount();
                nf.Show();
                this.Hide();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                conn2.Open();
                string sqlSearchStudents = "SELECT TBLUsers.username, TBLUsers.forename, TBLUsers.surname, TBLUsers.subjectLevel, TBLSubjects.subjectName FROM TBLUsers INNER JOIN(TBLSubjects INNER JOIN TBLEntry ON TBLSubjects.[subjectID] = TBLEntry.[subjectID]) ON TBLUsers.[userID] = TBLEntry.[userID] WHERE TBLUsers.username LIKE @userInput ORDER BY TBLUsers.username ASC, TBLSubjects.subjectName ASC";
                OleDbDataAdapter daViewStudents = new OleDbDataAdapter();
                OleDbCommand cmdSearchStudents = new OleDbCommand();
                DataSet dsSearchStudents = new DataSet();
                //Defines dataset, data adapter and data command

                daViewStudents = new OleDbDataAdapter(sqlSearchStudents, conn2);
                daViewStudents.SelectCommand.Parameters.AddWithValue("@userInput", "%" + tbSearchBar.Text + "%");
                daViewStudents.Fill(dsSearchStudents, "dsSearchStudents");
                //Fills dataset using data adapter
                //Data adapter will bring back records the user has searched for

                cmdSearchStudents = new OleDbCommand(sqlSearchStudents, conn2);
                cmdSearchStudents.Parameters.AddWithValue("@userInput", "%" + tbSearchBar.Text + "%");

                int number = 0;
                OleDbDataReader drViewStudents = cmdSearchStudents.ExecuteReader();
                while (drViewStudents.Read())
                {
                    number++;
                }
                conn2.Close();
                drViewStudents.Close();
                if (number != 0)
                {
                    dgvViewStudents.Rows.Clear();
                    dgvViewStudents.Refresh();
                    dgvViewStudents.Rows.Add(number - 1);
                    //Resets datagrid and refreshes it so changes can be seen

                    dgvViewStudents.AutoResizeColumns();
                    dgvViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //Used to autosize the columns so that if more data is added to a column, the data isnt cut off

                    for (int i = 0; i < number; i++) //Iterates through columns
                    {
                        for (int j = 0; j < 5; j++) //Iterates through rows
                        {
                            dgvViewStudents.Rows[i].Cells[j].Value = dsSearchStudents.Tables["dsSearchStudents"].Rows[i].ItemArray[j].ToString();
                            //Populates datagrid using dataset and double for loop. Iterates through columns and rows to fill the datagrid in the same format as the dataset
                        }
                    }
                    dsSearchStudents.Clear();
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

            if(Convert.ToBoolean(btnFilter.Tag) == true)
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
            string username = tbSearchBar.Text; //stores username for SQL LIKE command
            List<string> subjectFilter = new List<string>(); //List to hold subjects chosen in subject filter
            foreach (object itemChecked in clbSubjectFilter.CheckedItems)
            {
                string subject = clbSubjectFilter.GetItemText(itemChecked);
                subjectFilter.Add(subject);
            }
            //Adds subjects chosen in the checked list box to a list

            string subjectFilterSQL = "SELECT TBLUsers.username, TBLUsers.forename, TBLUsers.surname, TBLUsers.subjectLevel, TBLSubjects.subjectName FROM TBLUsers INNER JOIN(TBLSubjects INNER JOIN TBLEntry ON TBLSubjects.[subjectID] = TBLEntry.[subjectID]) ON TBLUsers.[userID] = TBLEntry.[userID] WHERE TBLUsers.username LIKE @username AND ";
            if (subjectFilter.Count != 0)
            {
                for(int i = 0; i < subjectFilter.Count; i++)
                {
                    subjectFilterSQL = subjectFilterSQL + "TBLSubjects.subjectName = @subjectName" + i.ToString() + " OR ";
                }
                conn2.Open();
                //For loop used to continually add parameters to SQL statement
                subjectFilterSQL = Regex.Replace(subjectFilterSQL, @"OR $", String.Empty);
                subjectFilterSQL = subjectFilterSQL + "ORDER BY TBLUsers.username ASC, TBLSubjects.subjectName ASC";

                OleDbDataAdapter daSubjectFilter = new OleDbDataAdapter();
                OleDbCommand cmdSubjectFilter = new OleDbCommand();
                DataSet dsSubjectFilter = new DataSet();
                //Define data variables needed

                daSubjectFilter = new OleDbDataAdapter(subjectFilterSQL, conn2);
                //Define SQL dataset/data adapter
                daSubjectFilter.SelectCommand.Parameters.AddWithValue("@username", "%" + username+ "%"); //LIKE parameter
                for(int j = 0; j < subjectFilter.Count; j++)
                {
                    daSubjectFilter.SelectCommand.Parameters.AddWithValue("@subjectName" + j.ToString(), subjectFilter[j]);
                }
                //Iteration to add parameters over and over again
                daSubjectFilter.Fill(dsSubjectFilter, "dsSubjectFilter");

                cmdSubjectFilter = new OleDbCommand(subjectFilterSQL, conn2); //LIKE parameter
                cmdSubjectFilter.Parameters.AddWithValue("@username", "%" + username + "%");
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
                    dgvViewStudents.Rows.Clear();
                    dgvViewStudents.Refresh();
                    if(number != 1)
                    {
                        dgvViewStudents.Rows.Add(number - 1);
                    }
                    //Resets datagrid and refreshes it so changes can be seen

                    dgvViewStudents.AutoResizeColumns();
                    dgvViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //Used to autosize the columns so that if more data is added to a column, the data isnt cut off

                    for (int i = 0; i < number; i++) //Iterates through columns
                    {
                        for (int j = 0; j < 5; j++) //Iterates through rows
                        {
                            dgvViewStudents.Rows[i].Cells[j].Value = dsSubjectFilter.Tables["dsSubjectFilter"].Rows[i].ItemArray[j].ToString();
                            //Populates datagrid using dataset and double for loop. Iterates through columns and rows to fill the datagrid in the same format as the dataset
                        }
                    }
                    dsSubjectFilter.Clear();
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
                    string sqlViewStudents = "SELECT TBLUsers.username, TBLUsers.forename, TBLUsers.surname, TBLSubjects.subjectLevel, TBLSubjects.subjectName FROM TBLUsers INNER JOIN(TBLSubjects INNER JOIN TBLEntry ON TBLSubjects.[subjectID] = TBLEntry.[subjectID]) ON TBLUsers.[userID] = TBLEntry.[userID] ORDER BY username ASC, TBLSubjects.subjectName ASC";
                    //SQL Query to return forename, surname, subjectLevel, subjectID and subjectName from the database
                    OleDbDataAdapter daViewStudents = new OleDbDataAdapter();
                    OleDbCommand cmdViewStudents = new OleDbCommand();
                    DataSet dsViewStudents = new DataSet();
                    DataTable dtViewStudents = new DataTable();
                    //DataGridView dgvViewStudents = new GroupDataGrid();

                    //Define dataset, command and data adapter
                    daViewStudents = new OleDbDataAdapter(sqlViewStudents, conn2);
                    daViewStudents.Fill(dsViewStudents, "dsViewStudents");
                    dsViewStudents.Tables[0].DefaultView.Sort = "username ASC";
                    cmdViewStudents = new OleDbCommand(sqlViewStudents, conn2);
                    int number = 0;
                    OleDbDataReader drViewStudents = cmdViewStudents.ExecuteReader();
                    while (drViewStudents.Read())
                    {
                        number++;
                    }
                    drViewStudents.Close();
                    conn2.Close();

                    dgvViewStudents.Rows.Clear();
                    dgvViewStudents.Refresh();
                    //Clear data grid view before re-displaying the data

                    dgvViewStudents.Rows.Add(number - 1);
                    //Code above uses data reader to read through all records/rows in the dataset, then increments an integer which keeps track of the total number of record in the dataset
                    //Uses this number to add rows to the datagrid so that all records can be displayed
                    //number-1 used so that an extra row is not added (0-base index)

                    dgvViewStudents.AutoResizeColumns();
                    dgvViewStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    //Used to autosize the columns so that if more data is added to a column, the data isnt cut off

                    //dgvViewStudents.CellFormatting += ;
                    for (int i = 0; i < number; i++) //Iterates through rows
                    {
                        for (int j = 0; j < 5; j++) //Iterates through columns
                        {
                            dgvViewStudents.Rows[i].Cells[j].Value = dsViewStudents.Tables["dsViewStudents"].Rows[i].ItemArray[j].ToString();
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
