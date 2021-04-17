using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneService : IDisposable
    {
        Task<List<PersonPhone>> FindAllAsync();
        Task<PersonPhone> Find(int id);
        Task Add(PersonPhone personPhone);
        Task Update(PersonPhone personPhone);
        Task Remove(PersonPhone personPhone);
        Task<PersonPhone> Find(Expression<Func<PersonPhone, bool>> predicate);
    }
}
