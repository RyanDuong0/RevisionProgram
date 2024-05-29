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
    public partial class frmEditStudentAccount : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\Userpasswords.accdb"); //Creates new database connection for the TBLPasswords table
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        //Establishes database connections

        public frmEditStudentAccount()
        {
            InitializeComponent();
            cbNewQualLevel.Items.Add("A-Level");
            cbNewQualLevel.Items.Add("GCSE");

            conn2.Open();
            OleDbCommand cmdGetQualLevel = new OleDbCommand();
            string getQualLevelSQL = "SELECT subjectLevel FROM TBLUsers WHERE username = @Username";
            cmdGetQualLevel = new OleDbCommand(getQualLevelSQL, conn2);
            cmdGetQualLevel.Parameters.AddWithValue("@Username", User.editAccountUsername);
            string qualificationLevel = Convert.ToString(cmdGetQualLevel.ExecuteScalar());
            //SQL and DB commands to get the qualification level of the user that the teacher clicked on
            conn2.Close();

            lblDisplayUsername.Text = String.Format("{0} ({1})" , User.editAccountUsername, qualificationLevel);
        }

        private string generateNewPassword() //Function to randomly generate a new password for the user
        {
            const string characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890"; //List of characters that will be allowed in the new password
            const string password = "Password";
            StringBuilder newPassword = new StringBuilder();
            Random rand = new Random();
            for (int i = 0; i < 4; i++)
            {
                newPassword.Append(characters[rand.Next(characters.Length)]);
            }
            return password + newPassword.ToString();
        }

        private void frmEditStudentAccount_Load(object sender, EventArgs e)
        {

        }

        private void lblResetPassword_Click(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmViewStudents nf = new frmViewStudents();
            nf.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }

        private void btnConfirmChanges_Click(object sender, EventArgs e)
        {
            string username = tbNewUsername.Text;
            if(tbNewUsername.Text == "")
            {
                MessageBox.Show("Username field has been left blank");
                return;
            }
            if(username.Length < 1 || username.Length > 20)
            {
                MessageBox.Show("Username must be between 1 and 20 characters long!");
                return;
            }
            if ((cbNewQualLevel.Text == "") || (cbNewQualLevel.Text != "A-Level" && cbNewQualLevel.Text != "GCSE"))
            {
                MessageBox.Show("Please select a valid qualification level");
            }
            //Validation checks
            else
            {
                string newUsername = tbNewUsername.Text;
                string newQualLevel = cbNewQualLevel.Text;
                //Assign variables needed for the SQL statement
                string oldUsername = User.editAccountUsername;
                OleDbCommand cmdUpdateDetails = new OleDbCommand();
                OleDbCommand cmdCheckUsername = new OleDbCommand();
                OleDbCommand cmdUpdateUsername = new OleDbCommand();
                DialogResult yesNoBox = MessageBox.Show("Are you sure? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //Check if user actually wants to change details.

                conn2.Open();
                conn.Open();
                if (yesNoBox == DialogResult.Yes)
                {
                    string checkUsernameSQL = "SELECT COUNT(*) FROM TBLUsers WHERE username = @newUsername"; //SQL to check if username is already in use
                    string updateDetailsSQL = "UPDATE TBLUsers SET username = @newUsername, subjectLevel = @newQualLevel WHERE username = @oldUsername"; //SQL statement to update details (MAIN DATABASE)
                    string updateUsernameSQL = "UPDATE TBLPasswords SET username = @newUsername WHERE username = @oldUsername"; //SQL statement to update username (PASSWORDS DATABASE)
                    cmdCheckUsername = new OleDbCommand(checkUsernameSQL, conn2);
                    cmdCheckUsername.Parameters.AddWithValue("@newUsername", newUsername);
                    int count = Convert.ToInt32(cmdCheckUsername.ExecuteScalar());
                    if (count > 0) //If count > 0, it means username already in use
                    {
                        MessageBox.Show("Username is already in use");
                    }
                    else
                    {
                        cmdUpdateDetails = new OleDbCommand(updateDetailsSQL, conn2);
                        cmdUpdateDetails.Parameters.AddWithValue("@newUsername", newUsername);
                        cmdUpdateDetails.Parameters.AddWithValue("@newQualLevel", newQualLevel);
                        cmdUpdateDetails.Parameters.AddWithValue("@oldUsername", oldUsername);

                        cmdUpdateUsername = new OleDbCommand(updateUsernameSQL, conn);
                        cmdUpdateUsername.Parameters.AddWithValue("@newUsername", newUsername);
                        cmdUpdateUsername.Parameters.AddWithValue("@oldUsername", oldUsername);
                        //Add parameters required for the SQL statement to update the details
                        try
                        {
                            cmdUpdateDetails.ExecuteNonQuery();
                            cmdUpdateUsername.ExecuteNonQuery();
                            MessageBox.Show("Changes sucessful");
                        }
                        catch(Exception ex) //Catch errors and output message
                        {
                            MessageBox.Show(ex.ToString());
                            MessageBox.Show("Changes unsuccessful");
                        }
                    }
                    conn2.Close();
                    conn.Close();
                    User.editAccountUsername = newUsername;
                }
            }
        }

        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = User.editAccountUsername;
            OleDbCommand cmdUpdatePassword = new OleDbCommand();
            DialogResult yesNoBox = MessageBox.Show("Are you sure? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(yesNoBox == DialogResult.Yes)
            {
                conn.Open();
                string newPassword = generateNewPassword();

                string databasePassword = Encryption.hashString(newPassword); //New variable to store the hashed password
                string salt = Encryption.generateSalt();
                string hashSalt = Encryption.hashString(String.Format("{0}{1}", databasePassword, salt)); //New hash and salted created to be stored in the database

                string sqlUpdatePassword = "UPDATE TBLPasswords SET [userPassword] = @HashSalt, [salt] = @Salt WHERE [username] = @Username"; //Updates password stored in database with the newly created one
                cmdUpdatePassword = new OleDbCommand(sqlUpdatePassword, conn);
                cmdUpdatePassword.Parameters.AddWithValue("@HashSalt", hashSalt);
                cmdUpdatePassword.Parameters.AddWithValue("@Salt", salt);
                cmdUpdatePassword.Parameters.AddWithValue("@Username", username);
                try
                {
                    cmdUpdatePassword.ExecuteNonQuery();
                    MessageBox.Show("Reset successful. New password is: " + newPassword);
                }
                catch
                {
                    MessageBox.Show("Password reset unsuccessful");
                }
                conn.Close();
            }
        }
    }
}
