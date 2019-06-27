using GuanatosSoft.Api.Data.Entities;
using GuanatosSoft.Api.Data.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GuanatosSoft.Api.Services
{
    public class RestaurantService : IRestaurantService // : Still need a base service and common interface for this service
    {
        private IRepositoryRestaurant repository; 

        public RestaurantService(IRepositoryRestaurant repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Search for a text pattern in Name or Description fields
        /// </summary>
        /// <param name="text">Text value to look for</param>
        /// <returns>List of restaurants</returns>
        public Task<IEnumerable<Restaurant>> SearchPattern(string text)
        {
            // We could need a data transfer object not to send db models to the front end
            // If needed do some other logic that could involve other services or repositories
            return this.repository.SearchPattern(text);
        }
    }
}
