﻿using Ametista.Core;
using Ametista.Core.Entity;
using Ametista.Core.Repository;
using System;
using Ametista.Application.Events;
using System.Threading.Tasks;

namespace Ametista.Application.Commands
{
    public class CreateGemstoneCommandHandler : ICommandHandler<CreateGemstoneCommand, CreateGemstoneCommandResult>
    {
        private readonly IGemstoneWriteOnlyRepository _writeOnlyRepository;
        private readonly IEventBus _eventBus;

        public CreateGemstoneCommandHandler(IGemstoneWriteOnlyRepository writeOnlyRepository, IEventBus eventBus)
        {
            _writeOnlyRepository = writeOnlyRepository ?? throw new ArgumentNullException(nameof(writeOnlyRepository));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task<CreateGemstoneCommandResult> Handle(CreateGemstoneCommand command)
        {
            Gemstone gemstone = Gemstone.CreateNew(command.Name, command.ScientificName, command.Price);
            MaterializeGemstoneEvent materializeGemstoneEvent = new MaterializeGemstoneEvent(gemstone.Id);

            await _writeOnlyRepository.Add(gemstone);
            await _eventBus.Publish(materializeGemstoneEvent);

            return new CreateGemstoneCommandResult() { Id = gemstone.Id };
        }
    }
}
