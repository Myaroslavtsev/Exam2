using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Model;
using AutoMapper;
using System.ComponentModel.DataAnnotations;

namespace Exam2_webapp.Resistors
{
    public sealed class ResistorsService
    {
        private readonly IResistorsRepository resistorsRepository;
        private readonly IMapper mapper;

        public ResistorsService(IResistorsRepository resistorsRepository, IMapper mapper)
        {
            this.resistorsRepository = resistorsRepository ?? throw new ArgumentNullException(nameof(resistorsRepository));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<View.Resistors.Resistor> CreateResistorAsync(
            View.Resistors.ResistorCreateInfo viewCreateInfo,
            CancellationToken token)
        {
            var modelCreateInfo = this.mapper.Map< View.Resistors.ResistorCreateInfo, Model.Resistors.ResistorCreateInfo>(viewCreateInfo);
            ValidateOnCreate(modelCreateInfo);
            var modelResistor = await this.resistorsRepository.CreateResistorAsync(modelCreateInfo, token);

            var viewResistor = this.mapper.Map<Model.Resistors.Resistor, View.Resistors.Resistor>(modelResistor);
            return viewResistor;
        }

        private static void ValidateOnCreate(Model.Resistors.ResistorCreateInfo createInfo)
        {
            if (createInfo.Accuracy != null && 
                (createInfo.Accuracy <= 0 || createInfo.Accuracy >= 1))
                throw new ValidationException("Accuracy value out of range");

            if (createInfo.Power <= 0)
                throw new ValidationException("Power value must be positive");

            if (createInfo.Resistance <= 0)
                throw new ValidationException("Resistance value must be positive");
        }

        public async Task<View.Resistors.Resistor> GetResistorAsync(string id, CancellationToken token)
        {
            var modelResistor = await this.resistorsRepository.GetResistorAsync(id, token);

            var viewResistor = this.mapper.Map<Model.Resistors.Resistor, View.Resistors.Resistor>(modelResistor);
            return viewResistor;
        }

    }
}
