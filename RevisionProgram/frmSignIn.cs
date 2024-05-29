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
using System.Data.SqlClient;

namespace RevisionProgram
{
    //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ryand\OneDrive\Documents\College\Project\Database\RevisonProgramDatabase.accdb
    //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\ryand\OneDrive\Documents\College\Project\Database\Userpasswords.accdb
    public partial class frmSignIn : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\Userpasswords.accdb"); //Creates new database connection for the TBLPasswords table
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        OleDbCommand cmd;
        
        public frmSignIn()
        {
            InitializeComponent();
        }

        private void frmSignIn_Load(object sender, EventArgs e)
        {

        }

        private void btnDontHaveAccount_Click(object sender, EventArgs e)
        {
            frmRegistration nf = new frmRegistration();
            nf.Show();
            this.Hide();
        }
        
        private bool checkTeacher(string username) //return true if teacher, return false if student
        {
            string checkRoleSQL = "SELECT role FROM TBLUsers WHERE username = @User"; //SQL statement to get the role of the account with inputted username
            conn2.Open();
            cmd = new OleDbCommand(checkRoleSQL, conn2);
            cmd.Parameters.AddWithValue("@User", username);
            string role = Convert.ToString(cmd.ExecuteScalar()); //Role that is returned from the database stored in variable
            conn2.Close();
            if(role.ToUpper() == "TEACHER")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void btnSignIn_Click(object sender, EventArgs e)
        {
            if(tbUsername.Text == "")
            {
                MessageBox.Show("Please enter a username");
                return;
            }
            if(tbPassword.Text == "")
            {
                MessageBox.Show("Please enter a password");
                return;
            }
            string checkUserSQL = "SELECT * FROM TBLPasswords WHERE username = @User"; //SQL statement to select all fields that have the username that the user has inputted
            cmd = new OleDbCommand(checkUserSQL, conn); //Runs this sql statement on the passwords database
            string username = tbUsername.Text;
            string salt = "";
            conn.Open();
            cmd.Parameters.AddWithValue("@User", username);
            OleDbDataReader reader = cmd.ExecuteReader(); //Creates a data reader. Used to read data rows from a database
            while (reader.Read())
            {
                salt = reader["salt"].ToString(); //Takes the salt stored in the database and then stores it in a variable
            }
            reader.Close();

            string pass = Encryption.hashString(tbPassword.Text);//Creates a new hash for the inputted password. If the inputted password is the same as the password stored in the database, the 
                                                                 //hashed password should be the exact same
            string hashSalt = Encryption.hashString(String.Format("{0}{1}", pass, salt)); //A new hashsalt is made which should match the hashSalt for the password stored in the database
            string loginQuerySQL = "SELECT COUNT(*) FROM TBLPasswords WHERE username = @User AND userPassword = @Pass"; //SQL to find number of accounts with the inputted username and password
            cmd = new OleDbCommand(loginQuerySQL, conn);
            cmd.Parameters.AddWithValue("@User", username);
            cmd.Parameters.AddWithValue("@Pass", hashSalt);

            int result = Convert.ToInt32(cmd.ExecuteScalar());

            if(result == 1)
            {
                MessageBox.Show("Login successful, welcome back: " + username);
                if(checkTeacher(username) == true)
                {
                    //MessageBox.Show("TEST: you are a teacher");
                    frmTeacherMainMenu nf = new frmTeacherMainMenu();
                    User.Username = username;
                    nf.Show();
                    this.Hide();
                }
                else
                {
                    //MessageBox.Show("TEST: you are a student");
                    frmStudentMainMenu nf = new frmStudentMainMenu();
                    User.Username = username;
                    nf.Show();
                    this.Hide();
                    
                }
            }
            else
            {
                MessageBox.Show("Login failed");
                //Error message displayed
            }
            conn.Close();
        }

        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
            frmForgotPassword nf = new frmForgotPassword();
            nf.Show();
            this.Hide();
        }
    }
}
