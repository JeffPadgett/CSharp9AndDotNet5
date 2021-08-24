using static System.Console;
using WiredBrainCoffee.StorageApp.Repositories;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Data;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlRepository<Employee> empRepo = new(new StorageAppDbContext());
            AddEmployees(empRepo);
            GetEmployeeById(empRepo);

            ListRepository<Organization> orgRepo = new();
            AddOrganizations(orgRepo);

            ReadLine();
        }

        private static void GetEmployeeById(IRepository<Employee> empRepo)
        {
            var emp = empRepo.GetById(2);
            WriteLine($"Employee with Id 2: {emp}");
        }

        private static void AddEmployees(IRepository<Employee> empRepo)
        {
            empRepo.Add(new Employee { FirstName = "Jessie" });
            empRepo.Add(new Employee { FirstName = "Anna" });
            empRepo.Add(new Employee { FirstName = "Thomas" });
            empRepo.Save();
        }

        private static void AddOrganizations(IRepository<Organization> orgRepo)
        {
            orgRepo.Add(new Organization { Name = "pluralsight" });
            orgRepo.Add(new Organization { Name = "CIT bank" });
            orgRepo.Add(new Organization { Name = "Brightway" });
            orgRepo.Save();
        }
    }
}
