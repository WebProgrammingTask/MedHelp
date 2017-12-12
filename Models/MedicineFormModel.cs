using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedHelp.Models
{
    public class MedicineFormModel
    {
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }

        public int FormModelId { get; set; }
        public FormModel FormModel { get; set; }
    }
}
