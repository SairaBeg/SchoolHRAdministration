using System;
using HRAdministrationAPI;
using System.Linq;

namespace SchoolHRAdministration
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal totalSalaries = 0;
            List<IEmployee> employees = new List<IEmployee>();
            SeedData(employees);
            //    foreach(IEmployee employee in employees)
            //    {
            //        totalSalaries += employee.Salary;
            //    }
            //    Console.WriteLine(totalSalaries);
            Console.WriteLine( employees.Sum(e=> e.Salary));
        }
        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = new Teacher
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Fisher",
                Salary = 40000
            };
            employees.Add(teacher1);

            IEmployee teacher2 = new Teacher
            {
                Id = 2,
                FirstName = "Jenny",
                LastName = "Thomas",
                Salary = 40000
            };
            employees.Add(teacher2);

            IEmployee aprincipal = new AssistantPrincipal
            {
                Id = 3,
                FirstName = "Delvin",
                LastName = "Brown",
                Salary = 70000
            };
            employees.Add(aprincipal);


            IEmployee principal = new Principal
            {
                Id = 4,
                FirstName = "Brenda",
                LastName = "Mullins",
                Salary = 80000
            };
            employees.Add(principal);
        }
    }

public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary+  (base.Salary *0.02m); }
    }

    public class AssistantPrincipal : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
    }
    public class Principal : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
    }
}