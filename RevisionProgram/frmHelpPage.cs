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
    public partial class frmHelpPage : Form
    {
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database       
        public frmHelpPage()
        {
            InitializeComponent();

            conn2.Open();
            OleDbCommand cmdGetRole = new OleDbCommand();
            string userID = getUserID(User.Username);
            string getRoleSQL = "SELECT role FROM TBLUsers WHERE userID = @userID";
            cmdGetRole = new OleDbCommand(getRoleSQL, conn2);
            cmdGetRole.Parameters.AddWithValue("@userID", userID);
            string role = Convert.ToString(cmdGetRole.ExecuteScalar());
            conn2.Close();

            lblStudentInfo.Text = "•Start off by heading over to the Subject Preferences page" +
                                  "\n•Select the qualification level you are currently studying at" +
                                  "\n•Choose the subjects you are currently studying" +
                                  "\n•Once complete, head over to the Subject Resources page to access past papers and other resources" +
                                  "\n•If you have changed qualification level, or are studying a different subject, head over to the Account Information" +
                                  "\n  page to reset your subjects." +
                                  "\n  This page will also allow you to change your username and password" +
                                  "\n•There is also a revision timer which can be used to revise for a pre-determined length of time and a messagebox" +
                                  "\n  will pop notifying you that the time is up";

            lblTeacherInfo.Text = "•This account is a teacher account so it has access to more adminstrative controls" +
                                  "\n•The View Students page allows you to access a portion of the database, showing all of the students that " +
                                  "\n  are currently signed up with the system" +
                                  "\n•If a student has forgotten their password and email, their username and password can be changed through the " +
                                  "\n  View Students page. Double click on the student's account and enter a new username, and reset their password" +
                                  "\n•If you need to change any details of this account, head over to the Account Information page, which will" +
                                  "\n  allow you to change your username and password" +
                                  "\n•The Subject Resources page can be used to view the resources that students have access to" +
                                  "\n  and this can be used to assign students homeworks within lesson";

            lblStudentInfo.Visible = false;
            lblTeacherInfo.Visible = false;
            lblStudents.Visible = false;
            lblTeachers.Visible = false;

            if(role.ToUpper() == "TEACHER")
            {
                lblTeacherInfo.Visible = true;
                lblTeachers.Visible = true;
            }
            else
            {
                lblStudentInfo.Visible = true;
                lblStudents.Visible = true;
            }
        }

        private string getUserID(string username)
        {
            string getID = "SELECT userID FROM TBLUsers WHERE username = @Username";
            OleDbCommand cmdGetID = new OleDbCommand();
            cmdGetID = new OleDbCommand(getID, conn2);
            cmdGetID.Parameters.AddWithValue("@Username", username);
            string userID = Convert.ToString(cmdGetID.ExecuteScalar());
            return userID;
        }

        private void lblHelpPage_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            conn2.Open();
            string userID = getUserID(User.Username);
            OleDbCommand cmdGetRole = new OleDbCommand();
            string getRoleSQL = "SELECT role FROM TBLUsers WHERE userID = @UserID";
            cmdGetRole = new OleDbCommand(getRoleSQL, conn2);
            cmdGetRole.Parameters.AddWithValue("@UserID", userID);
            string role = Convert.ToString(cmdGetRole.ExecuteScalar());

            if(role.ToUpper() == "TEACHER")
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
            conn2.Close();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }

        private void frmHelpPage_Load(object sender, EventArgs e)
        {

        }
    }
}
