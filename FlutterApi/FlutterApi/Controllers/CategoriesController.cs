using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlutterApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        ICategoriesService categoriesContext;
        public CategoriesController(ICategoriesService category)
        {
            this.categoriesContext = category;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            var categories = categoriesContext.GetCategories();
            return Ok(categories);
        }
        [HttpGet("{userId}/{includeBooks}")]
        public IActionResult GetCategoriesById(int userId,bool includeBooks)
        {
            var categories = categoriesContext.GetCategoriesById(userId,includeBooks);
            return Ok(categories);
        }
        [HttpGet("{userId}")]
        public IActionResult GetUserFavoriteCategories(int userId)
        {
            var categories = categoriesContext.GetUserFavoriteCategories(userId);
            return Ok(categories);
        }
        [HttpGet("{userId}/{categoryId}")]
        public IActionResult MakeFavoriteCategory(int userId,int categoryId)
        {
            var categories = categoriesContext.MakeFavorite(userId,categoryId);
            return Ok(categories);
        }
        [HttpGet("{userId}/{categoryId}")]
        public IActionResult RemoveFavoriteCategory(int userId, int categoryId)
        {
            var categories = categoriesContext.RemoveFavorite(userId, categoryId);
            return Ok(categories);
        }
        [HttpPost]
        public IActionResult AddCategory(Categories category)
        {
            var result = categoriesContext.addCategory(category);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var result = categoriesContext.deleteCategory(categoryId);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult EmptyCategory()
        {
            Categories categories = new Categories() { };
            return Ok(categories);
        }

    }
}