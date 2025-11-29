using labaoop3.Repository.Base;
using labaoop3.Service.Base;
using labaoop3.Service.Mappers;
using labaoop3.Service.Views;
using labaoop3.Repository.Base;
using labaoop3.Service.Base;
using labaoop3.Service.Mappers;
using labaoop3.Service.Views;
using System.Collections.Generic;
using System.Linq;

namespace labaoop3.Service.Impl
{
    public class SpellService : ISpellService
    {
        private readonly ISpellRepository _spellRepo;
        public SpellService(ISpellRepository spellRepo) => _spellRepo = spellRepo;

        public IEnumerable<SpellDTO> GetAll() => _spellRepo.GetAll().Select(SpellMapper.ToDto).ToList();
    }
}
