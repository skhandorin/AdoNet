﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Employees
    {
        public List<Employee> EmployeeList { get; set; }

        /// <summary>
        /// Returns an employee using a stored procedure
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployee(int employeeId)
        {
            var e = new Employee();

            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"GetEmployeeDetails";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var p1 = new SqlParameter("businessEntityID", System.Data.SqlDbType.Int)
                    {
                        Value = employeeId
                    };
                    cmd.Parameters.Add(p1);

                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (reader.Read())
                    {
                        e.Load(reader);
                    }
                }
            }

            return e;
        }

        /// <summary>
        /// Returns an employee using Inline SQL
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public Employee GetEmployeeDONOTCALL(int employeeId)
        {
            var e = new Employee();

            using(SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
select * 
  from HumanResources.Employee e
    join Person.Person p on p.BusinessEntityID = e.BusinessEntityID and p.PersonType = 'EM'
	join HumanResources.EmployeeDepartmentHistory eh on eh.BusinessEntityID = e.BusinessEntityID
	join HumanResources.Department d on d.DepartmentID = eh.DepartmentID
  where e.BusinessEntityID = {0}";
                    cmd.CommandText = string.Format(cmd.CommandText, employeeId.ToString());
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    if (reader.Read())
                    {
                        e.Load(reader);
                    }
                }
            }

            return e;
        }

        /// <summary>
        /// Update the name of a department given its ID
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="newName"></param>
        public void UpdateDepartmentName(int departmentId, string newName, string oldName = null)
        {
            using (SqlConnection conn = DB.GetSqlConnection())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"UpdateDepartmentName";
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    var p1 = new SqlParameter("id", System.Data.SqlDbType.Int);
                    p1.Value = departmentId;
                    cmd.Parameters.Add(p1);

                    var p2 = new SqlParameter("name", System.Data.SqlDbType.NVarChar, 100);
                    p2.Value = newName;
                    cmd.Parameters.Add(p2);

                    var p3 = new SqlParameter("oldname", System.Data.SqlDbType.NVarChar, 100);
                    p3.Value = oldName;
                    cmd.Parameters.Add(p3);

                    int res = cmd.ExecuteNonQuery();

                }
            }
        }
    }


    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }

        public void Load(SqlDataReader reader)
        {
            EmployeeId = Int32.Parse(reader["BusinessEntityId"].ToString());
            FirstName = reader["FirstName"].ToString();
            LastName = reader["LastName"].ToString();
            DepartmentId = Int32.Parse(reader["DepartmentId"].ToString());
            DepartmentName = reader["Name"].ToString();



        }
    }
}
