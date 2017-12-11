using System.Collections.Generic;
using MedHelp.Data;
using MedHelp.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("[action]")]
        public IEnumerable<Medicine> GetMedicines()
        {
            return _context.Medicines;
        }
    }
}