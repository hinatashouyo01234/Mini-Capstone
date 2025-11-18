using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashboardForm
{
    public class Patient
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        public DateTime? BiteDate { get; set; }
        public string BiteLocation { get; set; }
        public string AnimalType { get; set; }

        public bool VaccineGiven { get; set; }
        public DateTime? VaccineDate { get; set; }
        public string Notes { get; set; }
        public string VaccineName { get; set; }
        public string DoseNumber { get; set; }
        public DateTime FirstDoseDate { get; set; }
        public DateTime NextDoseDate { get; set; }
    }
}
