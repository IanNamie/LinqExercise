using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Xsl;

namespace LinqExercise
{
    class Program
    {
        //Static array of integers
        private static int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 };

        static void Main(string[] args)
        {
            /*
             * 
             * Complete every task using Method OR Query syntax. 
             * You may find that Method syntax is easier to use since it is most like C#
             * Every one of these can be completed using Linq and then printing with a foreach loop.
             * Push to your github when completed!
             * 
             */

            //TODO: Print the Sum of numbers
            Console.WriteLine("Sum of the Numbers:");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine("______________________________________________");
            //Sum();
            //TODO: Print the Average of numbers
            Console.WriteLine("Average of the Numbers:");
            Console.WriteLine(numbers.Average());
            Console.WriteLine("______________________________________________");
            //Average();
            //TODO: Order numbers in ascending order and print to the console
            Console.WriteLine("Ascending order:");
            var asc = numbers.OrderBy(x => x);
            foreach (var num in asc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("______________________________________________");
            //OrderAccending();
            //TODO: Order numbers in decsending order and print to the console
            Console.WriteLine("descending order:");
            var desc = numbers.OrderByDescending(x => x);
            foreach (var num in desc)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("______________________________________________");
            //OrderDecending();
            //TODO: Print to the console only the numbers greater than 6
            Console.WriteLine("Greater than 6:");
            var greaterThan6 = numbers.Where(x => x > 6);
            foreach (var num in greaterThan6)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("______________________________________________");
            //GreaterThan6();
            //TODO: Order numbers in any order (acsending or desc) but only print 4 of them **foreach loop only!**
            Console.WriteLine("descending last 4:");
            foreach (var num in desc.Take(4)) 
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("______________________________________________");
            //LastFour();

            //TODO: Change the value at index 4 to your age, then print the numbers in decsending order
            Console.WriteLine("Age injector:");
            numbers.SetValue(23, 4);
            var descendingWithAge = numbers.OrderByDescending(x => x);
            foreach (var num in descendingWithAge) 
            { 
                Console.WriteLine(num);
            }

            Console.WriteLine("______________________________________________");
            
            //MyAgeInjector();
            // List of employees ****Do not remove this****
            var employees = CreateEmployees();

            //TODO: Print all the employees' FullName properties to the console only if their FirstName starts with a C OR an S and order this in ascending order by FirstName.

            var firstNameWithCOrS = employees.Where(x => x.FirstName.ToLower().StartsWith("c") || x.FirstName.ToLower().StartsWith("s"));
            employees.OrderBy(x => x.FirstName);
            Console.WriteLine("Employee ordered by first name and letter:");
            foreach (var name in firstNameWithCOrS) 
            {
                Console.WriteLine(name.FullName);
            }
            Console.WriteLine("__________________________________________________________________________");

            //TODO: Print all the employees' FullName and Age who are over the age 26 to the console and order this by Age first and then by FirstName in the same result.
            Console.WriteLine("Employee ordered by name and age:");
            var ageFilter = employees.Where(x => x.Age > 26).OrderByDescending(x => x.Age).OrderBy(x => x.FirstName);
            foreach (var name in ageFilter) 
            {
                Console.WriteLine(name.FullName);
                Console.WriteLine(name.Age);
            }
            Console.WriteLine("___________________________________________________________________________");
            //TODO: Print the Sum and then the Average of the employees' YearsOfExperience if their YOE is less than or equal to 10 AND Age is greater than 35.
            Console.WriteLine("Sum and Average Years of Experience:");
            Console.WriteLine("");
            var yearsOfExp = employees.Where(x => x.YearsOfExperience <= 10 && x.Age > 35); 
            
                Console.WriteLine($"Sum of years of experience: {yearsOfExp.Sum(x => x.YearsOfExperience)}");
                Console.WriteLine($"Average years of experience: {yearsOfExp.Average(x => x.YearsOfExperience)}");
            Console.WriteLine("___________________________________________________________________________");
            //TODO: Add an employee to the end of the list without using employees.Add()
            Console.WriteLine("Added new employee...");
            employees = employees.Append(new Employee("Ian", "Namie", 23,1)).ToList();
            foreach (var newEmployee in employees) 
            {
                Console.WriteLine(newEmployee.FullName); 
            }
            Console.WriteLine("____________________________________________________________________________");

            Console.WriteLine();

            Console.ReadLine();
        }
        public static void  Sum()
        {
            Console.WriteLine("Sum:");
            
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum);
            Console.WriteLine("_______________________________________________________________");
        }
        public static void Average()
        {
            Console.WriteLine("Average:");
            
            var sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
            }
            Console.WriteLine(sum / 9);
            Console.WriteLine("_______________________________________________________________");
        }
        public static void OrderAccending()
        {
            Console.WriteLine("Accending Order:");
            
         var acending = numbers.OrderBy(x => x);
            foreach (var num in acending) 
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("_______________________________________________________________");
        }
        public static void OrderDecending()
        {
            Console.WriteLine("Decending Order:");
            
            var decending = numbers.OrderByDescending(x => x);
            foreach (var num in decending)
            {
                Console.WriteLine(num);
            }
            Console.WriteLine("________________________________________________________________");
        }
        public static void GreaterThan6()
        {
            Console.WriteLine("numbers Greater Than 6:");
            foreach (var num in numbers)
            {
                if (num > 6) 
                {
                    Console.WriteLine(num);
                }
            }
            Console.WriteLine("________________________________________________________________");
        }
        public static void LastFour()
        {
            Console.WriteLine("Last four in descending:");
        var accending = numbers.OrderByDescending(x => x);
            foreach (var decending in accending) 
            {
                if (decending > 5)
                {
                    Console.WriteLine(decending);
                }
            }
            Console.WriteLine("________________________________________________________________");
        }
        public static void MyAgeInjector()
        {
            Console.WriteLine("Replacing with my age:");
            numbers[4] = 23;
            var goingDown = numbers.OrderByDescending(x => x);
            foreach (var num in goingDown) 
            {
                Console.WriteLine(num); 
            }
            Console.WriteLine("____________________________________________________________");
        }
       
        #region CreateEmployeesMethod
        private static List<Employee> CreateEmployees()
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Cruz", "Sanchez", 25, 10));
            employees.Add(new Employee("Steven", "Bustamento", 56, 5));
            employees.Add(new Employee("Micheal", "Doyle", 36, 8));
            employees.Add(new Employee("Daniel", "Walsh", 72, 22));
            employees.Add(new Employee("Jill", "Valentine", 32, 43));
            employees.Add(new Employee("Yusuke", "Urameshi", 14, 1));
            employees.Add(new Employee("Big", "Boss", 23, 14));
            employees.Add(new Employee("Solid", "Snake", 18, 3));
            employees.Add(new Employee("Chris", "Redfield", 44, 7));
            employees.Add(new Employee("Faye", "Valentine", 32, 10));

            return employees;
        }
        #endregion
    }
}
