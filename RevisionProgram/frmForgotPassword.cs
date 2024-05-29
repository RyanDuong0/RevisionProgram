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
using System.Security.Cryptography;
using System.Net.Mail;

namespace RevisionProgram
{
    public partial class frmForgotPassword : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\Userpasswords.accdb"); //Creates new database connection for the TBLPasswords table
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        OleDbCommand cmd = new OleDbCommand();
        //Establish connections to both databases
        public frmForgotPassword()
        {
            InitializeComponent();
        }

        private void frmForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private string generateNewPassword() //Function to randomly generate a new password for the user
        {
            const string characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"; //List of characters that will be allowed in the new password
            StringBuilder newPassword = new StringBuilder();
            Random rand = new Random();
            for(int i = 0; i < 8; i++)
            {
                newPassword.Append(characters[rand.Next(characters.Length)]);
            }
            return newPassword.ToString();
        }

        private static bool isValid(string email)
        {
            var valid = true;

            try
            {
                var emailAddress = new MailAddress(email);
            }
            catch
            {
                valid = false;
            }

            return valid;
        }

        private void btnBack_Click(object sender, EventArgs e) //Button takes the user back to sign in page
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text;
            string email = tbEmail.Text;

            if (isValid(email) == true)
            {
                string checkUsernameSQL = "SELECT Count(*) FROM TBLPasswords WHERE username = @User"; //Checks username in TBLPasswords
                string checkUsername2SQL = "SELECT Count(*) FROM TBLUsers WHERE username = @User"; //Checks username in TBLUsers
                string checkEmailSQL = "SELECT Count(*) FROM TBLUsers WHERE email = @Email";
                conn.Open();
                conn2.Open();
                OleDbCommand cmdTBLUsers; //Defines new local command that will run on the TBLUsers table and will check to see if username in DB == inputted username
                OleDbCommand cmdTBLPasswords; //Defines new local command that will run on the TBLPasswords and check to see if username in DB == inputted username
                OleDbCommand cmdCheckEmail; //Defines new local command that will run on the TLBUsers table and checks to see if the email the user inputted is valid
                cmdTBLPasswords = new OleDbCommand(checkUsernameSQL, conn); //Runs check usernameSQL on first connection which searches for inputted username
                cmdTBLUsers = new OleDbCommand(checkUsername2SQL, conn2); //Runs check usernameSQL on second connection and also searches for inputted username
                cmdCheckEmail = new OleDbCommand(checkEmailSQL, conn2); //Runs checkEmailSQL on second connection, validating that the email is in the database
                cmdTBLPasswords.Parameters.AddWithValue("@User", username);
                cmdTBLUsers.Parameters.AddWithValue("@User", username);
                cmdCheckEmail.Parameters.AddWithValue("@Email", email); //This line and the two above just adds the variable "username" as the parameter so that both databases can be queried.
                int resultTBLPasswords = Convert.ToInt32(cmdTBLPasswords.ExecuteScalar()); //Runs SQL statement to return the number of users that have the same username as the one inputted (in TBLPasswords)
                int resultTBLUsers = Convert.ToInt32(cmdTBLUsers.ExecuteScalar()); //Runs SQL statement to return the number of users that have the same username as the one inputted (in TBLUsers)
                int resultCheckEmail = Convert.ToInt32(cmdCheckEmail.ExecuteScalar()); //Runs SQL statement to return number of users with the inputted email
                conn.Close();
                conn2.Close();

                if(resultCheckEmail == 0) //If number of email results is 0, it means that no account has the inputted email
                {
                    MessageBox.Show("Incorrect email");
                    return;
                }
                if ((resultTBLUsers == 0) && (resultTBLPasswords == 0)) //If the number of results is 0, it means that no account with that username exists
                {
                    MessageBox.Show("Account does not exist!");
                }
                else
                {
                    DialogResult yesNoBox = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //Creates a Yes or No dialog box
                    if (yesNoBox == DialogResult.Yes)
                    {
                        conn.Open();
                        string newPassword = generateNewPassword();

                        string databasePassword = Encryption.hashString(newPassword); //New variable to store the hashed password
                        string salt = Encryption.generateSalt();
                        string hashSalt = Encryption.hashString(String.Format("{0}{1}", databasePassword, salt)); //New hash and salted created to be stored in the database

                        string sqlUpdatePassword = "UPDATE TBLPasswords SET [userPassword] = @HashSalt, [salt] = @Salt WHERE [username] = @Username"; //Updates password stored in database with the newly created one
                        cmd = new OleDbCommand(sqlUpdatePassword, conn);
                        cmd.Parameters.AddWithValue("@HashSalt", hashSalt);
                        cmd.Parameters.AddWithValue("@Salt", salt);
                        cmd.Parameters.AddWithValue("@Username", username);
                        try
                        {
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Reset successful. Your new password is: " + newPassword + "\nPlease sign in");
                        }
                        catch
                        {
                            MessageBox.Show("Password reset unsuccessful");
                        }
                        conn.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Invalid email!");
            }
        }
    }
}
