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
    [Migration("20171206120843_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedHelp.Models.LastOpenedDocument", b =>
                {
                    b.Property<int>("LastOpenedDocumentId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("LastOpenedTime");

                    b.Property<string>("Patient");

                    b.Property<int>("TemplateId");

                    b.HasKey("LastOpenedDocumentId");

                    b.HasIndex("TemplateId");

                    b.ToTable("GetLastOpenedDocuments");
                });

            modelBuilder.Entity("MedHelp.Models.Template", b =>
                {
                    b.Property<int>("TemplateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImagePath");

                    b.Property<string>("Name");

                    b.HasKey("TemplateId");

                    b.ToTable("Templates");
                });

            modelBuilder.Entity("MedHelp.Models.LastOpenedDocument", b =>
                {
                    b.HasOne("MedHelp.Models.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
