using labaoop3.Entities;
using System.Collections.Generic;

namespace labaoop3.Repository.Base
{
    public interface IWizardRepository : IRepository<WizardEntity>
    {
        IEnumerable<SpellEntity> GetSpellsForWizard(int wizardId);
    }
}
