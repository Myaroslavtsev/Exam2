using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using View;
using System.Threading;
using System.Threading.Tasks;
using View.Resistors;

namespace Exam2_webapp.Client
{
    public sealed class ElementsClient : IElementsClient
    {
        // Post("")
        public async Task<Resistor> CreateResistorAsync(ResistorCreateInfo createInfo)
        {
            throw new NotImplementedException();
        }

        // Get("{id}")
        public async Task<Resistor> GetResistorAsync(string id)
        {
            throw new NotImplementedException();
        }

        // Get("")
        public async Task<Resistor> SearchResistorAsync(ResistorSearchInfo searchInfo)
        {
            throw new NotImplementedException();
        }

        // Delete("{id}")
        public async Task DeleteResistorAsync(string id)
        {
            throw new NotImplementedException();
        }

        // Patch("{id}")
        public async Task PatchResistorAsync(string id, ResistorUpdateInfo updateInfo)
        {
            throw new NotImplementedException();
        }
    }
}