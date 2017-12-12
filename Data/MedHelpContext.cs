using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedHelp.Models;
using Microsoft.EntityFrameworkCore;


namespace MedHelp.Data
{
    public class MedHelpContext : DbContext
    {
        public MedHelpContext(DbContextOptions<MedHelpContext> options) : base(options)
        { }
        
        public DbSet<LastOpenedDocument> LastOpenedDocuments { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<FormModel> FormModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicineFormModel>()
                .HasKey(t => new {t.MedicineId, t.FormModelId});
            modelBuilder.Entity<FormModel>()
                .HasOne(t => t.Template)
                .WithOne(f => f.FormModel)
                .HasForeignKey<Template>(f => f.FormModelId);

            modelBuilder.Entity<FormModel>()
                .HasOne(t => t.LastOpenedDocument)
                .WithOne(f => f.FormModel)
                .HasForeignKey<LastOpenedDocument>(f => f.FormModelId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
