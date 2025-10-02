using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using POSSystem.Application.Features.Commands;
using POSSystem.Application.Interfaces;
using POSSystem.Domain.Entities;

namespace POSSystem.Application.Features.CommandHandlers
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        public AddOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request);
            return await _orderRepository.CreateAsync(order);
        }
    }
}
