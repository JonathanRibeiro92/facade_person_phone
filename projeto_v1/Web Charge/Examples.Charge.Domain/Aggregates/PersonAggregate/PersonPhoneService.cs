using System;
using Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate
{
    public class PersonPhoneService : IPersonPhoneService
    {
        private readonly IPersonPhoneRepository _personPhoneRepository;
        public PersonPhoneService(IPersonPhoneRepository personPhoneRepository)
        {
            _personPhoneRepository = personPhoneRepository;
        }

        public async Task<List<PersonPhone>> FindAllAsync() => (await _personPhoneRepository.FindAllAsync()).ToList();
        public async Task<PersonPhone> Find(int id)
        {
            return await _personPhoneRepository.FindById(id);
        }

        public async Task<PersonPhone> Find(Expression<Func<PersonPhone, bool>> predicate)
        {
            return await _personPhoneRepository.FirstOrDefaultAsync(predicate);
        }

        public async Task Add(PersonPhone personPhone)
        {
            await _personPhoneRepository.Add(personPhone);
        }

        public async Task Update(PersonPhone personPhone)
        {
            await _personPhoneRepository.Update(personPhone);
        }

        public async Task Remove(PersonPhone personPhone)
        {
            await _personPhoneRepository.Remove(personPhone);
        }

        public void Dispose()
        {
            _personPhoneRepository?.Dispose();
        }
    }
}
