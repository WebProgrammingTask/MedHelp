﻿// <auto-generated />
using MedHelp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace MedHelp.Migrations
{
    [DbContext(typeof(MedHelpContext))]
    [Migration("20171212032212_ReferenceFix")]
    partial class ReferenceFix
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedHelp.Models.Complaint", b =>
                {
                    b.Property<int>("ComplaintId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ComplaintDescription");

                    b.HasKey("ComplaintId");

                    b.ToTable("Complaints");
                });

            modelBuilder.Entity("MedHelp.Models.ComplaintFormModel", b =>
                {
                    b.Property<int>("ComplaintId");

                    b.Property<int>("FormModelId");

                    b.HasKey("ComplaintId", "FormModelId");

                    b.HasIndex("FormModelId");

                    b.ToTable("ComplaintFormModel");
                });

            modelBuilder.Entity("MedHelp.Models.FormModel", b =>
                {
                    b.Property<int>("FormModelId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Anamnesis");

                    b.Property<string>("DoctorName");

                    b.Property<DateTime>("PatientBirthday");

                    b.Property<string>("PatientName");

                    b.Property<string>("Recommended");

                    b.Property<string>("Speciality");

                    b.Property<DateTime>("VisitDay");

                    b.HasKey("FormModelId");

                    b.ToTable("FormModels");
                });

            modelBuilder.Entity("MedHelp.Models.LastOpenedDocument", b =>
                {
                    b.Property<int>("LastOpenedDocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("FormModelId");

                    b.Property<DateTime>("LastOpenedTime");

                    b.Property<string>("Patient");

                    b.Property<int>("TemplateId");

                    b.HasKey("LastOpenedDocumentId");

                    b.HasIndex("FormModelId")
                        .IsUnique();

                    b.HasIndex("TemplateId");

                    b.ToTable("LastOpenedDocuments");
                });

            modelBuilder.Entity("MedHelp.Models.Medicine", b =>
                {
                    b.Property<int>("MedicineId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("MedicineName");

                    b.HasKey("MedicineId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("MedHelp.Models.MedicineFormModel", b =>
                {
                    b.Property<int>("MedicineId");

                    b.Property<int>("FormModelId");

                    b.HasKey("MedicineId", "FormModelId");

                    b.HasIndex("FormModelId");

                    b.ToTable("MedicineFormModel");
                });

            modelBuilder.Entity("MedHelp.Models.Template", b =>
                {
                    b.Property<int>("TemplateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("FormModelId");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.Property<string>("SchemeJson");

                    b.HasKey("TemplateId");

                    b.HasIndex("FormModelId")
                        .IsUnique();

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("MedHelp.Models.ComplaintFormModel", b =>
                {
                    b.HasOne("MedHelp.Models.Complaint", "Complaint")
                        .WithMany("ComplaintFormModels")
                        .HasForeignKey("ComplaintId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedHelp.Models.FormModel", "FormModel")
                        .WithMany("ComplaintFormModels")
                        .HasForeignKey("FormModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedHelp.Models.LastOpenedDocument", b =>
                {
                    b.HasOne("MedHelp.Models.FormModel", "FormModel")
                        .WithOne("LastOpenedDocument")
                        .HasForeignKey("MedHelp.Models.LastOpenedDocument", "FormModelId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("MedHelp.Models.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedHelp.Models.MedicineFormModel", b =>
                {
                    b.HasOne("MedHelp.Models.FormModel", "FormModel")
                        .WithMany("MedicineFormModels")
                        .HasForeignKey("FormModelId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MedHelp.Models.Medicine", "Medicine")
                        .WithMany("FormModels")
                        .HasForeignKey("MedicineId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MedHelp.Models.Template", b =>
                {
                    b.HasOne("MedHelp.Models.FormModel", "FormModel")
                        .WithOne("Template")
                        .HasForeignKey("MedHelp.Models.Template", "FormModelId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}