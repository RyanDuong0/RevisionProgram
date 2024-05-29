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
    public partial class frmSubjectPreferencesGCSE : Form
    {
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        //Establish connection to main database
        OleDbDataAdapter da = new OleDbDataAdapter();

        public frmSubjectPreferencesGCSE()
        {
            InitializeComponent();
            loadCheckedListBox();
        }

        private void loadCheckedListBox() //Function to load the subjects into the checkedListBox
        {
            conn2.Open();
            DataTable dt = new DataTable(); //DataTable used to hold the data from data adapter
            dt.Clear();
            string level = "GCSE";
            string sqlSubjects = "SELECT subjectName FROM TBLSubjects WHERE subjectLevel = @Level ORDER BY subjectName ASC"; //SQL Statement to select all subjects that are under the qualification level chosen by the user.
            da = new OleDbDataAdapter(sqlSubjects, conn2); //Retrieves all subjects stored in the database where subjectLevel has the value "GCSE"
            da.SelectCommand.Parameters.AddWithValue("@Level", level);
            da.Fill(dt); //Fills datatable with data adapter
            try
            {
                clbSubjects.DataSource = dt;
                clbSubjects.DisplayMember = "subjectName";
                clbSubjects.ValueMember = "subjectName";
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
            conn2.Open();
            string getID = "SELECT userID FROM TBLUsers WHERE username = @Username";
            OleDbCommand cmdGetID = new OleDbCommand();
            cmdGetID = new OleDbCommand(getID, conn2);
            cmdGetID.Parameters.AddWithValue("@Username", username);
            string userID = Convert.ToString(cmdGetID.ExecuteScalar());
            conn2.Close();
            return userID;
        }

        private List<string> getSubjectID(List<string> chosenSubjects)
        {
            List<string> subjectIDs = new List<string>(); //List to hold subjectIDs
            string level = "GCSE"; //Used in SQL statement
           
            OleDbCommand cmdGetSubjectID = new OleDbCommand();
            string sqlGetSubjectID = "SELECT * FROM TBLSubjects WHERE subjectName=@Name AND subjectLevel=@Level";
            //SQL and CMD used to get subjectID            

            for(int i = 0; i < chosenSubjects.Count; i++) //Iterates through chosenSubjects to get the subject, and then use SQL to return the subjectID of that subject, then place into new list
            {
                string currentSubject = chosenSubjects[i]; //Temporarily stores current subject in current iteration
                string currentSubjectID = ""; //Temporarily stores current subjectID in current iteration
                cmdGetSubjectID = new OleDbCommand(sqlGetSubjectID, conn2);
                cmdGetSubjectID.Parameters.AddWithValue("@Name", currentSubject);
                cmdGetSubjectID.Parameters.AddWithValue("@Level", level);
                OleDbDataReader reader = cmdGetSubjectID.ExecuteReader(); //Defines reader which will be used to read the dataset
                while (reader.Read())
                {
                    currentSubjectID = reader["subjectID"].ToString(); //Assigns value of currentSubjectID to the ID from the reader
                    subjectIDs.Add(currentSubjectID); //Adds subjectID to the list
                }
                reader.Close();
            }
            return subjectIDs;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSubjectPreferences nf = new frmSubjectPreferences();
            nf.Show();
            this.Hide();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            OleDbCommand cmdInsertInfo = new OleDbCommand();
            string insertSubjectsSQL = "INSERT INTO TBLEntry(userID, subjectID) VALUES(@UserID, @SubjectID)"; //SQL statement to insert subjectID and userID into the database
            string userID = getUserID(User.Username);

            conn2.Open();
            List<string> chosenSubjects = new List<string>(); //Defined list that will be used to store the subjects chosen by the user
            string subject;
            foreach (object itemChecked in clbSubjects.CheckedItems)
            {
                subject = clbSubjects.GetItemText(itemChecked);
                chosenSubjects.Add(subject);
            }
            //Foreach loop used to iterate through the actual data/object where the check box is checked. It then inputs this into the array

            List<string> subjectIDs = new List<string>();
            subjectIDs = getSubjectID(chosenSubjects); //Assigns recently defined list to the list returned by the getSubjectID function

            int check = 0;
            for (int i = 0; i < subjectIDs.Count; i++) //Iterates through subjectIDs and will store them in the database alongside userID
            {
                string currentSubjectID = subjectIDs[i];
                try
                {
                    cmdInsertInfo = new OleDbCommand(insertSubjectsSQL, conn2);
                    cmdInsertInfo.Parameters.AddWithValue("@UserID", userID);
                    cmdInsertInfo.Parameters.AddWithValue("@SubjectID", currentSubjectID);
                    check = Convert.ToInt32(cmdInsertInfo.ExecuteNonQuery());
                }
                catch //Catch error when user tries to enroll in the same subjects
                {
                    i = subjectIDs.Count;
                    MessageBox.Show("You cannot enroll in the same subject more than once");
                }
            }
            if(check > 0)
            {
                int n = chosenSubjects.Count();
                string[] tempSubjects = new string[n];
                string subjects = "";
                for(int i = 0; i < tempSubjects.Length; i++)
                {
                    tempSubjects[i] = chosenSubjects[i];
                    subjects = string.Join(", ", tempSubjects);
                }

                MessageBox.Show("You have been enrolled into these subjects: " + subjects);
            }
            conn2.Close();

            conn2.Open();
            OleDbCommand cmdInsertLevel = new OleDbCommand();
            string qualificationLevel = "GCSE";
            string insertLevelSQL = "UPDATE TBLUsers SET subjectLevel = @QualificationLevel WHERE username = @Username";
            cmdInsertLevel = new OleDbCommand(insertLevelSQL, conn2);
            cmdInsertLevel.Parameters.AddWithValue("@QualificationLevel", qualificationLevel);
            cmdInsertLevel.Parameters.AddWithValue("@Username", User.Username);
            cmdInsertLevel.ExecuteNonQuery();
            conn2.Close();
            //SQL statement to update the qualification level in the database
        }

        private void frmSubjectPreferencesGCSE_Load(object sender, EventArgs e)
        {

        }
    }
}
