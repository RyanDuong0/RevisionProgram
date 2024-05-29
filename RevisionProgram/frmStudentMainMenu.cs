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

    public partial class frmStudentMainMenu : Form
    {
        public frmStudentMainMenu()
        {
            InitializeComponent();
        }

        private void lblMainMenu_Click(object sender, EventArgs e)
        {

        }

        private void btnAccountInformation_Click(object sender, EventArgs e)
        {
            frmAccountInformation nf = new frmAccountInformation();
            nf.Show();
            this.Hide();
            
        }

        private void btnHelpPage_Click(object sender, EventArgs e) //Student main menu
        {
            frmHelpPage nf = new frmHelpPage();
            nf.Show();
            this.Hide();
        }

        private void btnSubjectPreferences_Click(object sender, EventArgs e)
        {
            frmSubjectPreferences nf = new frmSubjectPreferences();
            nf.Show();
            this.Hide();
        }

        private void btnSubjectResources_Click(object sender, EventArgs e) //Student main menu
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
            //Logs user out of account and returns them to the main menu
        }

        private void linkLblTools_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmRevisionTools nf = new frmRevisionTools();
            nf.Show();
            this.Hide();
        }
    }
}
