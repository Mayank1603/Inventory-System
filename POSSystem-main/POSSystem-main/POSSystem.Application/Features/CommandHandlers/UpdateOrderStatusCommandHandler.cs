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
    public class UpdateOrderStatusCommandHandler:IRequestHandler<UpdateOrderStatusCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository orderRepository;
        public UpdateOrderStatusCommandHandler(IMapper mapper, IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
            this._mapper = mapper;
        }
        public async Task<bool> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {
            var existingStatusDetails = await orderRepository.GetByIdAsync(new Order(), request.Id);
            if (existingStatusDetails == null)
            {
                return false;
            }

            var orderStatusToUpdate = _mapper.Map<Order>(request);
            var result = await orderRepository.UpdateAsync(orderStatusToUpdate);
            return result;
        }
    }
}
