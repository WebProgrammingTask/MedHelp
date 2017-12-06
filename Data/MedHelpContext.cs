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
    }
}
