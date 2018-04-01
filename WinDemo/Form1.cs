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
using DataLayer;

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
            try
            {
                string connString = DataLayer.DB.ConnectionString;
                DataLayer.DB.ApplicationName = this.AppName;
                DataLayer.DB.ConnectionTimeout = 3;
                SqlConnection conn = DataLayer.DB.GetSqlConnection();

                DataTable tableLog = DataLayer.ApplicatioLog.GetLog(this.AppName);
                dataGridViewAppLog.DataSource = tableLog;
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var es = new DataLayer.Employees();

                DataLayer.DB.EnableStatistics = true;
                var employee = es.GetEmployee(int.Parse(textBoxEID.Text));
                RefreshStatistics(DataLayer.DB.LastStatistics);
                DataLayer.DB.EnableStatistics = false;

                textBoxFName.Text = employee.FirstName;
                textBoxLName.Text = employee.LastName;
                textBoxDName.Text = employee.DepartmentName;
                labelDepartmentId.Text = employee.DepartmentId.ToString();
                labelOldName.Text = employee.DepartmentName;
                labelOldName.Visible = true;

                DataLayer.ApplicatioLog.Add4($"Searched for user id: {textBoxEID.Text}");

                DataTable tableLog = DataLayer.ApplicatioLog.GetLog(this.AppName);
                dataGridViewAppLog.DataSource = tableLog;
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception) { }
        }

        private void buttonDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicatioLog.DeleteCommentsForApp(this.AppName);

                DataTable tableLog = DataLayer.ApplicatioLog.GetLog(this.AppName);
                dataGridViewAppLog.DataSource = tableLog;
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception) { }
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
                    employees.UpdateDepartmentName(departmentId, textBoxDName.Text, labelOldName.Text);

                    buttonGetEmployee_Click(sender, null);
                }
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }
        }

        private void buttonUpdateLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = (DataTable)dataGridViewAppLog.DataSource;
                DataLayer.DB.EnableStatistics = true;
                DataTable tableRes = DataLayer.ApplicatioLog.UpdateLogChanges(table);
                RefreshStatistics(DataLayer.DB.LastStatistics);
                DataLayer.DB.EnableStatistics = false;
                dataGridViewAppLog.DataSource = tableRes;
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DBConcurrencyException cex)
            {
                MessageBox.Show(this, cex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }
        }

        private void RefreshStatistics(ConnectionStatistics connectionStatistics)
        {
            listViewStats.Items.Clear();
            foreach (string key in connectionStatistics.OriginalStats.Keys)
            {
                ListViewItem lvi = new ListViewItem(key);
                lvi.SubItems.Add(connectionStatistics.OriginalStats[key].ToString());
                listViewStats.Items.Add(lvi);
            }
        }

        private void dataGridViewAppLog_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
