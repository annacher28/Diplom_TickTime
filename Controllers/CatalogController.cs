using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WatchStore.Data;
using WatchStore.Helpers; // для работы с сессией

namespace WatchStore.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Отображение списка товаров
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        // Детальная страница товара
        public async Task<IActionResult> Details(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        // Добавление товара в избранное (гость)
        [HttpPost]
        public IActionResult AddToFavorite(int productId)
        {
            var favoriteIds = HttpContext.Session.GetObjectFromJson<List<int>>("FavoriteIds") ?? new List<int>();
            if (!favoriteIds.Contains(productId))
            {
                favoriteIds.Add(productId);
                HttpContext.Session.SetObjectAsJson("FavoriteIds", favoriteIds);
            }
            return Ok();
        }

        // Удаление из избранного (гость)
        [HttpPost]
        public IActionResult RemoveFromFavorite(int productId)
        {
            var favoriteIds = HttpContext.Session.GetObjectFromJson<List<int>>("FavoriteIds") ?? new List<int>();
            if (favoriteIds.Contains(productId))
            {
                favoriteIds.Remove(productId);
                HttpContext.Session.SetObjectAsJson("FavoriteIds", favoriteIds);
            }
            return Ok();
        }

        // Страница избранного для гостя
        public IActionResult Favorites()
        {
            var favoriteIds = HttpContext.Session.GetObjectFromJson<List<int>>("FavoriteIds") ?? new List<int>();
            var products = _context.Products.Where(p => favoriteIds.Contains(p.Id)).ToList();
            return View(products);
        }
    }
}