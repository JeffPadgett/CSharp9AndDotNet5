using static System.Console;
using WiredBrainCoffee.StorageApp.Repositories;
using WiredBrainCoffee.StorageApp.Entities;
using System;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericRepository<Employee> empRepo = new();
            AddEmployees(empRepo);
            GetEmployeeById(empRepo);

            GenericRepository<Organization> orgRepo = new();
            AddOrganizations(orgRepo);

            ReadLine();
        }

        private static void GetEmployeeById(GenericRepository<Employee> empRepo)
        {
            var emp = empRepo.GetById(2);
            Console.WriteLine($"Employee with Id 2: {emp}");
        }

        private static void AddEmployees(GenericRepository<Employee> empRepo)
        {
            empRepo.Add(new Employee { FirstName = "Jessie" });
            empRepo.Add(new Employee { FirstName = "Anna" });
            empRepo.Add(new Employee { FirstName = "Thomas" });
            empRepo.Save();
        }

        private static void AddOrganizations(GenericRepository<Organization> orgRepo)
        {
            orgRepo.Add(new Organization { Name = "pluralsight" });
            orgRepo.Add(new Organization { Name = "CIT bank" });
            orgRepo.Add(new Organization { Name = "Brightway" });
            orgRepo.Save();
        }
    }
}
