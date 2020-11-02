using RevisandoExercicio1.Entities.Enums;
using System;
using System.Collections.Generic;

namespace RevisandoExercicio1.Entities
{
    class Worker
    {
        public string Name { get; set; }

        public WorkerLevel Level { get; set; }

        public double BaseSalary { get; set; }

        public Department Department { get; set; }

        //public HourContract contracts { get; set; }

        public List<HourContract> contracts { get; set; } = new List<HourContract>();

        public Worker()
        {

        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department department)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void addContract(HourContract contract)
        {
            contracts.Add(contract);
        }

        public void removeContract(HourContract contract)
        {
            contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (HourContract contract in contracts)
            {

                if (contract.Date.Year == year && contract.Date.Month == month)
                {
                    sum += contract.TotalValue();
                }


            }

            return sum;
        }



    }
}
