using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Rainbowcat_web_1.Data;
using Rainbowcat_web_1.Models;

namespace Rainbowcat_web_1.Controllers
{
    public class IngredientController : Controller
    {
        private Repository<Ingredient> ingredient;

        public IngredientController(ApplicationDbContext context)
        {
            this.ingredient = new Repository<Ingredient>(context);
        }

        public async Task<IActionResult> Index()
        {
            return View(await ingredient.GetAllAsync());
        }

        public async Task<IActionResult> Details(int id)

        {
            return View(await ingredient.GetByIdAsync(id,new QueryOption<Ingredient>()));
        }
    }
}
