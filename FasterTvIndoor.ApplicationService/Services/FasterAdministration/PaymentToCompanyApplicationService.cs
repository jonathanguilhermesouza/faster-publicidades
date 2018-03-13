using FasterTvIndoor.Domain.FasterAdministration.Commands.PaymentToCompanyCommands;
using FasterTvIndoor.Domain.FasterAdministration.Entities;
using FasterTvIndoor.Domain.FasterAdministration.Repositories;
using FasterTvIndoor.Domain.FasterAdministration.Services;
using FasterTvIndoor.Infrastructure.Persistence;
using System.Collections.Generic;
using System;

namespace FasterTvIndoor.ApplicationService.Services.FasterAdministration
{
    public class PaymentToCompanyApplicationService : ApplicationService, IPaymentToCompanyApplicationService
    {
        private IPaymentToCompanyRepository _repository;

        public PaymentToCompanyApplicationService(IPaymentToCompanyRepository repository, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            _repository = repository;
        }

        public List<PaymentToCompany> GetAll()
        {
            return _repository.GetAll();
        }

        public List<PaymentToCompany> GetByRange(int skip, int take, string word)
        {
            return _repository.GetByRange(skip, take, word);
        }

        public List<PaymentToCompany> GetByRangeCompany(int skip, int take, int id)
        {
            return _repository
                .GetByRangeCompany(skip, take, id);
        }

        public PaymentToCompany GetById(int id)
        {
            return _repository.GetById(id);
        }

        public PaymentToCompany GetByIdCompany(int id)
        {
            return _repository.GetByIdCompany(id);
        }

        public PaymentToCompany Create(CreatePaymentToCompanyCommand command)
        {
            var payment = new PaymentToCompany(command.IdCompany, command.Value,command.DatePayment, command.Description);
            payment.Create();
            _repository.Create(payment);

            if (Commit())
                return payment;

            return null;
        }

        public PaymentToCompany Update(UpdatePaymentToCompanyCommand command)
        {
            var payment = _repository.GetById(command.IdPaymentToCompany);
            payment.Update(command);
            _repository.Update(payment);

            if (Commit())
                return payment;

            return null;
        }

        public PaymentToCompany Delete()
        {
            throw new System.NotImplementedException();
        }

        public int GetCount(string word)
        {
            return _repository.GetCount(word);
        }

        public int GetCountCompany(int id)
        {
            return _repository.GetCountCompany(id);
        }

        public PaymentToCompany Delete(DeletePaymentToCompanyCommand command)
        {
            var payment = _repository.GetById(command.IdPaymentToCompany);
            _repository.Delete(payment);

            if (Commit())
                return payment;

            return null;
        }
    }
}
