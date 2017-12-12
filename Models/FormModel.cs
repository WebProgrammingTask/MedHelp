using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedHelp.Models
{
    public class FormModel
    {
        public int FormModelId { get; set; }
        public string PatientName { get; set; }
        public DateTime PatientBirthday { get; set; }
        public DateTime VisitDay { get; set; }
        public ICollection<MedicineFormModel> MedicineFormModels{ get;} = new List<MedicineFormModel>();
        public string Complaints { get; set; }
        public LastOpenedDocument LastOpenedDocument{ get; set; }
        public Template Template { get; set; }
        public string Speciality { get; set; }
        public string DoctorName { get; set; }
        public string Anamnesis { get; set; }
        public string Recommended { get; set; }
    }
}
