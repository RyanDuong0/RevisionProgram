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
    public partial class frmViewResources : Form
    {
        OleDbConnection conn2 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=N:\\A Level Computer Science\\Project\\Database\\RevisonProgramDatabase.accdb"); //New database connection for main database
        public frmViewResources()
        {
            InitializeComponent();
            lblResourceName.Text = User.resourceName;
            wbPDFViewer.Navigate(getResourceLocation(User.resourceName));
        }

        public string getResourceLocation(string resourceName)
        {
            conn2.Open();
            OleDbCommand cmdGetResourceLocation = new OleDbCommand();
            string getResourceLocationSQL = "SELECT resourceLocation FROM TBLResources WHERE resourceName = @resourceName"; //SQL to get the location of resource from database
            cmdGetResourceLocation = new OleDbCommand(getResourceLocationSQL, conn2);
            cmdGetResourceLocation.Parameters.AddWithValue("@resourceName", User.resourceName);
            string location = Convert.ToString(cmdGetResourceLocation.ExecuteScalar());
            conn2.Close();
            return location;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            frmSubjectResources nf = new frmSubjectResources();
            nf.Show();
            this.Hide();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            frmSignIn nf = new frmSignIn();
            nf.Show();
            this.Hide();
        }

        private void frmViewResources_Load(object sender, EventArgs e)
        {

        }
    }
}
