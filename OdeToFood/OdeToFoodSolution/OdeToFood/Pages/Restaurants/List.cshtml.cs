using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private IConfiguration confiuration;
        private IRestaurantData restaurantData;

        public ListModel(IConfiguration configuration, IRestaurantData restaurantData)
        {
            this.confiuration = configuration;
            this.restaurantData = restaurantData;
        }

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        public void OnGet()
        {
            Message = confiuration["Message"];
            Restaurants = restaurantData.GetAll();
        }
    }
}
