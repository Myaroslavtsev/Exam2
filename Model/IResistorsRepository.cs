using System.Threading;
using System.Threading.Tasks;
using ModelResistors = Model.Resistors;
using System.Collections.Generic;
using View.Resistors;

namespace Model
{
    public interface IResistorsRepository
    {
        Task<ModelResistors.Resistor> GetResistorAsync(string id, CancellationToken token);

        Task<List<ModelResistors.Resistor>> SearchResisrosAsync(Model.Resistors.ResistorSearchInfo searchinfo, CancellationToken token);

        Task<ModelResistors.Resistor> CreateResistorAsync(Model.Resistors.ResistorCreateInfo createinfo, CancellationToken token);

        Task UpdateResistorAsync(string id, Model.Resistors.ResistorUpdateInfo updateInfo, CancellationToken token);

        Task DeleteResistorAsync(string id, CancellationToken token);
    }
}
