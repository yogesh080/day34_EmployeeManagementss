using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using day34_EmployeeManagement;

namespace day34_EmployeeManagement
{
    public class EmployeeRepo
    {

        //static as connection will be made only once in application
        List<SalaryDetailModel> employeeDetailsList = new List<SalaryDetailModel>();
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog =CompanyDB; Integrated Security = True;";
        SqlConnection connection = new SqlConnection(connectionString);
        public void GetAllemployee()
        {

            try
            {
                using (this.connection)
                {
                    string query = "select * from Employeedetail";
                    SqlCommand sqlCommand = new SqlCommand(query, this.connection);
                    this.connection.Open();
                    SqlDataReader dr = sqlCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            SalaryDetailModel employeeModel = new SalaryDetailModel();
                            employeeModel.EmployeeID = dr.GetInt32(0);
                            employeeModel.EmployeeName = dr.GetString(1);
                            employeeModel.Department = dr.GetString(2);
                            employeeModel.Month = dr.GetString(3);
                            employeeModel.EmployeeSalary = dr.GetInt32(4);
                            employeeModel.SalaryID = dr.GetInt32(5);



                            //display retrieved record
                            employeeDetailsList.Add(employeeModel);


                        }
                        foreach (var employee in employeeDetailsList)
                        {
                            Console.WriteLine($"EmployeeID: {employee.EmployeeID}\nEmployeeName: {employee.EmployeeName}\nDepartment: {employee.Department}\nMonth: {employee.Month}\nEmployeeSalary: {employee.EmployeeSalary}\nSalaryID: {employee.SalaryID}");

                        }

                    }
                    else
                    {
                        throw new Exception("No data found");
                    }
                    dr.Close();
                    this.connection.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        

    }
}