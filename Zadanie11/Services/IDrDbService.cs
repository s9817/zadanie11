using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie11.Models;

namespace Zadanie11.Services
{
    public interface IDrDbService
    {
        public Doctor GetDoctor(int id);
        public Doctor AddDoctor(Doctor doctor);
        public Doctor EditDoctor(Doctor doctor);
        public Doctor DeleteDoctor(int id);
    }
}
