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

namespace RevisionProgram
{
    public partial class frmSubjectPreferences : Form
    {
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        //Establish connection to main database
        DataSet ds = new DataSet();
        OleDbDataAdapter da = new OleDbDataAdapter();

        public frmSubjectPreferences()
        {
            InitializeComponent();

            //cbQualificationLevel.Items.Add("A-Level");
            //cbQualificationLevel.Items.Add("GCSE");

            //Adds two values to the qualification level combo box
            
            //this.cbQualificationLevel.DropDownStyle = ComboBoxStyle.DropDownList;
            
            this.cbSubjectOne.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSubjectTwo.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSubjectThree.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cbSubjectFour.DropDownStyle = ComboBoxStyle.DropDownList;
            //Changing style of combo boxes so that they are read only

            cbSubjectFour.Visible = false;
            lblSubjectFour.Visible = false;
            linkLblRemoveSubject.Visible = false;
            lblHelpTip2.Visible = false;
            //Sets the combo boxes that are not needed to be invisible/hidden

            loadCombo();
        }

        private void loadCombo()
        {
            conn2.Open();
            ds.Clear(); //Clears dataset so that no duplicate values are in the combo box
            string level = "A-Level";
            string sqlSubjects = "SELECT subjectName FROM TBLSubjects WHERE subjectLevel = @Level ORDER BY subjectName ASC"; //SQL Statement to select all subjects that are under the qualification level chosen by the user.
            da = new OleDbDataAdapter(sqlSubjects, conn2); //Retrieves all subjects stored in the database where subjectLevel is what the user inputted
            da.SelectCommand.Parameters.AddWithValue("@Level", level); //Parameter added for SQL statement
            da.Fill(ds); //Fills the dataset with the retrieved data from the data adapter

            cbSubjectOne.DataSource = ds.Tables[0].Copy();
            cbSubjectOne.DisplayMember = "subjectName";
            cbSubjectOne.ValueMember = "subjectName";

            cbSubjectTwo.DataSource = ds.Tables[0].Copy();
            cbSubjectTwo.DisplayMember = "subjectName";
            cbSubjectTwo.ValueMember = "subjectName";
                
            cbSubjectThree.DataSource = ds.Tables[0].Copy();
            cbSubjectThree.DisplayMember = "subjectName";
            cbSubjectThree.ValueMember = "subjectName";

            //check if user has picked four subjects
            if (User.hasPickedFour == true)
            {
               cbSubjectFour.DataSource = ds.Tables[0].Copy();
               cbSubjectFour.DisplayMember = "subjectName";
               cbSubjectFour.ValueMember = "subjectName";
               return;
            }
            //Inputs all subjects retrieved from the database into the comboboxes
            conn2.Close();

            /*
            else
            {
                level = "GCSE";
                string sqlSubjects = "SELECT subjectName FROM TBLSubjects WHERE subjectLevel = @Level"; //SQL Statement to select all subjects that are under the qualification level chosen by the user.
                da = new OleDbDataAdapter(sqlSubjects, conn2); //Retrieves all subjects stored in the database where subjectLevel is what the user inputted
                da.SelectCommand.Parameters.AddWithValue("@Level", level); //Parameter added for SQL statement
                da.Fill(ds); //Fills the dataset with the retrieved data from the data adapter

                cbSubjectOne.DataSource = ds.Tables[0].Copy();
                cbSubjectOne.DisplayMember = "subjectName";
                cbSubjectOne.ValueMember = "subjectName";
                
                cbSubjectTwo.DataSource = ds.Tables[0].Copy();
                cbSubjectTwo.DisplayMember = "subjectName";
                cbSubjectTwo.ValueMember = "subjectName";
                
                cbSubjectThree.DataSource = ds.Tables[0].Copy();
                cbSubjectThree.DisplayMember = "subjectName";
                cbSubjectThree.ValueMember = "subjectName";

                cbSubjectFour.DataSource = ds.Tables[0].Copy();
                cbSubjectFour.DisplayMember = "subjectName";
                cbSubjectFour.ValueMember = "subjectName";
                //Inputs all subjects retrieved from the database into the comboboxes

                conn2.Close();
            }
            */
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

        private string[] getSubjectID(string subjectOne, string subjectTwo, string subjectThree, string subjectFour) //Function to get the subjectIDs of all the subjects
        {
            OleDbDataAdapter da = new OleDbDataAdapter();
            DataSet ds = new DataSet();
            string level = "A-Level";
            if(subjectFour != "")
            {
                string getSubjectID = "SELECT subjectID FROM TBLSubjects WHERE subjectName IN (@SubjectOne, @SubjectTwo, @SubjectThree, @SubjectFour) AND subjectLevel = @Level";
                da = new OleDbDataAdapter(getSubjectID, conn2);
                da.SelectCommand.Parameters.AddWithValue("@SubjectOne", subjectOne);
                da.SelectCommand.Parameters.AddWithValue("@SubjectTwo", subjectTwo);
                da.SelectCommand.Parameters.AddWithValue("@SubjectThree", subjectThree);
                da.SelectCommand.Parameters.AddWithValue("@SubjectFour", subjectFour);
                da.SelectCommand.Parameters.AddWithValue("@Level", level);
                da.Fill(ds, "Subjects");
                //Fills dataset with data adapter

                string subjectIdOne = ds.Tables["Subjects"].Rows[0].ItemArray[0].ToString();                   
                string subjectIdTwo = ds.Tables["Subjects"].Rows[1].ItemArray[0].ToString();                
                string subjectIdThree = ds.Tables["Subjects"].Rows[2].ItemArray[0].ToString();                
                string subjectIdFour = ds.Tables["Subjects"].Rows[3].ItemArray[0].ToString();
                //Assigns variables the values stored in the dataset

                string[] subjectArray = new string[4] { subjectIdOne, subjectIdTwo, subjectIdThree, subjectIdFour };
                //Inputs the variables into the array
                
                return subjectArray;
            }
            else
            {
                string getSubjectID = "SELECT subjectID FROM TBLSubjects WHERE subjectName IN (@SubjectOne, @SubjectTwo, @SubjectThree) AND subjectLevel = @Level";
                da = new OleDbDataAdapter(getSubjectID, conn2);
                da.SelectCommand.Parameters.AddWithValue("@SubjectOne", subjectOne);
                da.SelectCommand.Parameters.AddWithValue("@SubjectTwo", subjectTwo);
                da.SelectCommand.Parameters.AddWithValue("@SubjectThree", subjectThree);
                da.SelectCommand.Parameters.AddWithValue("@Level", level);
                da.Fill(ds, "Subjects");
                //Fills dataset with data adapter

                string subjectIdOne = ds.Tables["Subjects"].Rows[0].ItemArray[0].ToString();
                string subjectIdTwo = ds.Tables["Subjects"].Rows[1].ItemArray[0].ToString();
                string subjectIdThree = ds.Tables["Subjects"].Rows[2].ItemArray[0].ToString();
                //Assigns variables the values stored in the dataset

                string[] subjectArray = new string[3] { subjectIdOne, subjectIdTwo, subjectIdThree };
                //Inputs the variables into the array
               
                return subjectArray;
            }
        }

        public static bool isDuplicate(string subjectOne, string subjectTwo, string subjectThree, string subjectFour) //Takes in four parameters which will be the subjects chosen
        {
            bool isDuplicate = false;
            if((subjectOne == subjectTwo)||(subjectOne==subjectThree)||(subjectOne==subjectFour)||(subjectTwo==subjectThree)||(subjectTwo==subjectFour)||(subjectThree==subjectFour))
            {
                isDuplicate = true;
                return isDuplicate;
            }
            return isDuplicate;
        }

        private void frmSubjectPreferences_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmStudentMainMenu nf = new frmStudentMainMenu();
            nf.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string subjectOne = cbSubjectOne.Text;
            string subjectTwo = cbSubjectTwo.Text;
            string subjectThree = cbSubjectThree.Text;
            string subjectFour = cbSubjectFour.Text;
            int check = 0;
            OleDbCommand cmdInsertInfo = new OleDbCommand();
            //Assign variables the values of their respective combo box values 
            if (isDuplicate(subjectOne, subjectTwo, subjectThree, subjectFour) == true)
            {
                //If there is duplicate values, notify the user
                MessageBox.Show("Can not pick the same subject more than once!");
                return;
            }
            else
            {
                conn2.Open();
                string userID = getUserID(User.Username); //Get userID to use to input userID and subjectID into database.
                conn2.Close();
                if (cbSubjectFour.Text != "") //If there is a value in cbSubjectFour, we want to insert 4 values into the database
                {
                    conn2.Open();
                    string insertSubjectsSQL = "INSERT INTO TBLEntry(userID, subjectID) VALUES(@UserID, @SubjectID)"; //Inserts subjects into the database
                    string[] subjectIDArray = getSubjectID(subjectOne, subjectTwo, subjectThree, subjectFour); //For 4 subjects
                    for (int i = 0; i < 4; i++) //Iterates through the array returned by getSubjectID function. Inputs the data into the database one by one, 4 times
                    {
                        string subjectID = subjectIDArray[i];
                        try
                        {
                            cmdInsertInfo = new OleDbCommand(insertSubjectsSQL, conn2);
                            cmdInsertInfo.Parameters.AddWithValue("@UserID", userID);
                            cmdInsertInfo.Parameters.AddWithValue("@SubjectID", subjectID);
                            check = Convert.ToInt32(cmdInsertInfo.ExecuteNonQuery());
                            //Iterates 4 times, inputs userID and subjectID into database
                        }
                        catch //Catch error when student tries to enrol in the same subject again
                        {
                            i = 4;
                            MessageBox.Show("You cannot enrol in the same subject more than once");
                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("You have been enrolled into these subjects: " + subjectOne + ", " + subjectTwo + ", " + subjectThree + ", " + subjectFour);
                    }
                    conn2.Close();
                }
                else if(cbSubjectFour.Text == "")
                {
                    conn2.Open();
                    string insertSubjectsSQL = "INSERT INTO TBLEntry(userID, subjectID) VALUES(@UserID, @SubjectID)"; //Inserts subjects into the database
                    string[] subjectIDArray = getSubjectID(subjectOne, subjectTwo, subjectThree, subjectFour);
                    for (int i = 0; i < 3; i++) //For 3 subjects
                    {
                        string subjectID = subjectIDArray[i];
                        try
                        {
                            cmdInsertInfo = new OleDbCommand(insertSubjectsSQL, conn2);
                            cmdInsertInfo.Parameters.AddWithValue("@UserID", userID);
                            cmdInsertInfo.Parameters.AddWithValue("@SubjectID", subjectID);
                            check = Convert.ToInt32(cmdInsertInfo.ExecuteNonQuery());
                            //Iterates 3 times, inputs userID and subjectID into database
                        }
                        catch //Catch error when student tries to enrol in the same subject again
                        {
                            i = 3;
                            MessageBox.Show("You cannot enrol in the same subject more than once");
                        }
                    }
                    if (check > 0)
                    {
                        MessageBox.Show("You have been enrolled into these subjects: " + subjectOne + ", " + subjectTwo + ", " + subjectThree);
                    }
                    conn2.Close();
                }
            }

            conn2.Open();
            OleDbCommand cmdInsertLevel = new OleDbCommand();
            //string qualificationLevel = cbQualificationLevel.Text;
            string qualificationLevel = "A-Level";
            string insertLevelSQL = "UPDATE TBLUsers SET subjectLevel = @QualificationLevel WHERE username = @Username";
            cmdInsertLevel = new OleDbCommand(insertLevelSQL, conn2);
            cmdInsertLevel.Parameters.AddWithValue("@QualificationLevel", qualificationLevel);
            cmdInsertLevel.Parameters.AddWithValue("@Username", User.Username);
            cmdInsertLevel.ExecuteNonQuery();
            conn2.Close();
            //SQL statement to update the qualification level in the database
        }

        /*
        private void cbQualificationLevel_SelectedIndexChanged(object sender, EventArgs e) //Used to check when the contents of the combo box changes
        {
            string qualificationLevel = cbQualificationLevel.Text; //Stores the qualification level in a variable
            if (qualificationLevel == "A-Level")
            {
                try
                {
                    ds.Clear(); //Clears data set so that no duplicate data is shown in combo box
                    loadCombo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else if(cbQualificationLevel.Text == "GCSE")
            {
                try
                {
                    ds.Clear();
                    loadCombo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        */

        private void linkLabelShowSubject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblSubjectFour.Visible = true;
            cbSubjectFour.Visible = true;
            lblHelpTip.Visible = false;
            linkLblShowSubject.Visible = false;
            //Once this link label is clicked, show subject 4 combo box and label, hide the link label + label

            lblHelpTip2.Visible = true;
            linkLblRemoveSubject.Visible = true;
            User.hasPickedFour = true;
            loadCombo();
            conn2.Close();
        }

        private void linkLblRemoveSubject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            lblSubjectFour.Visible = false;
            cbSubjectFour.Visible = false;
            lblHelpTip2.Visible = false;
            linkLblRemoveSubject.Visible = false;
            //Makes subject 4 combo box disappear, and its label. Makes the "if you take three subjects....." link label and label disappear

            lblHelpTip.Visible = true;
            linkLblShowSubject.Visible = true;
            //Makes the "If you take four subjects...." label and link label re-appear
            cbSubjectFour.DataSource = null;
            User.hasPickedFour = false;
        }

        private void linkLblClickGCSE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmSubjectPreferencesGCSE nf = new frmSubjectPreferencesGCSE();
            nf.Show();
            this.Hide();
        }
    }
}