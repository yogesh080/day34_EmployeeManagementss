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

        
    }
}