using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDemo
{
    public partial class Form1 : Form
    {
        public string AppName { get; private set; } = "WinDemo Application";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connString = DataLayer.DB.ConnectionString;
            DataLayer.DB.ApplicationName = this.AppName;
            DataLayer.DB.ConnectionTimeout = 30;
            SqlConnection conn = DataLayer.DB.GetSqlConnection();
        }

        private void buttonGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var es = new DataLayer.Employees();
                var employee = es.GetEmployee(int.Parse(textBoxEID.Text));

                textBoxFName.Text = employee.FirstName;
                textBoxLName.Text = employee.LastName;
                textBoxDName.Text = employee.DepartmentName;
                labelDepartmentId.Text = employee.DepartmentId.ToString();

                DataLayer.ApplicatioLog.Add4($"Searched for user id: {textBoxEID.Text}");
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void buttonDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicatioLog.DeleteCommentsForApp(this.AppName);
            }
            catch (Exception)
            {
                //throw;
            }
        }

        private void linkLabelUpdateDepartmentName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // A search must first be performed
                if (textBoxEID.Text.Length > 0 && textBoxDName.Text.Length > 0)
                {
                    DataLayer.Employees employees = new DataLayer.Employees();
                    int departmentId = int.Parse(labelDepartmentId.Text);
                    employees.UpdateDepartmentName(departmentId, textBoxDName.Text);

                }
            }
            catch { }
        }
    }
}
