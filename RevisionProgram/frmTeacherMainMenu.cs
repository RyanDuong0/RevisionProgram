using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RevisionProgram
{
    public partial class frmTeacherMainMenu : Form
    {
        public frmTeacherMainMenu()
        {
            InitializeComponent();
        }

        private void btnViewStudents_Click(object sender, EventArgs e)
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
            //Logs user out of account and returns them to the main menu
        }

        private void btnAccountInformation_Click(object sender, EventArgs e)
        {
            frmAccountInformation nf = new frmAccountInformation();
            nf.Show();
            this.Hide();
        }

        private void frmTeacherMainMenu_Load(object sender, EventArgs e)
        {

        }

        private void btnHelpPage_Click(object sender, EventArgs e) //Teacher main menu
        {
            frmHelpPage nf = new frmHelpPage();
            nf.Show();
            this.Hide();
        }

        private void btnSubjectResources_Click(object sender, EventArgs e) //Teacher main menu
        {
            frmSubjectResources nf = new frmSubjectResources();
            nf.Show();
            this.Hide();
        }
    }
}
