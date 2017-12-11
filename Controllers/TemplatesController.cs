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

        /// <summary>
        /// Get all templates
        /// </summary>
        /// <returns>
        /// List with all templates
        /// </returns>
        [HttpGet("[action]")]
        public IEnumerable<Template> GetTemplates()
        {
            return _context.Templates;
        }

        /// <summary>
        /// Get specific template by templateId with loaded propertiesss
        /// </summary>
        /// <param name="templateId">Needed template id</param>
        /// <returns>Template</returns>
        [HttpGet("[action]/{templateId}")]
        public Template GetTemplateWithProperties(int templateId)
        {
            var template = _context.Templates.Single(t => t.TemplateId == templateId);
            _context.Entry(template).Collection(t => t.Properties).Query().Include(p => p.Type).Load();
            return template;
        }
    }
}