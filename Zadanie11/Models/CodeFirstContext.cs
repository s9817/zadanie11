using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie11.Models
{
    public class CodeFirstContext : DbContext
    {
        public virtual DbSet<Patient> Patient { get; set; } //musimy dodac jesli chcemy ich tutaj uzywac
        public virtual DbSet<Prescription> Prescription { get; set; }
        public virtual DbSet<Doctor> Doctor { get; set; }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {

        }

        //nie daje onmodelcofiguring, bo dalam juz w startupie AddDbContext. Bylby błąd!!!
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                //musi byc klucz glowny
                entity.HasKey(e => e.IdPatient).HasName("Patient_PK");
                entity.Property(e => e.IdPatient).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Birthdate).IsRequired();

                var list = new List<Patient>
                {
                    new Patient
                    {
                        IdPatient = 1,
                        FirstName = "Magda",
                        LastName = "Babka",
                        Birthdate = new DateTime(1999,10,05)
                    },
                    new Patient
                    {
                        IdPatient = 2,
                        FirstName = "Izabela",
                        LastName = "Kalika",
                        Birthdate = new DateTime(1960,06,04)
                    }
                };

                entity.HasData(list);
            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                //musi byc klucz glowny
                entity.HasKey(e => e.IdDoctor).HasName("Doctorn_PK");
                entity.Property(e => e.IdDoctor).ValueGeneratedNever();
                entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Email).HasMaxLength(100).IsRequired();
                var list = new List<Doctor>
                {
                    new Doctor
                    {
                        IdDoctor = 1,
                        FirstName = "Karol",
                        LastName = "Lek",
                        Email = "klek@op.pl"
                    },
                    new Doctor
                    {
                        IdDoctor = 2,
                        FirstName = "Paulina",
                        LastName = "Doc",
                        Email = "pdoc@op.pl"
                    }
                };

                entity.HasData(list);
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                //musi byc klucz glowny
                entity.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Date).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();
                entity.HasOne(d => d.Patient).WithMany(p => p.Prescritions)
                    .HasForeignKey(d => d.IdPatient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescrition_Patient");
                entity.HasOne(d => d.Doctor).WithMany(p => p.Prescritions)
                    .HasForeignKey(d => d.IdDoctor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Prescrition_Doctor");

                var list = new List<Prescription>
                {
                    new Prescription
                    {
                        IdPrescription = 1,
                        Date = new DateTime(2020,06,04),
                        DueDate = new DateTime(2020,06,20),
                       IdPatient = 1,
                       IdDoctor = 1
                    },
                   new Prescription
                   {
                       IdPrescription = 2,
                       Date = new DateTime(2020, 06, 05),
                       DueDate = new DateTime(2020, 06, 21),
                       IdPatient = 2,
                       IdDoctor = 1
                    }
                };

                entity.HasData(list);
            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                //musi byc klucz glowny
                entity.HasKey(e => e.IdMedicament).HasName("Medicament_PK");
                entity.Property(e => e.IdMedicament).ValueGeneratedNever();
                entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Description).HasMaxLength(100).IsRequired();
                entity.Property(e => e.Type).HasMaxLength(100).IsRequired();

                var list = new List<Medicament>
                {
                    new Medicament
                    {
                        IdMedicament = 1,
                        Name = "koronabiotyk",
                        Description = "silny antybiotyk, lecz koronawirusa",
                        Type = "syrop"
                    },

                    new Medicament
                    {
                        IdMedicament = 2,
                        Name = "straszka",
                        Description = "lek na stres",
                        Type = "tabletki"
                    },
                    new Medicament
                    {
                        IdMedicament = 3,
                        Name = "grzybostop",
                        Description = "lek na grzybice na sterydach",
                        Type = "maść"
                    }
                };

                entity.HasData(list);
            });



            modelBuilder.Entity<Prescription_Medicament>(entity =>
            {
                //musi byc klucz glowny
                entity.HasKey(e => new { e.IdMedicament, e.IdPrescription }).HasName("Med_Presc_PK");
                entity.Property(e => e.IdPrescription).ValueGeneratedNever();
                entity.Property(e => e.Dose).IsRequired();
                entity.Property(e => e.Details).HasMaxLength(100).IsRequired();
                entity.HasOne(d => d.Medicament).WithMany(p => p.Prescription_Medicament)
                    .HasForeignKey(d => d.IdMedicament)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MP_Medicament");
                entity.HasOne(d => d.Prescription).WithMany(p => p.Prescription_Medicament)
                    .HasForeignKey(d => d.IdPrescription)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MP_Prescription");

                var list = new List<Prescription_Medicament>
                {
                    new Prescription_Medicament
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Dose =5,
                        Details = "duża łyżka co 5h"
                    },

                    new Prescription_Medicament
                    {
                       IdMedicament = 1,
                        IdPrescription = 2,
                        Dose =5,
                        Details = "duża łyżka co 5h"
                    },
                    new Prescription_Medicament
                    {
                        IdMedicament = 3,
                        IdPrescription = 1,
                        Dose =1,
                        Details = "smarowac raz dziennie"
                    }
                };

                entity.HasData(list);
            });


        }
    }
}
