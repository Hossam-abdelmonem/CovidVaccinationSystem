using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidVaccinationSystem.Core.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsVaccinated { get; set; }
        public ICollection<VaccinationEntry> VaccinationEntries { get; set; }
    }
}
