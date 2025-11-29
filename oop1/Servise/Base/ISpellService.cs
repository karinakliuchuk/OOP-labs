using labaoop3.Service.Views;
using System.Collections.Generic;

namespace labaoop3.Service.Base
{
    public interface ISpellService
    {
        IEnumerable<SpellDTO> GetAll();
    }
}

