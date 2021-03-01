using System;
using System.Reflection;
using static System.Console;
using System.Linq; // to use OderByDescending
using System.Runtime.CompilerServices; // to use CompilerGeneratedAttribute
using Packt.Shared;


namespace WorkingWithReflection
{
    class Program
    {


        [Coder("Mark Price", "22 August 2019")]
        [Coder("Johnni Rusmussen", "13 September 2019")]
        public static void DoStuff()
        {
        }

        static void Main()
        {
            WriteLine("Assembly metadata:");
            Assembly assembly = Assembly.GetEntryAssembly();

            WriteLine($" Full name: {assembly.FullName}");
            WriteLine($" Location: {assembly.Location}");

            var attributes = assembly.GetCustomAttributes();

            WriteLine($" Attributes:");
            foreach (Attribute a in attributes)
            {
                WriteLine($" {a.GetType()}");
            }

            var version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();

            WriteLine($" Version : {version.InformationalVersion}");

            var company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();

            WriteLine($" Company: {company.Company}");

            WriteLine();
            WriteLine($"* Types:");
            Type[] types = assembly.GetTypes();

            foreach (Type type in types)
            {
                WriteLine();
                WriteLine($"Type: {type.FullName}");
                if (type.FullName.Contains("+<>"))
                {
                    continue;
                }
                MemberInfo[] members = type.GetMembers();

                foreach (MemberInfo member in members)
                {

                    WriteLine($" {member.MemberType}: {member.Name} ({member.DeclaringType.Name})");

                    var coders = member.GetCustomAttributes<CoderAttribute>().OrderByDescending(c => c.LastModified);

                    foreach (CoderAttribute coder in coders)
                    {
                        WriteLine($"-> Modified by {coder.Coder} on {coder.LastModified.ToShortDateString()}");
                    }
                };

            }

        }
    }
}
