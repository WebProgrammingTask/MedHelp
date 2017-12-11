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


        [HttpGet("[action]/{lastOpenedDocumentId}")]
        public LastOpenedDocument GetLastOpenedDocument(int lastOpenedDocumentId)
        {
            return _context.LastOpenedDocuments.Single(l => l.LastOpenedDocumentId == lastOpenedDocumentId);
        }

        [HttpPost("[action]")]
        public IActionResult InsertNewLastOpenedDocument([FromBody]LastOpenedDocument lastOpenedDocument)
        {
            if (lastOpenedDocument == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                _context.LastOpenedDocuments.Add(lastOpenedDocument);
                _context.SaveChanges();
                return CreatedAtRoute("InsertNewLastOpenedDocument", new {Id = lastOpenedDocument.LastOpenedDocumentId}, lastOpenedDocument);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}