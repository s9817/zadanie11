using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zadanie11.Models;

namespace Zadanie11.Services
{
    public class DrDbService : IDrDbService
    {
        readonly CodeFirstContext _context;
        public DrDbService(CodeFirstContext context)
        {
            _context = context;
        }

        public Doctor AddDoctor(Doctor doctor)
        {
            var doc = _context.Doctor.SingleOrDefault(d => d.IdDoctor == doctor.IdDoctor);
            if (doc != null) return null;
            else
            {
                _context.Doctor.Add(doc);
                _context.SaveChanges();
                return doctor;
            }
        }

        public Doctor DeleteDoctor(int id)
        {
            var doc = _context.Doctor.SingleOrDefault(d => d.IdDoctor == id);
            if (doc != null)
            {
                _context.Remove(doc);
                _context.SaveChanges();
                return doc;
            }
            else return null;

        }

        public Doctor EditDoctor(Doctor doctor)
        {
            var doc = _context.Doctor.SingleOrDefault(d => d.IdDoctor == doctor.IdDoctor);

            if (doc != null)
            {
                doc.LastName = doctor.LastName;
                doc.FirstName = doctor.FirstName;
                doc.Email = doctor.Email;
                _context.SaveChanges();
                return doc;
            }
            else return null;
        }

        public Doctor GetDoctor(int ID)
        {
            var doc = _context.Doctor.SingleOrDefault(d => d.IdDoctor == ID);
            return doc;
        }
    }
}
