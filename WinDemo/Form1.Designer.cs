namespace WinDemo
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxEID = new System.Windows.Forms.TextBox();
            this.buttonGetEmployee = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFName = new System.Windows.Forms.TextBox();
            this.textBoxLName = new System.Windows.Forms.TextBox();
            this.textBoxDName = new System.Windows.Forms.TextBox();
            this.buttonDeleteLog = new System.Windows.Forms.Button();
            this.linkLabelUpdateDepartmentName = new System.Windows.Forms.LinkLabel();
            this.labelDepartmentId = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter Employee ID:";
            // 
            // textBoxEID
            // 
            this.textBoxEID.Location = new System.Drawing.Point(118, 13);
            this.textBoxEID.Name = "textBoxEID";
            this.textBoxEID.Size = new System.Drawing.Size(100, 20);
            this.textBoxEID.TabIndex = 1;
            // 
            // buttonGetEmployee
            // 
            this.buttonGetEmployee.Location = new System.Drawing.Point(225, 9);
            this.buttonGetEmployee.Name = "buttonGetEmployee";
            this.buttonGetEmployee.Size = new System.Drawing.Size(36, 23);
            this.buttonGetEmployee.TabIndex = 2;
            this.buttonGetEmployee.Text = "GO";
            this.buttonGetEmployee.UseVisualStyleBackColor = true;
            this.buttonGetEmployee.Click += new System.EventHandler(this.buttonGetEmployee_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "First Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Last Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Department:";
            // 
            // textBoxFName
            // 
            this.textBoxFName.Location = new System.Drawing.Point(118, 62);
            this.textBoxFName.Name = "textBoxFName";
            this.textBoxFName.Size = new System.Drawing.Size(100, 20);
            this.textBoxFName.TabIndex = 3;
            // 
            // textBoxLName
            // 
            this.textBoxLName.Location = new System.Drawing.Point(118, 88);
            this.textBoxLName.Name = "textBoxLName";
            this.textBoxLName.Size = new System.Drawing.Size(100, 20);
            this.textBoxLName.TabIndex = 4;
            // 
            // textBoxDName
            // 
            this.textBoxDName.Location = new System.Drawing.Point(118, 113);
            this.textBoxDName.Name = "textBoxDName";
            this.textBoxDName.Size = new System.Drawing.Size(100, 20);
            this.textBoxDName.TabIndex = 5;
            // 
            // buttonDeleteLog
            // 
            this.buttonDeleteLog.Location = new System.Drawing.Point(15, 229);
            this.buttonDeleteLog.Name = "buttonDeleteLog";
            this.buttonDeleteLog.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteLog.TabIndex = 6;
            this.buttonDeleteLog.Text = "Delete Log";
            this.buttonDeleteLog.UseVisualStyleBackColor = true;
            this.buttonDeleteLog.Click += new System.EventHandler(this.buttonDeleteLog_Click);
            // 
            // linkLabelUpdateDepartmentName
            // 
            this.linkLabelUpdateDepartmentName.AutoSize = true;
            this.linkLabelUpdateDepartmentName.Location = new System.Drawing.Point(225, 116);
            this.linkLabelUpdateDepartmentName.Name = "linkLabelUpdateDepartmentName";
            this.linkLabelUpdateDepartmentName.Size = new System.Drawing.Size(42, 13);
            this.linkLabelUpdateDepartmentName.TabIndex = 7;
            this.linkLabelUpdateDepartmentName.TabStop = true;
            this.linkLabelUpdateDepartmentName.Text = "Update";
            this.linkLabelUpdateDepartmentName.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelUpdateDepartmentName_LinkClicked);
            // 
            // labelDepartmentId
            // 
            this.labelDepartmentId.AutoSize = true;
            this.labelDepartmentId.Location = new System.Drawing.Point(12, 139);
            this.labelDepartmentId.Name = "labelDepartmentId";
            this.labelDepartmentId.Size = new System.Drawing.Size(13, 13);
            this.labelDepartmentId.TabIndex = 8;
            this.labelDepartmentId.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 264);
            this.Controls.Add(this.labelDepartmentId);
            this.Controls.Add(this.linkLabelUpdateDepartmentName);
            this.Controls.Add(this.buttonDeleteLog);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonGetEmployee);
            this.Controls.Add(this.textBoxDName);
            this.Controls.Add(this.textBoxLName);
            this.Controls.Add(this.textBoxFName);
            this.Controls.Add(this.textBoxEID);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "WinDemo Application";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxEID;
        private System.Windows.Forms.Button buttonGetEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFName;
        private System.Windows.Forms.TextBox textBoxLName;
        private System.Windows.Forms.TextBox textBoxDName;
        private System.Windows.Forms.Button buttonDeleteLog;
        private System.Windows.Forms.LinkLabel linkLabelUpdateDepartmentName;
        private System.Windows.Forms.Label labelDepartmentId;
    }
}

