using System;
using System.Collections.Generic;
using System.Linq;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MedHelp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    public class LastOpenedDocumentsController : Controller
    {
        private readonly MedHelpContext _context;
        private readonly ILogger _logger;

        public LastOpenedDocumentsController(MedHelpContext context, ILogger<LastOpenedDocumentsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public IEnumerable<LastOpenedDocument> GetLastOpenedDocuments()
        {
            return _context.LastOpenedDocuments;
        }


        [HttpPost("[action]")]
        public IActionResult InsertNewLastOpenedDocument([FromBody] LastOpenedDocument lastOpenedDocument)
        {
            if (lastOpenedDocument == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                _context.LastOpenedDocuments.Add(lastOpenedDocument);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Can not insert new last opened document");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}