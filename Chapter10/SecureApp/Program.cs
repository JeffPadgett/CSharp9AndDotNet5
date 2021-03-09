using System;
using static System.Console;
using Packt.Shared;
using System.Threading;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security.Claims;

namespace SecureApp
{
    class Program
    {
        static void SecureFeature() //Example of how to allow specific users with authentication to access specific types of code. 
        {
            if (Thread.CurrentPrincipal == null)
            {
                throw new SecurityException("A user must be logged in to access this feature.");
            }

            if (!Thread.CurrentPrincipal.IsInRole("Admins"))
            {
                throw new SecurityException("User must be a member of Admins to access this feature.");
            }

            WriteLine("You have access to this secure feature.");
        }

        static void Main(string[] args)
        {
            Protector.Register("Alice", "Pa$$word", new[] {"Admins"});
            Protector.Register("Bob", "Pa$$word", new[] {"Sales", "TeamLeads"});
            Protector.Register("Eve", "Pa$$word");

            Write($"Enter your user name: ");
            string username = ReadLine();

            Write($"Enter your password: ");
            string password = ReadLine();

            Protector.LogIn(username, password);

            if (Thread.CurrentPrincipal == null)
            {
                WriteLine("Log in Failed.");
                return;
            }

            var p = Thread.CurrentPrincipal;

            WriteLine($"IsAuthenticated: {p.Identity.IsAuthenticated}");
            WriteLine($"AuthenticationType: {p.Identity.AuthenticationType}");
            WriteLine($"Name: {p.Identity.Name}");
            WriteLine($"IsInRole(Admins): {p.IsInRole("Admins")}");
            WriteLine($"IsInRole(Sales): {p.IsInRole("Sales")}");

            if (p is ClaimsPrincipal) //Claims principle have multiple identies, for example, a cop would see your face and your driverslicense. That's why it's usful.
            {
                WriteLine($"{p.Identity.Name} has the following claims: ");
            }

            foreach (Claim claim in (p as ClaimsPrincipal).Claims)
            {
                WriteLine($"{claim.Type}: {claim.Value}");
            }
            
            try
            {
                SecureFeature();
            }
            catch(System.Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }
        }
    }
}
