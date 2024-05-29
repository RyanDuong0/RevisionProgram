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
using System.Net.Mail;

namespace RevisionProgram
{
    public partial class frmAccountInformation : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\Userpasswords.accdb"); //Creates new database connection for the TBLPasswords table
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        public frmAccountInformation()
        {
            InitializeComponent();
            string email;
            string role;
            string subjectLevel;

            string getAccountDetails = "SELECT email, role, subjectLevel FROM TBLUsers WHERE username = @Username";
            OleDbDataAdapter daAccountDetails = new OleDbDataAdapter();
            DataSet dsAccDetails = new DataSet();
            daAccountDetails = new OleDbDataAdapter(getAccountDetails, conn2);
            daAccountDetails.SelectCommand.Parameters.AddWithValue("@Username", User.Username);
            daAccountDetails.Fill(dsAccDetails, "Details");
            //Instructions used to get the email and role, and stores it into a dataset to be displayed to the user

            email = dsAccDetails.Tables["Details"].Rows[0].ItemArray[0].ToString(); //Retrieves email from the dataset which is the first item in array dataset
            role = dsAccDetails.Tables["Details"].Rows[0].ItemArray[1].ToString(); //Retrieves role from the dataset which is the second item in array dataset

            if (role.ToUpper() == "TEACHER") //Check if role is teacher
            {
                subjectLevel = "N/A"; //Teacher not studying subjects so no qualification level shown
            }
            else
            {
                subjectLevel = dsAccDetails.Tables["Details"].Rows[0].ItemArray[2].ToString(); //Retrieves qualifcation level from the dataset which is the third item in array dataset
                if(subjectLevel == "")
                {
                    //lblDisplayQualLevel
                    subjectLevel = "N/A";
                }
            }

            lblDisplayUsername.Text = User.Username;
            lblDisplayEmail.Text = email;
            lblDisplayRole.Text = role;
            lblDisplayQualLevel.Text = subjectLevel;
            dsAccDetails.Clear();
            //Assgins all labels their respective values

            if(lblDisplayRole.Text == "Teacher") //Hides reset subject objects if they are a teacher
            {
                lblResetSubjects.Visible = false;
                linkLblResetSubject.Visible = false;
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

        private void btnConfirmPassword_Click(object sender, EventArgs e) //Confirm button for passwords
        {
            string newPassword = tbNewPassword.Text;
            string confirmPassword = tbConfirmPassword.Text;
            //Initialised variables and assigned them appropriate values to be used later

            if((tbOldPassword.Text == "") || (tbNewPassword.Text == "") || (tbConfirmPassword.Text == ""))
            {
                MessageBox.Show("One or more fields have been left blank!");
                return;
            }
            if (tbNewPassword.Text.Length <= 7 || tbNewPassword.Text.Length >= 16)
            {
                MessageBox.Show("Password must be between 8 and 15 characters long!"); //Selection used to validate that the password is of the correct length
                return;
            }
            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }
            //Validation checks to ensure no fields are left blank, the inputs are of the correct length and the passwords DO match

            conn.Open();
            conn2.Open();

            OleDbCommand cmdUpdatePassword = new OleDbCommand();
            OleDbCommand cmdCheckUser = new OleDbCommand();
            OleDbCommand cmdGetSalt = new OleDbCommand();
            //Defines commands to use separately for different purposes

            string getSaltSQL = "SELECT * FROM TBLPasswords WHERE username = @User"; //SQL statement to select all fields that have the username that the user has inputted
            cmdGetSalt = new OleDbCommand(getSaltSQL, conn); //Runs this sql statement on the passwords database
            string salt = "";
            cmdGetSalt.Parameters.AddWithValue("@User", User.Username);
            OleDbDataReader reader = cmdGetSalt.ExecuteReader(); //Creates a data reader. Used to read data rows from a database
            while (reader.Read())
            {
                salt = reader["salt"].ToString(); //Takes the salt stored in the database and then stores it in a variable
            }
            reader.Close();
            //Gets the salt stored in the database so that it can be used to validate the "old password" textbox

            string oldPassword = Encryption.hashString(tbOldPassword.Text);
            string hashSalt = Encryption.hashString(String.Format("{0}{1}", oldPassword, salt));
            string checkPassword = "SELECT COUNT(*) FROM TBLPasswords WHERE username = @Username AND userPassword = @Pass";
            cmdCheckUser = new OleDbCommand(checkPassword, conn);
            cmdCheckUser.Parameters.AddWithValue("@Username", User.Username);
            cmdCheckUser.Parameters.AddWithValue("@Pass", hashSalt);
            int result = Convert.ToInt32(cmdCheckUser.ExecuteScalar());
            //Checks to see if the password inputted in "old password" textbox is the same as the one stored in the database

            conn.Close();
            conn2.Close();

            if(result == 1) //if result is one, user inputted the correct password, so now we allow them to change their password and username
            {
                DialogResult yesNoBox = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //Creates a Yes or No dialog box
                if (yesNoBox == DialogResult.Yes)
                {
                    conn.Open();
                    conn2.Open();

                    string databasePassword = Encryption.hashString(newPassword);
                    string newSalt = Encryption.generateSalt();
                    string newHashSalt = Encryption.hashString(String.Format("{0}{1}", databasePassword, newSalt));
                    //Takes the new password then hashes it, salts it then hashes it again to then be stored in the database

                    string updatePasswordSQL = "UPDATE TBLPasswords SET userPassword = @HashSalt, salt = @Salt WHERE username = @Username";
                    cmdUpdatePassword = new OleDbCommand(updatePasswordSQL, conn);
                    cmdUpdatePassword.Parameters.AddWithValue("@HashSalt", newHashSalt);
                    cmdUpdatePassword.Parameters.AddWithValue("@Salt", newSalt);
                    cmdUpdatePassword.Parameters.AddWithValue("@Username", User.Username);
                    //SQL statement to update the password stored in TBLUsers
                    try
                    {
                        cmdUpdatePassword.ExecuteNonQuery();
                        MessageBox.Show("Details updated!");
                    }
                    catch
                    {
                        MessageBox.Show("Unsuccessful change");
                    }
                    conn.Close();
                    conn2.Close();
                }
            }
            else
            {
                MessageBox.Show("Incorrect password!");
                conn.Close();
                conn2.Close();
            }
        }

        private void btnConfirmUsername_Click(object sender, EventArgs e)
        {
            string newUsername = tbNewUsername.Text;
            if(tbNewUsername.Text == "")
            {
                MessageBox.Show("Username field has been left blank!");
                return;
            }
            if (tbNewUsername.Text.Length < 1 || tbNewUsername.Text.Length > 20)
            {
                MessageBox.Show("Username must be between 1 and 20 characters long!");
                return;
            }

            conn.Open();
            conn2.Open();

            OleDbCommand cmdUpdateUsername = new OleDbCommand(); //For main database
            OleDbCommand cmdUpdateUsername2 = new OleDbCommand(); //For the passwords database
            OleDbCommand cmdCheckUsername = new OleDbCommand(); //To check to see if the new username is already in use

            string checkUsernameSQL = "SELECT COUNT(*) FROM TBLUsers WHERE username = @Username";
            cmdCheckUsername = new OleDbCommand(checkUsernameSQL, conn2);
            cmdCheckUsername.Parameters.AddWithValue("@Username", newUsername);
            int result = Convert.ToInt32(cmdCheckUsername.ExecuteScalar());
            if(result > 0)
            {
                MessageBox.Show("Username is already in use!");
                conn.Close();
                conn2.Close();
            }
            else
            {
                DialogResult yesNoBox = MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); //Creates a Yes or No dialog box
                if (yesNoBox == DialogResult.Yes)
                {
                    string userID = getUserID(User.Username);
                    string updateUsernameSQL = "UPDATE TBLUsers SET username = @Username WHERE userID = @userID"; //SQL query to update just the username in main database
                    cmdUpdateUsername = new OleDbCommand(updateUsernameSQL, conn2);
                    cmdUpdateUsername.Parameters.AddWithValue("@Username", newUsername);
                    cmdUpdateUsername.Parameters.AddWithValue("@userID", userID);
                    //Commands to update the username in TBLUsers

                    string updateUsernameSQL2 = "UPDATE TBLPasswords SET username = @newUsername WHERE username = @oldUsername"; //SQL query to update username in passwords database
                    cmdUpdateUsername2 = new OleDbCommand(updateUsernameSQL2, conn);
                    cmdUpdateUsername2.Parameters.AddWithValue("@newUsername", tbNewUsername.Text);
                    cmdUpdateUsername2.Parameters.AddWithValue("@oldUsername", User.Username);
                    //Commands to update the username in TBLPasswords

                    User.Username = newUsername; //Updates the username to the new one, so it can be displayed
                    try
                    {
                        cmdUpdateUsername.ExecuteNonQuery();
                        cmdUpdateUsername2.ExecuteNonQuery();
                        MessageBox.Show("Username updated!");
                    }
                    catch
                    {
                        MessageBox.Show("Unsuccesful change!");
                    }
                    conn.Close();
                    conn2.Close();
                }
            }
        }

        private void frmAccountInformation_Load(object sender, EventArgs e)
        {

        }

        private void linkLblResetSubject_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult yesNoBox = MessageBox.Show("Are you sure? ", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(yesNoBox == DialogResult.Yes)
            {
                conn2.Open();
                string userID = getUserID(User.Username);
                string removeSubjectsSQL = "DELETE * FROM TBLEntry WHERE userID = @UserID"; //SQL statement to remove all records where the userID is the same
                string removeQualificationLvlSQL = "UPDATE TBLUsers SET subjectLevel = null WHERE userID = @UserID"; //SQL to alter the subjectLevel in database

                OleDbCommand cmdRemoveSubjects = new OleDbCommand();
                OleDbCommand cmdRemoveQualificationLvl = new OleDbCommand();
                try
                {
                    cmdRemoveSubjects = new OleDbCommand(removeSubjectsSQL, conn2);
                    cmdRemoveQualificationLvl = new OleDbCommand(removeQualificationLvlSQL, conn2);
                    cmdRemoveSubjects.Parameters.AddWithValue("@UserID", userID);
                    cmdRemoveQualificationLvl.Parameters.AddWithValue("@UserID", userID);
                    int result = Convert.ToInt32(cmdRemoveSubjects.ExecuteNonQuery()); //Stores integer value to see if the SQL statement worked
                    int result2 = Convert.ToInt32(cmdRemoveQualificationLvl.ExecuteNonQuery()); //Stores integer value to see if the SQL statement worked

                    if (result > 0 && result2 > 0)
                    {
                        MessageBox.Show("Reset successful! \nPlease refresh the page");
                    }
                    else
                    {
                        MessageBox.Show("Reset unsuccessful");
                    }
                }
                catch
                {
                    MessageBox.Show("Reset unsuccessful");
                }
            }
            conn2.Close();
        }
    }
}