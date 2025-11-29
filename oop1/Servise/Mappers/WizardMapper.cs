using labaoop3.Entities;
using labaoop3.Entities;
using labaoop3.Service.Mappers;
using labaoop3.Service.Views;
using labaoop3.Service.Views;
using labaoop3.Service.Mappers;
using System.Linq;

namespace labaoop3.Service.Mappers
{
    public static class WizardMapper
    {
        public static WizardDTO ToDto(WizardEntity e, System.Collections.Generic.IEnumerable<labaoop3.Entities.SpellEntity> spells)
        {
            return new WizardDTO
            {
                Id = e.Id,
                Name = e.Name,
                House = e.House,
                Spells = spells.Select(s => SpellMapper.ToDto(s)).ToList()
            };
        }
    }
}
