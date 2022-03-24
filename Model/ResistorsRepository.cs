using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using View.Resistors;
using MongoDB;
using MongoDB.Driver;
using Model.Exceptions;

namespace Model
{
    public sealed class ResistorsRepository : Model.IResistorsRepository
    {
        private readonly IMongoCollection<Model.Resistors.Resistor> resistorsCollection;

        public ResistorsRepository(IMongoCollection<Model.Resistors.Resistor> resistorsCollection)
        {
            this.resistorsCollection = resistorsCollection ?? throw new ArgumentNullException(nameof(resistorsCollection));
        }

        public async Task<Resistors.Resistor> CreateResistorAsync(Model.Resistors.ResistorCreateInfo createinfo, CancellationToken token)
        {
            var resistor = new Model.Resistors.Resistor
            {
                Id = Guid.NewGuid().ToString(),
                Resistance = createinfo.Resistance,
                Accuracy = createinfo.Accuracy ?? 0,
                Power = createinfo.Power,
                Quantity = createinfo.Quantity ?? 0,
                Material = createinfo.Material,
                Manufacturer = createinfo.Manufacturer
            };

            await this.resistorsCollection.InsertOneAsync(resistor, cancellationToken: token);

            return resistor;
        }

        public async Task DeleteResistorAsync(string id, CancellationToken token)
        {
            await this.resistorsCollection.DeleteOneAsync(resistor => resistor.Id == id, token);
        }

        public async Task<Resistors.Resistor> GetResistorAsync(string id, CancellationToken token)
        {
            var resistor = await this.resistorsCollection
                .Find(it => it.Id == id)
                .FirstOrDefaultAsync(token)
                .ConfigureAwait(false);

            if (resistor is null)
            {
                throw new ResistorNotFoundException(id);
            }

            return resistor;
        }

        public async Task<List<Resistors.Resistor>> SearchResisrosAsync(Model.Resistors.ResistorSearchInfo searchInfo, CancellationToken token)
        {
            var builder = Builders<Model.Resistors.Resistor>.Filter;
            var filter = builder.Empty;

            if (searchInfo.Resistance != null)
            {
                filter &= builder.Eq(resistor => resistor.Resistance, searchInfo.Resistance);
            }

            if (searchInfo.MaxAccuracy != null)
            {
                filter &= builder.Lte(resistor => resistor.Accuracy, searchInfo.MaxAccuracy);
            }

            if (searchInfo.MinPower != null)
            {
                filter &= builder.Gte(resistor => resistor.Power, searchInfo.MinPower);
            }

            if (searchInfo.MinQuantity != null)
            {
                filter &= builder.Gte(resistor => resistor.Quantity, searchInfo.MinQuantity);
            }

            if (!string.IsNullOrEmpty(searchInfo.Material))
            {
                filter &= builder.Eq(resistor => resistor.Material, searchInfo.Material);
            }

            if (!string.IsNullOrEmpty(searchInfo.Manufacturer))
            {
                filter &= builder.Eq(resistor => resistor.Manufacturer, searchInfo.Manufacturer);
            }

            var resistorsCursor = await this.resistorsCollection.FindAsync(filter);
            var resistors = await resistorsCursor
                .ToListAsync(token);
            var resistorsList = resistors
                .Skip(searchInfo.Offset ?? 0)
                .Take(searchInfo.Limit ?? 20)
                .ToList();
            return resistorsList;
        }

        public async Task UpdateResistorAsync(string id, Model.Resistors.ResistorUpdateInfo updateInfo, CancellationToken token)
        {
            var updates = new List<UpdateDefinition<Model.Resistors.Resistor>>();

            if (updateInfo.Resistance != null)
            {
                updates.Add(Builders<Model.Resistors.Resistor>.Update.Set(r => r.Resistance, updateInfo.Resistance));
            }

            if (updateInfo.Accuracy != null)
            {
                updates.Add(Builders<Model.Resistors.Resistor>.Update.Set(r => r.Accuracy, updateInfo.Accuracy));
            }

            if (updateInfo.Power != null)
            {
                updates.Add(Builders<Model.Resistors.Resistor>.Update.Set(r => r.Power, updateInfo.Power));
            }

            if (updateInfo.Quantity != null)
            {
                updates.Add(Builders<Model.Resistors.Resistor>.Update.Set(r => r.Quantity, updateInfo.Quantity));
            }

            if (!string.IsNullOrEmpty(updateInfo.Material))
            {
                updates.Add(Builders<Model.Resistors.Resistor>.Update.Set(r => r.Material, updateInfo.Material));
            }

            if (!string.IsNullOrEmpty(updateInfo.Manufacturer))
            {
                updates.Add(Builders<Model.Resistors.Resistor>.Update.Set(r => r.Manufacturer, updateInfo.Manufacturer));
            }

            var update = Builders<Model.Resistors.Resistor>.Update.Combine(updates);
            var updateResult = await this.resistorsCollection
                .UpdateOneAsync(it => it.Id == id, update, cancellationToken: token)
                .ConfigureAwait(false);

            if (updateResult.ModifiedCount == 0)
            {
                throw new ResistorNotFoundException(id);
            }
        }
    }
}
