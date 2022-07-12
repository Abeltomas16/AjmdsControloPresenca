using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjmdsControloPresenca.Domain.Entities.Teste
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        //
        //Navigation property Returns the Employee Address
        public virtual EmployeeAddress EmployeeAddress { get; set; }
    }

    public class EmployeeAddress
    {
        public int EmployeeID { get; set; }
        public string Address { get; set; }
        //
        //Navigation property Returns the Employee object
        public virtual Employee Employee { get; set; }

    }
}