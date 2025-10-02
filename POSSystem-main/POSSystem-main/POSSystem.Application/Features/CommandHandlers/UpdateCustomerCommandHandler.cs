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
    public class UpdateCustomerCommandHandler:IRequestHandler<UpdateCustomerCommand, bool>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerCommandHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
            this._mapper = mapper;
        }
        public async Task<bool> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var existingCustomerDetails = await _customerRepository.GetByIdAsync(new Customer(), request.Id);
            if (existingCustomerDetails == null)
            {
                return false;
            }

            var customerToUpdate = _mapper.Map<Customer>(request);
            var result = await _customerRepository.UpdateAsync(customerToUpdate);
            return result;
        }
    }
}
