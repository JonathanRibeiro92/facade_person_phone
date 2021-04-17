using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPhoneNumberTypeRepository: IRepository<PhoneNumberType>
    {
        Task<IEnumerable<PersonAggregate.PhoneNumberType>> FindAllAsync();
    }
}
