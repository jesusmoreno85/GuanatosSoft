using GuanatosSoft.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuanatosSoft.Api.Data.Repositories
{
    public interface IRepositoryRestaurant
    {
        Task<IEnumerable<Restaurant>> SearchPattern(string text);
    }
}
