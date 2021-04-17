using System.Collections.Generic;
using System.Threading.Tasks;

namespace Examples.Charge.Domain.Aggregates.PersonAggregate.Interfaces
{
    public interface IPersonPhoneRepository : IRepository<PersonPhone>
    {
        Task<IEnumerable<PersonAggregate.PersonPhone>> FindAllAsync();
    }
}
