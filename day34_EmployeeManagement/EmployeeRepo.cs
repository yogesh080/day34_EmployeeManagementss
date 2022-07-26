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

        public void UpdatingSalaryModel(SalaryUpdateModel salaryUpdatemodel)
        {
            int salary = 0;
            try
            {
                using (this.connection)
                {
                    SalaryDetailModel displayModel = new SalaryDetailModel();
                    SqlCommand cmd = new SqlCommand("updateEmployeeSalary", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@SalaryId", salaryUpdatemodel.SalaryId);
                    cmd.Parameters.AddWithValue("@Month", salaryUpdatemodel.Month);
                    cmd.Parameters.AddWithValue("@Salary", salaryUpdatemodel.EmployeeSalary);
                    cmd.Parameters.AddWithValue("@EmployeeID", salaryUpdatemodel.EmployeeId);

                    connection.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        while (dr.Read())
                        {
                            displayModel.EmployeeID = dr.GetInt32(0);
                            displayModel.EmployeeName = dr.GetString(1);
                            displayModel.Department = dr.GetString(2);
                            displayModel.Month = dr.GetString(3);
                            displayModel.EmployeeSalary = dr.GetInt32(4);
                            displayModel.SalaryID = dr.GetInt32(5);

                            Console.WriteLine($"EmployeeID: {displayModel.EmployeeID}\nEmployeeName: {displayModel.EmployeeName}\nSalaryID: {displayModel.SalaryID}\nEmployeeSalary: {displayModel.EmployeeSalary}");
                            salary = displayModel.EmployeeSalary;
                        }
                    }
                    else
                    {
                        Console.WriteLine("data not found");
                    }
                    dr.Close();
                    connection.Close();


                }

            }
            catch (Exception Ex)
            {

                throw new Exception(Ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }


    }
}