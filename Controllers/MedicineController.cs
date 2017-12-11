using System.Collections.Generic;
using System.Linq;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using Microsoft.Extensions.Logging;

namespace MedHelp.Controllers
{
    //[Authorize]
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

        /// <summary>
        /// Get all medicines
        /// </summary>
        /// <returns>All medicines</returns>
        [HttpGet("[action]")]
        public IEnumerable<string> GetMedicines()
        {
            return _context.Medicines.ToList().Select(m => m.MedicineName).ToList();
        }
    }
}