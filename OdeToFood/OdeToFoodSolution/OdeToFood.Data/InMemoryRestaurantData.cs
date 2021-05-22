using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Jeff's Pizza", Location= "Maryland", Cuisine= CuisineType.Italian},
                new Restaurant { Id = 2, Name = "Bowl of Pho", Location= "Jacksonville", Cuisine= CuisineType.Indian},
                new Restaurant { Id = 3, Name = "Taco Land", Location= "Saint Augustine", Cuisine= CuisineType.Mexican},
                new Restaurant { Id = 4, Name = "Olive Garden", Location= "Georga", Cuisine= CuisineType.Italian}
            };
        }

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            {
                if (restaurant != null)
                {
                    restaurant.Name = updatedRestaurant.Name;
                    restaurant.Location = updatedRestaurant.Location;
                    restaurant.Cuisine = updatedRestaurant.Cuisine;
                }

                return restaurant;
            }
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

    }
}
