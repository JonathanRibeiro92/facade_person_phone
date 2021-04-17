using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPhoneNumberTypeService : IDisposable
    {
        Task<PhoneNumberType> Find(int id);
        Task<PhoneNumberType> Find(Expression<Func<PhoneNumberType, bool>> predicate);

    }
}
