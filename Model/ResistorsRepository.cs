using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View.Resistors;

namespace Model
{
    public class ResistorsRepository : IResistorsRepository
    {
        public Task<Resistors.Resistor> CreateResistorAsync(ResistorCreateInfo createinfo, CancellationToken token)
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

        public Task<List<Resistors.Resistor>> SearchResisrosAsync(ResistorSearchInfo searchinfo, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public Task UpdateResistorAsync(string id, ResistorUpdateInfo updateInfo, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
