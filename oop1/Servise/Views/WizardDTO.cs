using labaoop3.Service.Views;
using labaoop3.Service.Views;
using System.Collections.Generic;

namespace labaoop3.Service.Views
{
    public class WizardDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string House { get; set; } = "";
        public List<SpellDTO> Spells { get; set; } = new();
    }
}
