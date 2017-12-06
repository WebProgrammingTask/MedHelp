using System;
using System.Collections.Generic;
using System.Linq;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedHelp.Controllers
{
    [Authorize]
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
    }
}