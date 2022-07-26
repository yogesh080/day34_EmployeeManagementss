namespace day34_EmployeeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRepo employeeRepository = new EmployeeRepo();
            employeeRepository.GetAllemployee();
        }
    }
}