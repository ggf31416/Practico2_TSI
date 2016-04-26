using Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shared.Entities
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public DateTime StartDate { get; set; }

        public int? Salary { get; set; }

        public double? HourlyRate { get; set; }

        public bool isFullTime { get; set; }

        public static EmployeeDTO FromShared(Employee emp)
        {
            EmployeeDTO e = new EmployeeDTO { Id = emp.Id, Name = emp.Name, StartDate = emp.StartDate };
            e.isFullTime = emp is FullTimeEmployee;
            if (emp is FullTimeEmployee)
            {
                e.Salary = ((FullTimeEmployee)emp).Salary;
            }
            else {
                e.HourlyRate = ((PartTimeEmployee)emp).HourlyRate;
            }
            return e;
        }



        public Employee toShared()
        {
            if (isFullTime)
            {
                return new FullTimeEmployee() { Id = this.Id, Name = this.Name, StartDate = this.StartDate, Salary = this.Salary.Value };
            }
            else
            {
                return new PartTimeEmployee() { Id = this.Id, Name = this.Name, StartDate = this.StartDate, HourlyRate = this.HourlyRate.Value };
            }
        }

    }
}