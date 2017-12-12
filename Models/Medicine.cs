using System.Collections.Generic;

namespace MedHelp.Models
{
    public class Medicine
    {
        public int MedicineId { get; set; }
        public string MedicineName { get; set; }
        public ICollection<MedicineFormModel> FormModels { get;  } = new List<MedicineFormModel>();
    }
}