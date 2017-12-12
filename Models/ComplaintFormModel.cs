using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedHelp.Models
{
    public class ComplaintFormModel
    {
        public int ComplaintId { get; set; }
        public Complaint Complaint { get; set; }

        public int FormModelId { get; set; }
        public FormModel FormModel { get; set; }
    }
}
