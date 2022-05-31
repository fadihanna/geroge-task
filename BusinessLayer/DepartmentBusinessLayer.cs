using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
 

namespace BusinessLayer
{
    public class DepartmentBusinessLayer
    {      
        public List<Department> DepartmentList
        {
           get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
                List<Department> departments = new List<Department>();
                 
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select* From Department;",con);
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read()) // READ COLUMNS FROM DATABASE
                    {
                        Department department = new Department();  
                        department.DepartmentID = Convert.ToInt32(rdr["DepartmentID"]);
                        department.DepartmentName = Convert.ToString(rdr["DepartmentName"]);
                        departments.Add(department);
                        
                    }
                    return departments;
                }

                   
             }
        
       }

        public void AddDepartment(Department department)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into Department (DepartmentName) Values (@DepartmentName);", con);

                SqlParameter paramDepartmentName = new SqlParameter();
                paramDepartmentName.ParameterName = "@DepartmentName";
                paramDepartmentName.Value = department.DepartmentName;
                cmd.Parameters.Add(paramDepartmentName);

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }
    
        public void DeleteDepartment(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete From Department Where DepartmentID = @DepartmentID", con);
                SqlParameter paramDepartmentID = new SqlParameter();
                paramDepartmentID.ParameterName = "@DepartmentID";
                paramDepartmentID.Value = id;
                cmd.Parameters.Add(paramDepartmentID);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditDepartment(Department department)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update Department Set DepartmentName = @DepartmentName Where DepartmentID = @DepartmentID", con);

                SqlParameter paramDepartmentID = new SqlParameter();
                paramDepartmentID.ParameterName = "@DepartmentID";
                paramDepartmentID.Value = department.DepartmentID;
                cmd.Parameters.Add(paramDepartmentID);

                SqlParameter paramDepartmentName = new SqlParameter();
                paramDepartmentName.ParameterName = "@DepartmentName";
                paramDepartmentName.Value = department.DepartmentName;
                cmd.Parameters.Add(paramDepartmentName);

             
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
       
    }
    
    }


