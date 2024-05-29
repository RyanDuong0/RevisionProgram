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
    public partial class frmRegistration : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\Userpasswords.accdb"); //Creates new database connection for the TBLPasswords table
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        OleDbCommand cmd;

        public frmRegistration()
        {
            InitializeComponent();
            cbRole.Items.Add("Student");
            cbRole.Items.Add("Teacher");
            this.cbRole.DropDownStyle = ComboBoxStyle.DropDownList; //Makes the combo box read-only so that users cannot type in the combo box
        }

        private void Form1_Load(object sender, EventArgs e) //Function should be named frmRegstration_Load
        {

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

        private string incrementUserID() //Function to get the most recent userID so that it can be modified for new accounts
        {
            string userIDSQL = "SELECT TOP 1 userID FROM TBLUsers ORDER BY userID DESC"; //SQL statement to get the first item in a list of all userIDs which are ordered in descending order
                                                                                         //This grabs the most recent userID as it is the larger value
            cmd = new OleDbCommand(userIDSQL, conn2); //Runs sql statement that gets the most recent userID on TBLUsers
            string recentUserID = Convert.ToString(cmd.ExecuteScalar());
            if(recentUserID == "")
            {
                recentUserID = "U00000";
            }
            else
            {
                string character = recentUserID.Substring(0, 1); //Selects first character so "U"
                int integer = Convert.ToInt32(recentUserID.Substring(1,  5)); //Selects the digits after U
                integer++; //Increments digit by 1
                int integerLength = integer.ToString().Length;
                int decimalLength; //Defines new variable that holds the length of the number of decimals that need to be added onto the end of the userID which acts as padding
                switch (integerLength) //Switch statement used to perform different instructions depending on if the length of the integer is in the units, tens, hundreds, thousands or ten thousands
                {
                    case 1:
                        decimalLength = integer.ToString("D").Length + 4; //If the integer is in the units, four 0's need to padded
                        recentUserID = character + integer.ToString("D" + decimalLength.ToString());
                        break;
                    case 2:
                        decimalLength = integer.ToString("D").Length + 3; //If the integer is in the tens, three 0's need to be padded
                        recentUserID = character + integer.ToString("D" + decimalLength.ToString());
                        break;
                    case 3:
                        decimalLength = integer.ToString("D").Length + 2; //If the integer is in the hundreds, two 0's need to be padded
                        recentUserID = character + integer.ToString("D" + decimalLength.ToString());
                        break;
                    case 4:
                        decimalLength = integer.ToString("D").Length + 1; //If the integer is in the thousands, one 0 need to be padded
                        recentUserID = character + integer.ToString("D" + decimalLength.ToString());
                        break;
                    case 5:
                        decimalLength = integer.ToString("D").Length + 0; //If the integer is in the ten thousands, no 0's need to be padded
                        recentUserID = character + integer.ToString("D" + decimalLength.ToString());
                        break;
                    default:
                        MessageBox.Show("ERROR");
                        break;
                }
            }
            return recentUserID;
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            string username = tbUsername.Text; //Declares local variable "username" which stores the inputted username from textbox
            string forename = tbForename.Text;
            string surname = tbSurname.Text;
            string email = tbEmail.Text;
            string role = cbRole.Text;
            //Creates local variables for all other inputs

            if (forename.Length < 1 || forename.Length > 15)
            {
                MessageBox.Show("Forename must be between 1 and 15 characters long!");
                return;
            }
            if(surname.Length < 1 || surname.Length > 15)
            {
                MessageBox.Show("Surname must be between 1 and 15 characters long!");
                return;
            }
            if(username.Length < 1 || username.Length > 20)
            {
                MessageBox.Show("Username must be between 1 and 20 characters long!");
                return;
            }
            if (isValid(email) == true)
            {
                //Nothing here as we do not need to output anything if the email is valid
            }
            else
            {
                MessageBox.Show("Please input a valid email!");
                return;
            }
            if(role == "Student" || role == "Teacher")
            { 
                //Nothing here as we do not need to output anything if the roles are correct
            }
            else
            {
                MessageBox.Show("Select a valid role!");
                return;
            }
            if (tbPassword.Text.Length <= 7 || tbPassword.Text.Length >= 16)
            {
                MessageBox.Show("Password must be between 8 and 15 characters long!"); //Selection used to validate that the password is of the correct length
                return;
            }
            if(tbPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("Passwords are not the same!"); //Selection used to validate that password and confirm password are the same
            }
            else
            {
                string password = Encryption.hashString(tbPassword.Text); //Uses encryption module to hash the password
                string salt = Encryption.generateSalt(); //Generates random salt
                string hashSalt = Encryption.hashString(String.Format("{0}{1}", password, salt)); //Combines generated hash and salt, then stores it in local variable
                
                //Stores all other details in variables so that they can be stored later

                string checkUsernameSQL = "SELECT Count(*) FROM TBLPasswords WHERE username = @User"; //Checks username in TBLPasswords
                string checkUsername2SQL = "SELECT Count(*) FROM TBLUsers WHERE username = @User"; //Checks username in TBLUsers
                conn.Open();
                conn2.Open();
                OleDbCommand cmdTBLUsers; //Defines new local command that will run on the TBLUsers table and will check for duplicate usernames
                OleDbCommand cmdTBLPasswords; //Defines new local command that will run on the TBLPasswords table and will check for duplicate usernames
                cmdTBLPasswords = new OleDbCommand(checkUsernameSQL, conn); //Runs check usernameSQL on first connection which checks for duplicate usernames in the TBLPasswords table
                cmdTBLUsers = new OleDbCommand(checkUsername2SQL, conn2); //Runs check usernameSQL on second connection, checking for duplicate usernames in the TBLUsers table
                cmdTBLPasswords.Parameters.AddWithValue("@User", username);
                cmdTBLUsers.Parameters.AddWithValue("@User", username); //This line and the one above just adds the variable "username" as the parameter so that both databases can be queried.
                int resultTBLPasswords = Convert.ToInt32(cmdTBLPasswords.ExecuteScalar()); //Runs SQL statement to return the number of users that have the same username as the one inputted (in TBLPasswords)
                int resultTBLUsers = Convert.ToInt32(cmdTBLUsers.ExecuteScalar()); //Runs SQL statement to return the number of users that have the same username as the one inputted (in TBLUsers)
                if((resultTBLUsers > 0) && (resultTBLPasswords > 0)) //If the number of results from both tables are greater than 0, it means that username is already in use
                {
                    MessageBox.Show("Username is already in use!");
                    conn.Close();
                    conn2.Close();
                }
                else //If not greater than 0, we can store the new username, hashed password and salt into the database
                {
                    string insertPasswordsSQL = "INSERT INTO TBLPasswords(username, userPassword, salt) VALUES(@Value1, @Value2, @Value3)"; //SQL Statement to insert the username, password and salt into the passwords database
                    string insertInfoSQL = "INSERT INTO TBLUsers (userID, forename, surname, username, email, role) VALUES(@userID, @Forename, @Surname, @Username, @Email, @Role)"; //SQL Statement to insert the user's details into the main database
                    int i; //For conn
                    int j; //For conn2
                    cmd = new OleDbCommand(insertPasswordsSQL, conn);
                    cmd.Parameters.AddWithValue("@Value1", username);
                    cmd.Parameters.AddWithValue("@Value2", hashSalt);
                    cmd.Parameters.AddWithValue("@Value3", salt);
                    i = cmd.ExecuteNonQuery();
                    conn.Close();
                    //Inserts new data into the database by running insertPasswordsSQL statement on database connection. Data inserted into TBLPasswords table

                    string recentUserID = incrementUserID(); //Calls function defined earlier and stores the most recently created account's userID in a local variable
                    cmd = new OleDbCommand(insertInfoSQL, conn2);
                    cmd.Parameters.AddWithValue("@userID", recentUserID);
                    cmd.Parameters.AddWithValue("@Forename", forename);
                    cmd.Parameters.AddWithValue("@Surname", surname);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Role", role);
                    j = cmd.ExecuteNonQuery();
                    conn2.Close();
                    if(i > 0 && j > 0) //Check to see if rows from passwords and main database have been affected, if so, an account will be created
                    {
                        MessageBox.Show("Account created");
                        frmSignIn nf = new frmSignIn();
                        nf.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Account not created");
                    }
                }
            }
        }

        private void cbRole_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAlreadyHaveAccount_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }
    }
}
