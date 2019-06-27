using GuanatosSoft.Api.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuanatosSoft.Api.Data.Repositories
{
    public class RestaurantRepository : RepositoryBase<Restaurant>, IRepositoryRestaurant
    {
        public RestaurantRepository(guanatossoftdbContext dbContext)
                : base(dbContext)
        {
            
        }

        public async Task<IEnumerable<Restaurant>> SearchPattern(string text)
        {
            return await this.dbSet.Where((x) =>
                x.Name.Contains(text, StringComparison.InvariantCultureIgnoreCase)
                || x.Description.Contains(text, StringComparison.InvariantCultureIgnoreCase))
                .ToListAsync();
        }
    }
}
