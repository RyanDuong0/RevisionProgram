namespace RevisionProgram
{
    partial class frmStudentMainMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblMainMenu = new System.Windows.Forms.Label();
            this.btnSubjectPreferences = new System.Windows.Forms.Button();
            this.btnSubjectResources = new System.Windows.Forms.Button();
            this.btnHelpPage = new System.Windows.Forms.Button();
            this.btnAccountInformation = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.linkLblTools = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblMainMenu
            // 
            this.lblMainMenu.AutoSize = true;
            this.lblMainMenu.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainMenu.Location = new System.Drawing.Point(309, 9);
            this.lblMainMenu.Name = "lblMainMenu";
            this.lblMainMenu.Size = new System.Drawing.Size(198, 45);
            this.lblMainMenu.TabIndex = 0;
            this.lblMainMenu.Text = "Main Menu";
            this.lblMainMenu.Click += new System.EventHandler(this.lblMainMenu_Click);
            // 
            // btnSubjectPreferences
            // 
            this.btnSubjectPreferences.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnSubjectPreferences.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubjectPreferences.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjectPreferences.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubjectPreferences.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjectPreferences.ForeColor = System.Drawing.Color.White;
            this.btnSubjectPreferences.Location = new System.Drawing.Point(172, 123);
            this.btnSubjectPreferences.Name = "btnSubjectPreferences";
            this.btnSubjectPreferences.Size = new System.Drawing.Size(209, 93);
            this.btnSubjectPreferences.TabIndex = 17;
            this.btnSubjectPreferences.Text = "Subject Preferences";
            this.btnSubjectPreferences.UseVisualStyleBackColor = false;
            this.btnSubjectPreferences.Click += new System.EventHandler(this.btnSubjectPreferences_Click);
            // 
            // btnSubjectResources
            // 
            this.btnSubjectResources.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnSubjectResources.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSubjectResources.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubjectResources.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSubjectResources.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubjectResources.ForeColor = System.Drawing.Color.White;
            this.btnSubjectResources.Location = new System.Drawing.Point(439, 123);
            this.btnSubjectResources.Name = "btnSubjectResources";
            this.btnSubjectResources.Size = new System.Drawing.Size(209, 93);
            this.btnSubjectResources.TabIndex = 18;
            this.btnSubjectResources.Text = "Subject Resources";
            this.btnSubjectResources.UseVisualStyleBackColor = false;
            this.btnSubjectResources.Click += new System.EventHandler(this.btnSubjectResources_Click);
            // 
            // btnHelpPage
            // 
            this.btnHelpPage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnHelpPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHelpPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHelpPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHelpPage.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHelpPage.ForeColor = System.Drawing.Color.White;
            this.btnHelpPage.Location = new System.Drawing.Point(172, 275);
            this.btnHelpPage.Name = "btnHelpPage";
            this.btnHelpPage.Size = new System.Drawing.Size(209, 93);
            this.btnHelpPage.TabIndex = 19;
            this.btnHelpPage.Text = "Help Page";
            this.btnHelpPage.UseVisualStyleBackColor = false;
            this.btnHelpPage.Click += new System.EventHandler(this.btnHelpPage_Click);
            // 
            // btnAccountInformation
            // 
            this.btnAccountInformation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnAccountInformation.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAccountInformation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccountInformation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAccountInformation.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccountInformation.ForeColor = System.Drawing.Color.White;
            this.btnAccountInformation.Location = new System.Drawing.Point(439, 275);
            this.btnAccountInformation.Name = "btnAccountInformation";
            this.btnAccountInformation.Size = new System.Drawing.Size(209, 93);
            this.btnAccountInformation.TabIndex = 20;
            this.btnAccountInformation.Text = "Account Information";
            this.btnAccountInformation.UseVisualStyleBackColor = false;
            this.btnAccountInformation.Click += new System.EventHandler(this.btnAccountInformation_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogOut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(689, 12);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(99, 31);
            this.btnLogOut.TabIndex = 21;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // linkLblTools
            // 
            this.linkLblTools.AutoSize = true;
            this.linkLblTools.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblTools.Location = new System.Drawing.Point(340, 401);
            this.linkLblTools.Name = "linkLblTools";
            this.linkLblTools.Size = new System.Drawing.Size(142, 15);
            this.linkLblTools.TabIndex = 22;
            this.linkLblTools.TabStop = true;
            this.linkLblTools.Text = "Click here for more tools";
            this.linkLblTools.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblTools_LinkClicked);
            // 
            // frmStudentMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.linkLblTools);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.btnAccountInformation);
            this.Controls.Add(this.btnHelpPage);
            this.Controls.Add(this.btnSubjectResources);
            this.Controls.Add(this.btnSubjectPreferences);
            this.Controls.Add(this.lblMainMenu);
            this.Name = "frmStudentMainMenu";
            this.Text = "frmStudentMainMenu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMainMenu;
        private System.Windows.Forms.Button btnSubjectPreferences;
        private System.Windows.Forms.Button btnSubjectResources;
        private System.Windows.Forms.Button btnHelpPage;
        private System.Windows.Forms.Button btnAccountInformation;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.LinkLabel linkLblTools;
    }
}