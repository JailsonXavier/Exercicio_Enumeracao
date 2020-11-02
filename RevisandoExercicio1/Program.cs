using RevisandoExercicio1.Entities;
using RevisandoExercicio1.Entities.Enums;
using System;
using System.Globalization;

namespace RevisandoExercicio1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            string deptname = Console.ReadLine();
            Console.WriteLine("Enter worker data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior):");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double salary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department dept= new Department(deptname);
            Worker worker = new Worker(name, level, salary, dept);

            Console.WriteLine("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());
            for (int i =1; i <=n; i++)
            {
                try { 
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date:  (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("ValuePerHours: ");
                double valueperhour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.WriteLine("Duration: (Hours) ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date, valueperhour, hours);
                worker.addContract(contract);

                } catch
                {
                    Console.WriteLine("Dados Inválidos!");
                }
            }

            Console.WriteLine();

            Console.WriteLine("Enter month and year to calculate income (MM/YYYY): ");
            string monthandyear = Console.ReadLine();
            int month = int.Parse(monthandyear.Substring(0,2));
            int year = int.Parse(monthandyear.Substring(3));

            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Icome for " + monthandyear + " : " + worker.Income(year,month).ToString("F2",CultureInfo.InvariantCulture));


        }
    }
}
