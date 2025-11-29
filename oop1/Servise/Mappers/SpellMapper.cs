using labaoop3.Entities;
using labaoop3.Service.Views;
using labaoop3.Entities;
using labaoop3.Service.Views;

namespace labaoop3.Service.Mappers
{
    public static class SpellMapper
    {
        public static SpellDTO ToDto(SpellEntity e) =>
            new SpellDTO { Id = e.Id, Name = e.Name, Damage = e.Damage, Effect = e.Effect };
    }
}
