using System;
using System.Collections.Generic;
using System.Linq;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MedHelp.Controllers
{
    //[Authorize]
    [FormatFilter]
    [Route("api/[controller]")]
    public class TemplatesController : Controller
    {
        private readonly MedHelpContext _context;
        private readonly ILogger _logger;

        public TemplatesController(MedHelpContext context, ILogger<TemplatesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("[action]/{format?}")]
        public IEnumerable<Template> GetTemplates()
        {
            return _context.Templates;
        }

        [HttpGet("[action]/{templateId}.{format?}")]
        public Template GetTemplateWithProperties(int templateId)
        {
            var template = _context.Templates.Single(t => t.TemplateId == templateId);
            return template;
        }

        [HttpDelete("[action]/{templateId}")]
        public IActionResult DeleteTemplate(int templateId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var template = _context.Medicines.FirstOrDefault(m => m.MedicineId == templateId);

                    if (template == null)
                    {
                        return NotFound();
                    }

                    _context.Medicines.Remove(template);
                    _context.SaveChanges();

                    transaction.Commit();

                    return new NoContentResult();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Can not delete template");
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}