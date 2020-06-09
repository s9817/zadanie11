using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie11.Models
{
    public class Doctor
    {
        public Doctor()
        {
            Prescritions = new HashSet<Prescription>(); 
        }
        public int IdDoctor { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Prescription> Prescritions { get; set; }
    }
}
