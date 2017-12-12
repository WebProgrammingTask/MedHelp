using System;
using System.Collections.Generic;
using System.Linq;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

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
            return _context.LastOpenedDocuments.OrderByDescending(d => d.LastOpenedTime);
        }


        [HttpGet("[action]/{lastOpenedDocumentId}")]
        public LastOpenedDocument GetLastOpenedDocument(int lastOpenedDocumentId)
        {
            return _context.LastOpenedDocuments.Single(l => l.LastOpenedDocumentId == lastOpenedDocumentId);
        }

        //TODO: REMAKE

        [HttpPut("[action]/{lastOpenedDocumentId}")]
        public IActionResult UpdateDocument(int lastOpenedDocumentId, [FromBody] LastOpenedDocument lastOpenedDocument)
        {
            if (lastOpenedDocument == null || lastOpenedDocument.LastOpenedDocumentId != lastOpenedDocumentId)
            {
                return BadRequest();
            }

            var document = _context.LastOpenedDocuments.Single(d => d.LastOpenedDocumentId == lastOpenedDocumentId);

            if (document == null)
            {
                return NotFound();
            }

            document.LastOpenedTime = lastOpenedDocument.LastOpenedTime;
            document.Patient = lastOpenedDocument.Patient;
            //document.ModelJson = lastOpenedDocument.ModelJson;

            _context.LastOpenedDocuments.Update(document);
            _context.SaveChanges();

            return Ok();
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
                return Ok(lastOpenedDocument.LastOpenedDocumentId);
                //CreatedAtRoute("GetLastOpenedDocument",
                //    new {lastOpenedDocumentId = lastOpenedDocument.LastOpenedDocumentId},
                //    lastOpenedDocument); //Ok();//CreatedAtRoute("InsertNewLastOpenedDocument", new {Id = lastOpenedDocument.LastOpenedDocumentId}, lastOpenedDocument);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Can not insert new last opened document");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}