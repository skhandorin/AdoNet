using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPDemo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LabelError.Text = "";

                try
                {
                    string connString = DataLayer.DB.ConnectionString;
                    DataLayer.DB.ApplicationName = "ASPDemo Application";
                    DataLayer.DB.ConnectionTimeout = 5;
                    SqlConnection conn = DataLayer.DB.GetSqlConnection();

                    GridViewAppLog.DataSource = DataLayer.ApplicatioLog.GetLog("ASPDemo Application");
                    GridViewAppLog.DataBind();
                }
                catch (SqlException sqlex)
                {
                    LabelError.Text = sqlex.Message;
                }
            }
        }

        protected void LinkButtonGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                var es = new DataLayer.Employees();
                var employee = es.GetEmployee(int.Parse(TextBoxEID.Text));

                TextBoxFName.Text = employee.FirstName;
                TextBoxLName.Text = employee.LastName;
                TextBoxDName.Text = employee.DepartmentName;
                LabelDepartmentId.Text = employee.DepartmentId.ToString();

                DataLayer.ApplicatioLog.Add4("Searched for user id: " + TextBoxEID.Text);

                GridViewAppLog.DataSource = DataLayer.ApplicatioLog.GetLog("ASPDemo Application");
                GridViewAppLog.DataBind();
            }
            catch (SqlException sqlex)
            {
                LabelError.Text = sqlex.Message;
            }
            catch (Exception)
            {
                //throw;
            }
        }

        protected void LinkButtonUpdateDepartmentName_Click(object sender, EventArgs e)
        {
            try
            {
                // A search must first be performed
                if (TextBoxEID.Text.Length > 0 && TextBoxDName.Text.Length > 0)
                {
                    DataLayer.Employees employees = new DataLayer.Employees();
                    int departmentId = int.Parse(LabelDepartmentId.Text);
                    employees.UpdateDepartmentName(departmentId, TextBoxDName.Text);

                }
            }
            catch (SqlException sqlex)
            {
                LabelError.Text = sqlex.Message;
            }
            catch { }
        }

        protected void LinkButtonDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicatioLog.DeleteCommentsForApp("ASPDemo Application");
            }
            catch (SqlException sqlex)
            {
                LabelError.Text = sqlex.Message;
            }
            catch { }
        }
    }
}