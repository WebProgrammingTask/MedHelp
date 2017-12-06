using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedHelp.Models;
using Microsoft.EntityFrameworkCore;
using Type = MedHelp.Models.Type;


namespace MedHelp.Data
{
    public class MedHelpContext : DbContext
    {
        public MedHelpContext(DbContextOptions<MedHelpContext> options) : base(options)
        { }
        
        public DbSet<LastOpenedDocument> LastOpenedDocuments { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Property> Properties { get; set; }
    }
}
