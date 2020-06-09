using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie11.Models
{
    public class Patient
    {
        public Patient()
        {
            Prescritions = new HashSet<Prescription>(); 
        }
        public int IdPatient { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Prescription> Prescritions { get; set; }
    }
}
