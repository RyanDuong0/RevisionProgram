using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace RevisionProgram
{
    public partial class frmRevisionTools : Form
    {
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        public frmRevisionTools()
        {
            InitializeComponent();
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

        private void btnTimer_Click(object sender, EventArgs e)
        {
            frmTimer nf = new frmTimer();
            nf.Show();
            this.Hide();
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
            conn2.Close();
        }
    }
}
