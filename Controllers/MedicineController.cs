using System;
using System.Collections.Generic;
using System.Linq;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Extensions.Logging;

namespace MedHelp.Controllers
{
    //[Authorize]
    [FormatFilter]
    [Route("api/[controller]")]
    public class MedicineController : Controller
    {
        private readonly MedHelpContext _context;
        private readonly ILogger _logger;

        public MedicineController(MedHelpContext context, ILogger<MedicineController> logger)
        {
            _context = context;
            _logger = logger;
        }
        
        [HttpGet("[action]/{format?}")]
        public IEnumerable<string> GetMedicines()
        {
           return _context.Medicines.ToList().Select(m => m.MedicineName).ToList();
        }

        [HttpDelete("[action]/{medicineId}")]
        public IActionResult DeleteMedicine(int medicineId)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var medicine = _context.Medicines.FirstOrDefault(m => m.MedicineId == medicineId);

                    if (medicine == null)
                    {
                        return NotFound();
                    }

                    _context.Medicines.Remove(medicine);
                    _context.SaveChanges();
                    
                    transaction.Commit();

                    return new NoContentResult();
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Can not delete medicine");
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
        }
    }
}