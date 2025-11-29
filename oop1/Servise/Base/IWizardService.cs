using labaoop3.Service.Views;
using labaoop3.Service.Views;
using System.Collections.Generic;

namespace labaoop3.Service.Base
{
    public interface IWizardService
    {
        IEnumerable<WizardDTO> GetAll();
        WizardDTO? GetById(int id);
    }
}
