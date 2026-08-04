using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;
using Restaurants.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Restaurants.Infrastructure.Repositories
{
    internal class DishesRepository(RestaurantsDbContext dbContext) : IDishesRepository
    {
        public async Task<int> Create(Dish entity)
        {
            dbContext.Dishes.Add(entity);
            await dbContext.SaveChangesAsync();
            return entity.id;
        }

        public async Task Delete(IEnumerable<Dish> entities)
        {
            dbContext.Dishes.RemoveRange(entities);
            await dbContext.SaveChangesAsync();
        }

        //Task<Restaurant> GetByNameAsync(string name);
        public async Task<Dish> GetNameAsync(string name)
        {
            var dishName = await dbContext.Dishes.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            return dishName!;
        }
    }
}
