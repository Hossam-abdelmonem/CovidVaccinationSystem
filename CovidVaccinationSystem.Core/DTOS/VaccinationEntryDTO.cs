using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationSystem.Core.DTOS
{
    public class VaccinationEntryDTO
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccinationDate { get; set; }
    }
}
