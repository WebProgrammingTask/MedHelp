using System.Collections.Generic;
using System.Linq;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedHelp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class TemplatesController : Controller
    {
        private readonly MedHelpContext _context;

        public TemplatesController(MedHelpContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<Template> GetTemplates()
        {
            return _context.Templates;
        }

        [HttpGet("[action]/{templateId}")]
        public Template GetTemplateWithProperties(int templateId)
        {
            var template = _context.Templates.Single(t => t.TemplateId == templateId);
            _context.Entry(template).Collection(t => t.Fields).Query().Include(f => f.Properties).Load();
            return template;
        }
    }
}