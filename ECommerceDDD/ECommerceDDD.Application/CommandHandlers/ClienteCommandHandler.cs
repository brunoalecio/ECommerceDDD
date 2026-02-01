using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ECommerceDDD.Application.Command;
using ECommerceDDD.Domain.Entities;
using ECommerceDDD.Domain.Events;
using ECommerceDDD.Domain.Interfaces;
using ECommerceDDD.Domain.ValueObjects;
using MediatR;
using ECommerceDDD.Domain.EventSourcing;

namespace ECommerceDDD.Application.CommandHandlers
{
    public class ClienteCommandHandler : 
        IRequestHandler<RegisterNewClienteCommand, bool>,
        IRequestHandler<UpdateClienteCommand, bool>,
        IRequestHandler<RemoveClienteCommand, bool>
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly IEventStoreRepository _eventStoreRepository;

        public ClienteCommandHandler(
            IClienteRepository clienteRepository,
            IUnitOfWork unitOfWork,
            IMediator mediator,
            IEventStoreRepository eventStoreRepository)
        {
            _clienteRepository = clienteRepository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }

        // CREATE
        public async Task<bool> Handle(RegisterNewClienteCommand request, CancellationToken cancellationToken)
        {
            var email = new Email(request.Email);
            var cliente = new Cliente(request.Nome, email, request.DataNascimento);

            await _clienteRepository.AddAsync(cliente);

            var success = await _unitOfWork.CommitAsync();

            if (!success) return false;

            var evento = new ClienteRegistradoEvent(
                cliente.Id,
                cliente.Nome,
                cliente.Email.Address,
                cliente.DataNascimento
            );

            _eventStoreRepository.Save(evento);

            await _mediator.Publish(evento, cancellationToken);

            return true;
        }

        // UPDATE
        public async Task<bool> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null) return false;

            cliente.DefinirNome(request.Nome);
            cliente.DefinirEmail(new Email(request.Email));
            cliente.DefinirDataNascimento(request.DataNascimento);

            _clienteRepository.Update(cliente);

            return await _unitOfWork.CommitAsync();
        }

        // DELETE
        public async Task<bool> Handle(RemoveClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);
            if (cliente == null) return false;

            _clienteRepository.Remove(cliente);

            return await _unitOfWork.CommitAsync();
        }
    }
}

