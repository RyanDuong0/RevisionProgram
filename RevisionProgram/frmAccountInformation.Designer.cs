namespace RevisionProgram
{
    partial class frmAccountInformation
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
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblAccountInformation = new System.Windows.Forms.Label();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblChangeDetails = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblNewUsername = new System.Windows.Forms.Label();
            this.tbNewUsername = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.tbOldPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.tbNewPassword = new System.Windows.Forms.TextBox();
            this.tbConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.btnConfirmPassword = new System.Windows.Forms.Button();
            this.lblDisplayUsername = new System.Windows.Forms.Label();
            this.lblDisplayEmail = new System.Windows.Forms.Label();
            this.lblDisplayRole = new System.Windows.Forms.Label();
            this.btnConfirmUsername = new System.Windows.Forms.Button();
            this.lblDisplayQualLevel = new System.Windows.Forms.Label();
            this.lblQualificationLevel = new System.Windows.Forms.Label();
            this.lblResetSubjects = new System.Windows.Forms.Label();
            this.linkLblResetSubject = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnLogOut.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogOut.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.White;
            this.btnLogOut.Location = new System.Drawing.Point(689, 9);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(99, 31);
            this.btnLogOut.TabIndex = 22;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(584, 9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(99, 31);
            this.btnBack.TabIndex = 23;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblAccountInformation
            // 
            this.lblAccountInformation.AutoSize = true;
            this.lblAccountInformation.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountInformation.Location = new System.Drawing.Point(225, 0);
            this.lblAccountInformation.Name = "lblAccountInformation";
            this.lblAccountInformation.Size = new System.Drawing.Size(337, 45);
            this.lblAccountInformation.TabIndex = 24;
            this.lblAccountInformation.Text = "Account Information";
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.Location = new System.Drawing.Point(109, 108);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(90, 33);
            this.lblDetails.TabIndex = 25;
            this.lblDetails.Text = "Details";
            // 
            // lblChangeDetails
            // 
            this.lblChangeDetails.AutoSize = true;
            this.lblChangeDetails.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChangeDetails.Location = new System.Drawing.Point(508, 108);
            this.lblChangeDetails.Name = "lblChangeDetails";
            this.lblChangeDetails.Size = new System.Drawing.Size(177, 33);
            this.lblChangeDetails.TabIndex = 26;
            this.lblChangeDetails.Text = "Change Details";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsername.Location = new System.Drawing.Point(49, 145);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(94, 23);
            this.lblUsername.TabIndex = 27;
            this.lblUsername.Text = "Username:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(49, 180);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(56, 23);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email:";
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(50, 216);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(48, 23);
            this.lblRole.TabIndex = 29;
            this.lblRole.Text = "Role:";
            // 
            // lblNewUsername
            // 
            this.lblNewUsername.AutoSize = true;
            this.lblNewUsername.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewUsername.Location = new System.Drawing.Point(435, 145);
            this.lblNewUsername.Name = "lblNewUsername";
            this.lblNewUsername.Size = new System.Drawing.Size(94, 23);
            this.lblNewUsername.TabIndex = 37;
            this.lblNewUsername.Text = "Username:";
            // 
            // tbNewUsername
            // 
            this.tbNewUsername.Location = new System.Drawing.Point(535, 149);
            this.tbNewUsername.Name = "tbNewUsername";
            this.tbNewUsername.Size = new System.Drawing.Size(136, 20);
            this.tbNewUsername.TabIndex = 38;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.Location = new System.Drawing.Point(435, 245);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(122, 23);
            this.lblOldPassword.TabIndex = 39;
            this.lblOldPassword.Text = "Old Password:";
            // 
            // tbOldPassword
            // 
            this.tbOldPassword.Location = new System.Drawing.Point(563, 248);
            this.tbOldPassword.Name = "tbOldPassword";
            this.tbOldPassword.PasswordChar = '*';
            this.tbOldPassword.Size = new System.Drawing.Size(136, 20);
            this.tbOldPassword.TabIndex = 40;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPassword.Location = new System.Drawing.Point(437, 284);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(130, 23);
            this.lblNewPassword.TabIndex = 41;
            this.lblNewPassword.Text = "New Password:";
            // 
            // tbNewPassword
            // 
            this.tbNewPassword.Location = new System.Drawing.Point(573, 288);
            this.tbNewPassword.Name = "tbNewPassword";
            this.tbNewPassword.PasswordChar = '*';
            this.tbNewPassword.Size = new System.Drawing.Size(136, 20);
            this.tbNewPassword.TabIndex = 42;
            // 
            // tbConfirmPassword
            // 
            this.tbConfirmPassword.Location = new System.Drawing.Point(600, 327);
            this.tbConfirmPassword.Name = "tbConfirmPassword";
            this.tbConfirmPassword.PasswordChar = '*';
            this.tbConfirmPassword.Size = new System.Drawing.Size(136, 20);
            this.tbConfirmPassword.TabIndex = 43;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirmPassword.Location = new System.Drawing.Point(437, 323);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(157, 23);
            this.lblConfirmPassword.TabIndex = 44;
            this.lblConfirmPassword.Text = "Confirm Password:";
            // 
            // btnConfirmPassword
            // 
            this.btnConfirmPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnConfirmPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirmPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmPassword.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmPassword.ForeColor = System.Drawing.Color.White;
            this.btnConfirmPassword.Location = new System.Drawing.Point(514, 373);
            this.btnConfirmPassword.Name = "btnConfirmPassword";
            this.btnConfirmPassword.Size = new System.Drawing.Size(139, 44);
            this.btnConfirmPassword.TabIndex = 47;
            this.btnConfirmPassword.Text = "Confirm Changes";
            this.btnConfirmPassword.UseVisualStyleBackColor = false;
            this.btnConfirmPassword.Click += new System.EventHandler(this.btnConfirmPassword_Click);
            // 
            // lblDisplayUsername
            // 
            this.lblDisplayUsername.AutoSize = true;
            this.lblDisplayUsername.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayUsername.Location = new System.Drawing.Point(149, 146);
            this.lblDisplayUsername.Name = "lblDisplayUsername";
            this.lblDisplayUsername.Size = new System.Drawing.Size(153, 23);
            this.lblDisplayUsername.TabIndex = 48;
            this.lblDisplayUsername.Text = "Display Username";
            // 
            // lblDisplayEmail
            // 
            this.lblDisplayEmail.AutoSize = true;
            this.lblDisplayEmail.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayEmail.Location = new System.Drawing.Point(111, 180);
            this.lblDisplayEmail.Name = "lblDisplayEmail";
            this.lblDisplayEmail.Size = new System.Drawing.Size(115, 23);
            this.lblDisplayEmail.TabIndex = 49;
            this.lblDisplayEmail.Text = "Display Email";
            // 
            // lblDisplayRole
            // 
            this.lblDisplayRole.AutoSize = true;
            this.lblDisplayRole.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayRole.Location = new System.Drawing.Point(104, 216);
            this.lblDisplayRole.Name = "lblDisplayRole";
            this.lblDisplayRole.Size = new System.Drawing.Size(108, 23);
            this.lblDisplayRole.TabIndex = 50;
            this.lblDisplayRole.Text = "Display Role";
            // 
            // btnConfirmUsername
            // 
            this.btnConfirmUsername.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnConfirmUsername.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirmUsername.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmUsername.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmUsername.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmUsername.ForeColor = System.Drawing.Color.White;
            this.btnConfirmUsername.Location = new System.Drawing.Point(514, 180);
            this.btnConfirmUsername.Name = "btnConfirmUsername";
            this.btnConfirmUsername.Size = new System.Drawing.Size(139, 44);
            this.btnConfirmUsername.TabIndex = 51;
            this.btnConfirmUsername.Text = "Confirm Changes";
            this.btnConfirmUsername.UseVisualStyleBackColor = false;
            this.btnConfirmUsername.Click += new System.EventHandler(this.btnConfirmUsername_Click);
            // 
            // lblDisplayQualLevel
            // 
            this.lblDisplayQualLevel.AutoSize = true;
            this.lblDisplayQualLevel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayQualLevel.Location = new System.Drawing.Point(211, 252);
            this.lblDisplayQualLevel.Name = "lblDisplayQualLevel";
            this.lblDisplayQualLevel.Size = new System.Drawing.Size(155, 23);
            this.lblDisplayQualLevel.TabIndex = 53;
            this.lblDisplayQualLevel.Text = "Display Qual Level";
            // 
            // lblQualificationLevel
            // 
            this.lblQualificationLevel.AutoSize = true;
            this.lblQualificationLevel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualificationLevel.Location = new System.Drawing.Point(49, 252);
            this.lblQualificationLevel.Name = "lblQualificationLevel";
            this.lblQualificationLevel.Size = new System.Drawing.Size(156, 23);
            this.lblQualificationLevel.TabIndex = 52;
            this.lblQualificationLevel.Text = "Qualification Level:";
            // 
            // lblResetSubjects
            // 
            this.lblResetSubjects.AutoSize = true;
            this.lblResetSubjects.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetSubjects.Location = new System.Drawing.Point(50, 373);
            this.lblResetSubjects.Name = "lblResetSubjects";
            this.lblResetSubjects.Size = new System.Drawing.Size(254, 19);
            this.lblResetSubjects.TabIndex = 55;
            this.lblResetSubjects.Text = "Would you like to reset your subjects?";
            // 
            // linkLblResetSubject
            // 
            this.linkLblResetSubject.AutoSize = true;
            this.linkLblResetSubject.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLblResetSubject.Location = new System.Drawing.Point(300, 374);
            this.linkLblResetSubject.Name = "linkLblResetSubject";
            this.linkLblResetSubject.Size = new System.Drawing.Size(71, 19);
            this.linkLblResetSubject.TabIndex = 54;
            this.linkLblResetSubject.TabStop = true;
            this.linkLblResetSubject.Text = "click here";
            this.linkLblResetSubject.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLblResetSubject_LinkClicked);
            // 
            // frmAccountInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblResetSubjects);
            this.Controls.Add(this.linkLblResetSubject);
            this.Controls.Add(this.lblDisplayQualLevel);
            this.Controls.Add(this.lblQualificationLevel);
            this.Controls.Add(this.btnConfirmUsername);
            this.Controls.Add(this.lblDisplayRole);
            this.Controls.Add(this.lblDisplayEmail);
            this.Controls.Add(this.lblDisplayUsername);
            this.Controls.Add(this.btnConfirmPassword);
            this.Controls.Add(this.lblConfirmPassword);
            this.Controls.Add(this.tbConfirmPassword);
            this.Controls.Add(this.tbNewPassword);
            this.Controls.Add(this.lblNewPassword);
            this.Controls.Add(this.tbOldPassword);
            this.Controls.Add(this.lblOldPassword);
            this.Controls.Add(this.tbNewUsername);
            this.Controls.Add(this.lblNewUsername);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblChangeDetails);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.lblAccountInformation);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogOut);
            this.Name = "frmAccountInformation";
            this.Text = "frmAccountInformation";
            this.Load += new System.EventHandler(this.frmAccountInformation_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblAccountInformation;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblChangeDetails;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblNewUsername;
        private System.Windows.Forms.TextBox tbNewUsername;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.TextBox tbOldPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox tbNewPassword;
        private System.Windows.Forms.TextBox tbConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Button btnConfirmPassword;
        private System.Windows.Forms.Label lblDisplayUsername;
        private System.Windows.Forms.Label lblDisplayEmail;
        private System.Windows.Forms.Label lblDisplayRole;
        private System.Windows.Forms.Button btnConfirmUsername;
        private System.Windows.Forms.Label lblDisplayQualLevel;
        private System.Windows.Forms.Label lblQualificationLevel;
        private System.Windows.Forms.Label lblResetSubjects;
        private System.Windows.Forms.LinkLabel linkLblResetSubject;
    }
}