using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

namespace ECommerceDDD.Application.Command
{
    public class RemoveClienteCommand : IRequest<bool>
    {
        public Guid Id { get; }

        public RemoveClienteCommand(Guid id)
        {
            Id = id;
        }
    }
}

