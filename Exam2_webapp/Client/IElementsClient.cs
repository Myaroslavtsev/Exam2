using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using View;
using System.Threading;
using System.Threading.Tasks;

namespace Exam2_webapp.Client
{
    public interface IElementsClient 
    {
        // Post("")
        Task<View.Resistors.Resistor> CreateResistorAsync(View.Resistors.ResistorCreateInfo createInfo);

        // Get("{id}")
        Task<View.Resistors.Resistor> GetResistorAsync(string id);

        // Get("")
        Task<View.Resistors.Resistor> SearchResistorAsync(View.Resistors.ResistorSearchInfo searchInfo);

        // Delete("{id}")
        Task DeleteResistorAsync(string id);

        // Patch("{id}")
        Task PatchResistorAsync(string id, View.Resistors.ResistorUpdateInfo updateInfo);
    }
}