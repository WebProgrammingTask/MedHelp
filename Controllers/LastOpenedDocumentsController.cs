using System;
using System.Collections.Generic;
using System.Linq;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedHelp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class LastOpenedDocumentsController : Controller
    {
        private readonly MedHelpContext _context;

        public LastOpenedDocumentsController(MedHelpContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public IEnumerable<LastOpenedDocument> GetLastOpenedDocuments()
        {
            return _context.LastOpenedDocuments;
        }


        [HttpPost("[action]")]
        public IActionResult InsertNewLastOpenedDocument([FromBody] LastOpenedDocument lastOpenedDocument)
        {
            if (lastOpenedDocument == null)
                return BadRequest();
            try
            {
                _context.LastOpenedDocuments.Add(lastOpenedDocument);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}