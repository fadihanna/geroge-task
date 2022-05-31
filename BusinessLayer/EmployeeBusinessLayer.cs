using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> EmployeeList
        {
            get
            {

                string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
               
                List<Employee> employees = new List<Employee>();

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("Select* From Employee;", con); 
                    cmd.CommandType = CommandType.Text;
                    con.Open(); // open connection
                    SqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read()) // read rows from database and convert to employee objects
                    {
                        Employee emp = new Employee();
                        emp.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                        emp.Name = rdr["Name"].ToString();
                        emp.Gender = rdr["Gender"].ToString();
                        emp.Title = rdr["Title"].ToString();
                        emp.Notes = rdr["Notes"].ToString();
                        emp.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
                        emp.DepartmentID = Convert.ToInt32(rdr["DepartmentID"]);

                        employees.Add(emp); // add employee object to list
                    }
                }
                return employees; // return list
            }
        }

        public void AddEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Insert into Employee (Name,Title,Gender,BirthDate,Notes,DepartmentID) Values (@Name,@Title,@Gender,@BirthDate,@Notes,@DepartmentID);", con);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramTitle = new SqlParameter();
                paramTitle.ParameterName = "@Title";
                paramTitle.Value = employee.Title;
                cmd.Parameters.Add(paramTitle);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramBirthDate = new SqlParameter();
                paramBirthDate.ParameterName = "@BirthDate";
                paramBirthDate.Value = employee.BirthDate;
                cmd.Parameters.Add(paramBirthDate);

                SqlParameter paramNotes = new SqlParameter();
                paramNotes.ParameterName = "@Notes";
                paramNotes.Value = employee.Notes;
                cmd.Parameters.Add(paramNotes);

                SqlParameter paramDepartmentID = new SqlParameter();
                paramDepartmentID.ParameterName = "@DepartmentID";
                paramDepartmentID.Value = employee.DepartmentID;
                cmd.Parameters.Add(paramDepartmentID);

                con.Open();
                cmd.ExecuteNonQuery();

            }

        }

        public void DeleteEmployee(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Delete From Employee Where EmployeeID = @EmployeeID", con);
                SqlParameter paramEmployeeID = new SqlParameter();
                paramEmployeeID.ParameterName = "@EmployeeID";
                paramEmployeeID.Value = id;
                cmd.Parameters.Add(paramEmployeeID);
                
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditEmployee(Employee employee)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Update Employee Set Name = @Name, Title=@Title , BirthDate = @BirthDate, Notes = @Notes, DepartmentID = @DepartmentID Where EmployeeID = @EmployeeID", con);

                SqlParameter paramEmployeeID = new SqlParameter();
                paramEmployeeID.ParameterName = "@EmployeeID";
                paramEmployeeID.Value = employee.EmployeeID;
                cmd.Parameters.Add(paramEmployeeID);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramTitle = new SqlParameter();
                paramTitle.ParameterName = "@Title";
                paramTitle.Value = employee.Title;
                cmd.Parameters.Add(paramTitle);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramBirthDate = new SqlParameter();
                paramBirthDate.ParameterName = "@BirthDate";
                paramBirthDate.Value = employee.BirthDate;
                cmd.Parameters.Add(paramBirthDate);

                SqlParameter paramNotes = new SqlParameter();
                paramNotes.ParameterName = "@Notes";
                paramNotes.Value = employee.Notes;
                cmd.Parameters.Add(paramNotes);

                SqlParameter paramDepartmentID = new SqlParameter();
                paramDepartmentID.ParameterName = "@DepartmentID";
                paramDepartmentID.Value = employee.DepartmentID;
                cmd.Parameters.Add(paramDepartmentID);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    
        public List <Employee> OrderByEmployeeName()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
            List<Employee> employees = new List<Employee>();
            
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("Select* From Employee Order by Name ASC;", con);
                cmd.CommandType = CommandType.Text;
                con.Open(); // open connection
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read()) // read rows from database and convert to employee objects then order by asc
                {
                    Employee emp = new Employee();
                    emp.EmployeeID = Convert.ToInt32(rdr["EmployeeID"]);
                    emp.Name = rdr["Name"].ToString();
                    emp.Gender = rdr["Gender"].ToString();
                    emp.Title = rdr["Title"].ToString();
                    emp.Notes = rdr["Notes"].ToString();
                    emp.BirthDate = Convert.ToDateTime(rdr["BirthDate"]);
                    emp.DepartmentID = Convert.ToInt32(rdr["DepartmentID"]);

                    employees.Add(emp);
                }
                    return employees;
            }

                // var name = from n in employeeBusinessLayer.EmployeeList orderby n.Name ascending select n;

            }
    

    
    }
}
