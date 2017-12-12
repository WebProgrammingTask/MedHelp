using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedHelp.Models
{
    public class Complaint
    {
        public int ComplaintId { get; set; }
        public string ComplaintDescription { get; set; }
        public ICollection<ComplaintFormModel> ComplaintFormModels { get;} = new List<ComplaintFormModel>();

    }
}
