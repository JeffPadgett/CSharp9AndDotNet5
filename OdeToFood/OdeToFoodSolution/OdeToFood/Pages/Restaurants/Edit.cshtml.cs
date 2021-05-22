using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private IHtmlHelper _htmlHelper;
        private IRestaurantData _restaurantData;

        [BindProperty]//only binds on post
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
            _restaurantData = restaurantData;
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
            if(restaurantId.HasValue)
            {
                Restaurant = _restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }


            if(Restaurant == null)
            {
                RedirectToPage("NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Cuisines = _htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                _restaurantData.Update(Restaurant);
            }
            else
            {
                _restaurantData.Add(Restaurant);
            }
            _restaurantData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage($"./Detail", new { restaurantId = Restaurant.Id }); //POST REDIRECT GET pattern. PRG
        }
    }
}