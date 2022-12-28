using ComputerRepair.BusinessLogic.Exceptions;
using ComputerRepair.BusinessLogic.HelpersFunctions;
using ComputerRepair.BusinessLogic.Interfaces;
using ComputerRepair.DataAccess.Interfaces;
using ComputerRepair.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerRepair.BusinessLogic.RepositoryServices
{
    public class PayementService: IPayementService
    {
        private readonly IPayementRepository _payementRepository;
        private readonly IOrderRepository _orderRepository;
        public PayementService(IPayementRepository payementRepository, IOrderRepository orderRepository)
        {
            _payementRepository = payementRepository;
            _orderRepository = orderRepository;
        }

        public async Task<Payement> AddAsync(Payement payement)
        {

            var payementLooked = await _payementRepository.GetByIdAsync(payement.PayementId);
            var orderLooked = await _orderRepository.GetByIdAsync(payement.PayementId);

            payementLooked.PayementDate = PayementHelperFunctions.SetPayementDate();
            payement.PayementDate = payementLooked.PayementDate;

            payementLooked.PayementStatus = PayementHelperFunctions.SetPayementStatus();
            payement.PayementStatus = payementLooked.PayementStatus;

            payementLooked.Amount = orderLooked.TotalPrice;
            payement.Amount = payementLooked.Amount;
            _payementRepository.Add(payement);

            await _payementRepository.SavechangesAsync();
            return payement;

        }

        public async Task<Payement> DeleteAsync(Payement payement)
        {
            var payementLooked = await _payementRepository.GetByIdAsync(payement.PayementId);

            if (payementLooked is null)
            {
                throw new NotFoundException("This Order has nogt been paid yet");
            }
            _payementRepository.DeleteAsync(payementLooked);
            await _payementRepository.SavechangesAsync();
            return payement;
        }

        public async Task<List<Payement>> GetAllAsync()
        {
            var payements = await _payementRepository.GetAllAsync();

            if (payements is null)
            {
                throw new NotFoundException("There are no paid order yet");
            }
            return  payements;
        }

        public async Task<Payement?> GetByIdAsync(int Id)
        {
            var payement = await _payementRepository.GetByIdAsync(Id);

            if (payement is null)
            {
                throw new NotFoundException("This order has not been paid yet");
            }

            return payement;
        }

        public Task SavechangesAsync()
        {
            return _payementRepository.SavechangesAsync();
        }

        public async Task<Payement> UpdateAsync(Payement payement)
        {
            var payementLooked = await _payementRepository.GetByIdAsync(payement.PayementId);

            if (payementLooked is null)
            {
                throw new NotFoundException("The Payement for this order has not be made yet");
            }

            payementLooked.PayementStatus = payement.PayementStatus;
            payementLooked.PayementDate = payement.PayementDate;

            _payementRepository.UpdateAsync(payementLooked);
            await _payementRepository.SavechangesAsync();

            return payement;
        }
    }
}
