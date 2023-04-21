using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagementConsole.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Timespan { get; set; }
        public bool Busy { get; set; }
    }
}
