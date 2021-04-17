using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Examples.Charge.Domain.Aggregates.ExampleAggregate.Interfaces;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PhoneNumberTypeService : IPhoneNumberTypeService
    {
        private readonly IPhoneNumberTypeRepository _phoneNumberTypeRepository;
        public PhoneNumberTypeService(IPhoneNumberTypeRepository phoneNumberTypeRepository)
        {
            _phoneNumberTypeRepository = phoneNumberTypeRepository;

        }

        public async Task<List<PhoneNumberType>> FindAllAsync() => (await _phoneNumberTypeRepository.FindAllAsync()).ToList();

        public void Dispose()
        {
            _phoneNumberTypeRepository?.Dispose();
        }

        public async Task<PhoneNumberType> Find(int id)
        {
            return await _phoneNumberTypeRepository.FindById(id);
        }

        public async Task<PhoneNumberType> Find(Expression<Func<PhoneNumberType, bool>> predicate)
        {
            return await _phoneNumberTypeRepository.FirstOrDefaultAsync(predicate);
        }
    }
}
