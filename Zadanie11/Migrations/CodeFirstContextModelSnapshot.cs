using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zadanie11.Migrations
{
    public partial class CodeFirstContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("cw11EFt.Models.Doctor", b =>
            {
                b.Property<int>("IdDoctor")
                    .HasColumnType("int");

                b.Property<string>("Email")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdDoctor")
                    .HasName("Doctorn_PK");

                b.ToTable("Doctor");

                b.HasData(
                    new
                    {
                        IdDoctor = 1,
                        Email = "klek@op.pl",
                        FirstName = "Karol",
                        LastName = "Lek"
                    },
                    new
                    {
                        IdDoctor = 2,
                        Email = "pdoc@op.pl",
                        FirstName = "Paulina",
                        LastName = "Doc"
                    });
            });

            modelBuilder.Entity("cw11EFt.Models.Medicament", b =>
            {
                b.Property<int>("IdMedicament")
                    .HasColumnType("int");

                b.Property<string>("Description")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Name")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("Type")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdMedicament")
                    .HasName("Medicament_PK");

                b.ToTable("Medicament");

                b.HasData(
                    new
                    {
                        IdMedicament = 1,
                        Description = "silny antybiotyk, lecz koronawirusa",
                        Name = "koronabiotyk",
                        Type = "syrop"
                    },
                    new
                    {
                        IdMedicament = 2,
                        Description = "lek na stres",
                        Name = "straszka",
                        Type = "tabletki"
                    },
                    new
                    {
                        IdMedicament = 3,
                        Description = "lek na grzybice na sterydach",
                        Name = "grzybostop",
                        Type = "maść"
                    });
            });

            modelBuilder.Entity("cw11EFt.Models.Patient", b =>
            {
                b.Property<int>("IdPatient")
                    .HasColumnType("int");

                b.Property<DateTime>("Birthdate")
                    .HasColumnType("datetime2");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.HasKey("IdPatient")
                    .HasName("Patient_PK");

                b.ToTable("Patient");

                b.HasData(
                    new
                    {
                        IdPatient = 1,
                        Birthdate = new DateTime(1999, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        FirstName = "Magda",
                        LastName = "Babka"
                    },
                    new
                    {
                        IdPatient = 2,
                        Birthdate = new DateTime(1960, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        FirstName = "Izabela",
                        LastName = "Kalika"
                    });
            });

            modelBuilder.Entity("cw11EFt.Models.Prescription", b =>
            {
                b.Property<int>("IdPrescription")
                    .HasColumnType("int");

                b.Property<DateTime>("Date")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DueDate")
                    .HasColumnType("datetime2");

                b.Property<int>("IdDoctor")
                    .HasColumnType("int");

                b.Property<int>("IdPatient")
                    .HasColumnType("int");

                b.HasKey("IdPrescription")
                    .HasName("Prescription_PK");

                b.HasIndex("IdDoctor");

                b.HasIndex("IdPatient");

                b.ToTable("Prescription");

                b.HasData(
                    new
                    {
                        IdPrescription = 1,
                        Date = new DateTime(2020, 6, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        DueDate = new DateTime(2020, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        IdDoctor = 1,
                        IdPatient = 1
                    },
                    new
                    {
                        IdPrescription = 2,
                        Date = new DateTime(2020, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        DueDate = new DateTime(2020, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                        IdDoctor = 1,
                        IdPatient = 2
                    });
            });

            modelBuilder.Entity("cw11EFt.Models.Prescription_Medicament", b =>
            {
                b.Property<int>("IdMedicament")
                    .HasColumnType("int");

                b.Property<int>("IdPrescription")
                    .HasColumnType("int");

                b.Property<string>("Details")
                    .IsRequired()
                    .HasColumnType("nvarchar(100)")
                    .HasMaxLength(100);

                b.Property<int>("Dose")
                    .HasColumnType("int");

                b.HasKey("IdMedicament", "IdPrescription")
                    .HasName("Med_Presc_PK");

                b.HasIndex("IdPrescription");

                b.ToTable("Prescription_Medicament");

                b.HasData(
                    new
                    {
                        IdMedicament = 1,
                        IdPrescription = 1,
                        Details = "duża łyżka co 5h",
                        Dose = 5
                    },
                    new
                    {
                        IdMedicament = 1,
                        IdPrescription = 2,
                        Details = "duża łyżka co 5h",
                        Dose = 5
                    },
                    new
                    {
                        IdMedicament = 3,
                        IdPrescription = 1,
                        Details = "smarowac raz dziennie",
                        Dose = 1
                    });
            });

            modelBuilder.Entity("cw11EFt.Models.Prescription", b =>
            {
                b.HasOne("cw11EFt.Models.Doctor", "Doctor")
                    .WithMany("Prescritions")
                    .HasForeignKey("IdDoctor")
                    .HasConstraintName("Prescrition_Doctor")
                    .IsRequired();

                b.HasOne("cw11EFt.Models.Patient", "Patient")
                    .WithMany("Prescritions")
                    .HasForeignKey("IdPatient")
                    .HasConstraintName("Prescrition_Patient")
                    .IsRequired();
            });

            modelBuilder.Entity("cw11EFt.Models.Prescription_Medicament", b =>
            {
                b.HasOne("cw11EFt.Models.Medicament", "Medicament")
                    .WithMany("Prescription_Medicament")
                    .HasForeignKey("IdMedicament")
                    .HasConstraintName("MP_Medicament")
                    .IsRequired();

                b.HasOne("cw11EFt.Models.Prescription", "Prescription")
                    .WithMany("Prescription_Medicament")
                    .HasForeignKey("IdPrescription")
                    .HasConstraintName("MP_Prescription")
                    .IsRequired();
            });
        }
    }
}
