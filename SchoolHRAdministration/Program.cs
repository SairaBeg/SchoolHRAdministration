using System;
using HRAdministrationAPI;
using System.Linq;
using static SchoolHRAdministration.Program;

namespace SchoolHRAdministration
{
    public class Program
    {
        public enum EmployeeType
        {
            Teacher,
            AssistantPrincipal,
            Principal
        }
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
            Console.WriteLine(employees.Sum(e => e.Salary));
        }
        public static void SeedData(List<IEmployee> employees)
        {
            IEmployee teacher1 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 1, "Bob", "Fisher",40000);
            IEmployee teacher2 = EmployeeFactory.GetEmployeeInstance(EmployeeType.Teacher, 2, "Jenny", "Thomas", 40000);
            IEmployee aprincipal = EmployeeFactory.GetEmployeeInstance(EmployeeType.AssistantPrincipal, 3, "Delvin", "Brown", 70000);
            IEmployee principal = EmployeeFactory.GetEmployeeInstance(EmployeeType.Principal, 4, "Brenda", "Mullins", 80000);

            employees.Add(teacher1);

            employees.Add(teacher2);

            employees.Add(aprincipal);

            employees.Add(principal);
        }
    }

    public class Teacher : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.02m); }
    }

    public class AssistantPrincipal : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.03m); }
    }
    public class Principal : EmployeeBase
    {
        public override decimal Salary { get => base.Salary + (base.Salary * 0.05m); }
    }

    public static class EmployeeFactory
    {
        public static IEmployee GetEmployeeInstance(EmployeeType employeeType, int id, string firstName, string lastName, decimal salary)
        {
            IEmployee employee = null;

            switch (employeeType)
            {
                case EmployeeType.Teacher:
                    employee = FactoryPattern<IEmployee, Teacher>.GetInstance();
                    break;

                case EmployeeType.AssistantPrincipal:
                    employee = FactoryPattern<IEmployee, AssistantPrincipal>.GetInstance();
                    break;

                case EmployeeType.Principal:
                    employee = FactoryPattern<IEmployee, Principal>.GetInstance();
                    break;

            }
            if (employee != null)
            {
                employee.Id = id;
                employee.FirstName = firstName;
                employee.LastName = lastName;
                employee.Salary = salary;
            }
            else
            {
                throw new NullReferenceException();
            }
            return employee;
        }
    }
}