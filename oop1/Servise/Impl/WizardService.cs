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
    public class WizardService : IWizardService
    {
        private readonly IWizardRepository _wizardRepo;
        private readonly ISpellRepository _spellRepo;

        public WizardService(IWizardRepository wizardRepo, ISpellRepository spellRepo)
        {
            _wizardRepo = wizardRepo;
            _spellRepo = spellRepo;
        }

        public IEnumerable<WizardDTO> GetAll()
        {
            var ws = _wizardRepo.GetAll();
            var list = new List<WizardDTO>();
            foreach (var w in ws)
            {
                var spells = _wizardRepo.GetSpellsForWizard(w.Id);
                list.Add(WizardMapper.ToDto(w, spells));
            }
            return list;
        }

        public WizardDTO? GetById(int id)
        {
            var w = _wizardRepo.GetById(id);
            if (w == null) return null;
            var spells = _wizardRepo.GetSpellsForWizard(w.Id);
            return WizardMapper.ToDto(w, spells);
        }
    }
}
