using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View.Resistors;

namespace Model
{
    public class ResistorsRepository : Model.IResistorsRepository
    {
        public Task<Resistors.Resistor> CreateResistorAsync(Model.Resistors.ResistorCreateInfo createinfo, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task DeleteResistorAsync(string id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<Resistors.Resistor> GetResistorAsync(string id, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task<List<Resistors.Resistor>> SearchResisrosAsync(Model.Resistors.ResistorSearchInfo searchinfo, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateResistorAsync(string id, Model.Resistors.ResistorUpdateInfo updateInfo, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
