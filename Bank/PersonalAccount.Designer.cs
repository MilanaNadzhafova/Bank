namespace Bank
{
    partial class PersonalAccount
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnFind = new System.Windows.Forms.Button();
            this.TxtForFind = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.RichMyCount = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.RichMyHistory = new System.Windows.Forms.RichTextBox();
            this.LabPlaceOfBirth = new System.Windows.Forms.Label();
            this.LabDataOfBirth = new System.Windows.Forms.Label();
            this.LabEmail = new System.Windows.Forms.Label();
            this.LabPhone = new System.Windows.Forms.Label();
            this.LabAdress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Head = new System.Windows.Forms.Label();
            this.picClose = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.LabPlaceOfBirth);
            this.panel1.Controls.Add(this.LabDataOfBirth);
            this.panel1.Controls.Add(this.LabEmail);
            this.panel1.Controls.Add(this.LabPhone);
            this.panel1.Controls.Add(this.LabAdress);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Head);
            this.panel1.Controls.Add(this.picClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Calibri", 16.25F, System.Drawing.FontStyle.Bold);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 644);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(155)))), ((int)(((byte)(213)))));
            this.panel2.Controls.Add(this.BtnFind);
            this.panel2.Controls.Add(this.TxtForFind);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.RichMyCount);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.RichMyHistory);
            this.panel2.Location = new System.Drawing.Point(46, 344);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(643, 273);
            this.panel2.TabIndex = 31;
            // 
            // BtnFind
            // 
            this.BtnFind.BackColor = System.Drawing.Color.White;
            this.BtnFind.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BtnFind.Location = new System.Drawing.Point(252, 225);
            this.BtnFind.Name = "BtnFind";
            this.BtnFind.Size = new System.Drawing.Size(160, 34);
            this.BtnFind.TabIndex = 37;
            this.BtnFind.Text = "Найти";
            this.BtnFind.UseVisualStyleBackColor = false;
            this.BtnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // TxtForFind
            // 
            this.TxtForFind.Location = new System.Drawing.Point(38, 225);
            this.TxtForFind.Name = "TxtForFind";
            this.TxtForFind.Size = new System.Drawing.Size(198, 34);
            this.TxtForFind.TabIndex = 36;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(504, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 24);
            this.label8.TabIndex = 35;
            this.label8.Text = "Счет";
            // 
            // RichMyCount
            // 
            this.RichMyCount.Cursor = System.Windows.Forms.Cursors.Default;
            this.RichMyCount.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RichMyCount.Location = new System.Drawing.Point(432, 85);
            this.RichMyCount.Name = "RichMyCount";
            this.RichMyCount.ReadOnly = true;
            this.RichMyCount.Size = new System.Drawing.Size(182, 120);
            this.RichMyCount.TabIndex = 34;
            this.RichMyCount.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.label7.Location = new System.Drawing.Point(281, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 26);
            this.label7.TabIndex = 33;
            this.label7.Text = "Мои счета";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(167, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 24);
            this.label6.TabIndex = 32;
            this.label6.Text = "История";
            // 
            // RichMyHistory
            // 
            this.RichMyHistory.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.RichMyHistory.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RichMyHistory.Location = new System.Drawing.Point(38, 85);
            this.RichMyHistory.Name = "RichMyHistory";
            this.RichMyHistory.ReadOnly = true;
            this.RichMyHistory.Size = new System.Drawing.Size(374, 120);
            this.RichMyHistory.TabIndex = 0;
            this.RichMyHistory.Text = "";
            // 
            // LabPlaceOfBirth
            // 
            this.LabPlaceOfBirth.AutoSize = true;
            this.LabPlaceOfBirth.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.LabPlaceOfBirth.Location = new System.Drawing.Point(228, 286);
            this.LabPlaceOfBirth.Name = "LabPlaceOfBirth";
            this.LabPlaceOfBirth.Size = new System.Drawing.Size(155, 26);
            this.LabPlaceOfBirth.TabIndex = 30;
            this.LabPlaceOfBirth.Text = "Дата рождения:";
            // 
            // LabDataOfBirth
            // 
            this.LabDataOfBirth.AutoSize = true;
            this.LabDataOfBirth.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.LabDataOfBirth.Location = new System.Drawing.Point(228, 237);
            this.LabDataOfBirth.Name = "LabDataOfBirth";
            this.LabDataOfBirth.Size = new System.Drawing.Size(155, 26);
            this.LabDataOfBirth.TabIndex = 29;
            this.LabDataOfBirth.Text = "Дата рождения:";
            // 
            // LabEmail
            // 
            this.LabEmail.AutoSize = true;
            this.LabEmail.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.LabEmail.Location = new System.Drawing.Point(228, 185);
            this.LabEmail.Name = "LabEmail";
            this.LabEmail.Size = new System.Drawing.Size(96, 26);
            this.LabEmail.TabIndex = 28;
            this.LabEmail.Text = "Эл.почта:";
            // 
            // LabPhone
            // 
            this.LabPhone.AutoSize = true;
            this.LabPhone.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.LabPhone.Location = new System.Drawing.Point(228, 137);
            this.LabPhone.Name = "LabPhone";
            this.LabPhone.Size = new System.Drawing.Size(92, 26);
            this.LabPhone.TabIndex = 27;
            this.LabPhone.Text = "Телефон:";
            // 
            // LabAdress
            // 
            this.LabAdress.AutoSize = true;
            this.LabAdress.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.LabAdress.Location = new System.Drawing.Point(228, 88);
            this.LabAdress.Name = "LabAdress";
            this.LabAdress.Size = new System.Drawing.Size(72, 26);
            this.LabAdress.TabIndex = 26;
            this.LabAdress.Text = "Адрес:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.label5.Location = new System.Drawing.Point(41, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 26);
            this.label5.TabIndex = 25;
            this.label5.Text = "Место рождения:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.label4.Location = new System.Drawing.Point(41, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(155, 26);
            this.label4.TabIndex = 24;
            this.label4.Text = "Дата рождения:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.label3.Location = new System.Drawing.Point(41, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 26);
            this.label3.TabIndex = 23;
            this.label3.Text = "Эл.почта:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.label2.Location = new System.Drawing.Point(41, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 26);
            this.label2.TabIndex = 22;
            this.label2.Text = "Телефон:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.25F);
            this.label1.Location = new System.Drawing.Point(41, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 26);
            this.label1.TabIndex = 21;
            this.label1.Text = "Адрес:";
            // 
            // Head
            // 
            this.Head.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Head.Location = new System.Drawing.Point(74, 12);
            this.Head.Name = "Head";
            this.Head.Size = new System.Drawing.Size(565, 39);
            this.Head.TabIndex = 20;
            this.Head.Text = "Шевченко Артём Михайлович";
            this.Head.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picClose
            // 
            this.picClose.BackgroundImage = global::Bank.Properties.Resources.Close;
            this.picClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picClose.Location = new System.Drawing.Point(11, 12);
            this.picClose.Name = "picClose";
            this.picClose.Size = new System.Drawing.Size(34, 39);
            this.picClose.TabIndex = 19;
            this.picClose.TabStop = false;
            this.picClose.Click += new System.EventHandler(this.picClose_Click);
            // 
            // PersonalAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 644);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PersonalAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PersonalAccount";
            this.Load += new System.EventHandler(this.PersonalAccount_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picClose;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Head;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox RichMyHistory;
        private System.Windows.Forms.Label LabPlaceOfBirth;
        private System.Windows.Forms.Label LabDataOfBirth;
        private System.Windows.Forms.Label LabEmail;
        private System.Windows.Forms.Label LabPhone;
        private System.Windows.Forms.Label LabAdress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnFind;
        private System.Windows.Forms.TextBox TxtForFind;
        private System.Windows.Forms.RichTextBox RichMyCount;
    }
}