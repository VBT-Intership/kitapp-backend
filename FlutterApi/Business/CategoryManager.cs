using Dal.AbstractInterfaces;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Bll
{
    public class CategoryManager : GenericManager<Categories>, ICategoriesService
    {
        ICategoriesRepository categoriesRepository;

        public CategoryManager(ICategoriesRepository categoriesRepository) : base(categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public List<Categories> GetCategories()
        {
            return categoriesRepository.GetCategories();
        }

        Categories GetCategoriesById(int categoryId, bool IncludeBooks)
        {
            return categoriesRepository.GetCategoriesById(categoryId, IncludeBooks);
        }

        public List<Categories> GetUserFavoriteCategories(int userId)
        {
            return categoriesRepository.GetUserFavoriteCategories(userId);
        }

        public bool MakeFavorite(int userId, int categoryId)
        {
            return categoriesRepository.MakeFavorite(userId, categoryId);
        }
        public bool RemoveFavorite(int userId, int categoryId)
        {
            return categoriesRepository.RemoveFavorite(userId, categoryId);

        }
        Categories ICategoriesService.GetCategoriesById(int categoryId, bool IncludeBooks)
        {
            throw new NotImplementedException();
        }

        public int addCategory(Categories category)
        {
            return categoriesRepository.addCategory(category);
        }

        public bool deleteCategory(int categoryId)
        {
            return categoriesRepository.deleteCategory(categoryId);
        }
    }
}
