using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationSystem.Core.Entities
{
    public class VaccinationEntry
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
        public Patient Patient { get; set; }
    }
}
