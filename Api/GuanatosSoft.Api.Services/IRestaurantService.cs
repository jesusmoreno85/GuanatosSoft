using GuanatosSoft.Api.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuanatosSoft.Api.Services
{
    public interface IRestaurantService
    {
        Task<IEnumerable<Restaurant>> SearchPattern(string text);
    }
}
