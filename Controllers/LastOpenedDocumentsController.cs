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

        /// <summary>
        /// Get all last opened documents
        /// </summary>
        /// <returns>List with all last documents</returns>
        [HttpGet("[action]")]
        public IEnumerable<LastOpenedDocument> GetLastOpenedDocuments()
        {
            return _context.LastOpenedDocuments.OrderByDescending(d => d.LastOpenedTime);
        }

        /// <summary>
        /// Get specific last opened document by id
        /// </summary>
        /// <param name="lastOpenedDocumentId">Needed document id</param>
        /// <returns>Document</returns>
        [HttpGet("[action]/{lastOpenedDocumentId}")]
        public LastOpenedDocument GetLastOpenedDocument(int lastOpenedDocumentId)
        {
            return _context.LastOpenedDocuments.Single(l => l.LastOpenedDocumentId == lastOpenedDocumentId);
        }

        /// <summary>
        /// Update existing document
        /// </summary>
        /// <remarks>
        /// According to the HTTP spec, a PUT request requires the client to send the entire updated entity, not just the deltas.
        /// </remarks>
        /// <param name="lastOpenedDocumentId">Needed template id</param>
        /// <param name="lastOpenedDocument">Needed document to update</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">All have updated successfully</response>
        /// <response code="400">If the item is null</response>  
        /// <response code="404">If the document not found</response>
        [HttpPut("[action]/{lastOpenedDocumentId}")]
        [ProducesResponseType(typeof(LastOpenedDocument), 200)]
        [ProducesResponseType(typeof(LastOpenedDocument), 400)]
        [ProducesResponseType(typeof(LastOpenedDocument), 404)]
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
            document.ModelJson = lastOpenedDocument.ModelJson;

            _context.LastOpenedDocuments.Update(document);
            _context.SaveChanges();

            return Ok();
        }

        /// <summary>
        /// Add document to the database
        /// </summary>
        /// <remarks>
        /// The preceding code is an HTTP POST method, indicated by the [HttpPost] attribute. 
        /// The [FromBody] attribute tells MVC to get the value of the to-do item from the body of the HTTP request.
        /// </remarks>
        /// <param name="lastOpenedDocument">New document needed to insert</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">All have added successfully</response>
        /// <response code="400">If the item is null</response>
        [HttpPost("[action]")]
        [ProducesResponseType(typeof(LastOpenedDocument), 200)]
        [ProducesResponseType(typeof(LastOpenedDocument), 400)]
        public IActionResult InsertNewLastOpenedDocument([FromBody]LastOpenedDocument lastOpenedDocument)
        {
            if (lastOpenedDocument == null || !ModelState.IsValid)
                return BadRequest();
            try
            {
                _context.LastOpenedDocuments.Add(lastOpenedDocument);
                _context.SaveChanges();
                return Ok(lastOpenedDocument.LastOpenedDocumentId);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Can not insert new last opened document");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}