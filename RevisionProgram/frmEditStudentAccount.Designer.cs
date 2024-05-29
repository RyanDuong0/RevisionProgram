namespace RevisionProgram
{
    partial class frmEditStudentAccount
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
            this.lblEditStudentAccount = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.lblDisplayUsername = new System.Windows.Forms.Label();
            this.lblQualificationLevel = new System.Windows.Forms.Label();
            this.lblNewUsername = new System.Windows.Forms.Label();
            this.tbNewUsername = new System.Windows.Forms.TextBox();
            this.lblResetPassword = new System.Windows.Forms.Label();
            this.cbNewQualLevel = new System.Windows.Forms.ComboBox();
            this.btnConfirmChanges = new System.Windows.Forms.Button();
            this.btnResetPass = new System.Windows.Forms.Button();
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblEditStudentAccount
            // 
            this.lblEditStudentAccount.AutoSize = true;
            this.lblEditStudentAccount.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditStudentAccount.Location = new System.Drawing.Point(215, 4);
            this.lblEditStudentAccount.Name = "lblEditStudentAccount";
            this.lblEditStudentAccount.Size = new System.Drawing.Size(342, 45);
            this.lblEditStudentAccount.TabIndex = 27;
            this.lblEditStudentAccount.Text = "Edit Student Account";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBack.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(584, 12);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(99, 31);
            this.btnBack.TabIndex = 32;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
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
            this.btnLogOut.TabIndex = 31;
            this.btnLogOut.Text = "Logout";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // lblDisplayUsername
            // 
            this.lblDisplayUsername.AutoSize = true;
            this.lblDisplayUsername.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayUsername.Location = new System.Drawing.Point(308, 48);
            this.lblDisplayUsername.Name = "lblDisplayUsername";
            this.lblDisplayUsername.Size = new System.Drawing.Size(153, 23);
            this.lblDisplayUsername.TabIndex = 49;
            this.lblDisplayUsername.Text = "Display Username";
            // 
            // lblQualificationLevel
            // 
            this.lblQualificationLevel.AutoSize = true;
            this.lblQualificationLevel.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQualificationLevel.Location = new System.Drawing.Point(257, 176);
            this.lblQualificationLevel.Name = "lblQualificationLevel";
            this.lblQualificationLevel.Size = new System.Drawing.Size(156, 23);
            this.lblQualificationLevel.TabIndex = 55;
            this.lblQualificationLevel.Text = "Qualification Level:";
            // 
            // lblNewUsername
            // 
            this.lblNewUsername.AutoSize = true;
            this.lblNewUsername.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewUsername.Location = new System.Drawing.Point(257, 138);
            this.lblNewUsername.Name = "lblNewUsername";
            this.lblNewUsername.Size = new System.Drawing.Size(94, 23);
            this.lblNewUsername.TabIndex = 56;
            this.lblNewUsername.Text = "Username:";
            // 
            // tbNewUsername
            // 
            this.tbNewUsername.Location = new System.Drawing.Point(357, 142);
            this.tbNewUsername.Name = "tbNewUsername";
            this.tbNewUsername.Size = new System.Drawing.Size(153, 20);
            this.tbNewUsername.TabIndex = 57;
            // 
            // lblResetPassword
            // 
            this.lblResetPassword.AutoSize = true;
            this.lblResetPassword.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResetPassword.Location = new System.Drawing.Point(257, 311);
            this.lblResetPassword.Name = "lblResetPassword";
            this.lblResetPassword.Size = new System.Drawing.Size(137, 23);
            this.lblResetPassword.TabIndex = 59;
            this.lblResetPassword.Text = "Reset Password:";
            this.lblResetPassword.Click += new System.EventHandler(this.lblResetPassword_Click);
            // 
            // cbNewQualLevel
            // 
            this.cbNewQualLevel.FormattingEnabled = true;
            this.cbNewQualLevel.Location = new System.Drawing.Point(420, 177);
            this.cbNewQualLevel.Name = "cbNewQualLevel";
            this.cbNewQualLevel.Size = new System.Drawing.Size(137, 21);
            this.cbNewQualLevel.TabIndex = 60;
            // 
            // btnConfirmChanges
            // 
            this.btnConfirmChanges.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnConfirmChanges.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnConfirmChanges.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmChanges.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnConfirmChanges.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirmChanges.ForeColor = System.Drawing.Color.White;
            this.btnConfirmChanges.Location = new System.Drawing.Point(324, 221);
            this.btnConfirmChanges.Name = "btnConfirmChanges";
            this.btnConfirmChanges.Size = new System.Drawing.Size(139, 44);
            this.btnConfirmChanges.TabIndex = 61;
            this.btnConfirmChanges.Text = "Confirm Changes";
            this.btnConfirmChanges.UseVisualStyleBackColor = false;
            this.btnConfirmChanges.Click += new System.EventHandler(this.btnConfirmChanges_Click);
            // 
            // btnResetPass
            // 
            this.btnResetPass.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(91)))), ((int)(((byte)(246)))));
            this.btnResetPass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnResetPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetPass.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnResetPass.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetPass.ForeColor = System.Drawing.Color.White;
            this.btnResetPass.Location = new System.Drawing.Point(404, 311);
            this.btnResetPass.Name = "btnResetPass";
            this.btnResetPass.Size = new System.Drawing.Size(139, 27);
            this.btnResetPass.TabIndex = 62;
            this.btnResetPass.Text = "Reset";
            this.btnResetPass.UseVisualStyleBackColor = false;
            this.btnResetPass.Click += new System.EventHandler(this.btnResetPass_Click);
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedUser.Location = new System.Drawing.Point(344, 69);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(77, 13);
            this.lblSelectedUser.TabIndex = 63;
            this.lblSelectedUser.Text = "(Selected user)";
            // 
            // frmEditStudentAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(244)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblSelectedUser);
            this.Controls.Add(this.btnResetPass);
            this.Controls.Add(this.btnConfirmChanges);
            this.Controls.Add(this.cbNewQualLevel);
            this.Controls.Add(this.lblResetPassword);
            this.Controls.Add(this.tbNewUsername);
            this.Controls.Add(this.lblNewUsername);
            this.Controls.Add(this.lblQualificationLevel);
            this.Controls.Add(this.lblDisplayUsername);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogOut);
            this.Controls.Add(this.lblEditStudentAccount);
            this.Name = "frmEditStudentAccount";
            this.Text = "frmEditStudentAccount";
            this.Load += new System.EventHandler(this.frmEditStudentAccount_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEditStudentAccount;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Label lblDisplayUsername;
        private System.Windows.Forms.Label lblQualificationLevel;
        private System.Windows.Forms.Label lblNewUsername;
        private System.Windows.Forms.TextBox tbNewUsername;
        private System.Windows.Forms.Label lblResetPassword;
        private System.Windows.Forms.ComboBox cbNewQualLevel;
        private System.Windows.Forms.Button btnConfirmChanges;
        private System.Windows.Forms.Button btnResetPass;
        private System.Windows.Forms.Label lblSelectedUser;
    }
}