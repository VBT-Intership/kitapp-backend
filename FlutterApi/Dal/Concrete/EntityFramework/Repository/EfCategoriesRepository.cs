using Dal.AbstractInterfaces;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Concrete.EntityFramework.Repository
{
    public class EfCategoriesRepository : EfGenericRepository<Categories>, ICategoriesRepository
    {
        public EfCategoriesRepository():base()
        {
            
        }

        public int addCategory(Categories category)
        {
            context.Categories.Add(category);
            context.SaveChanges();
            return category.Id;
        }

        public bool deleteCategory(int categoryId)
        {
            context.Categories.Remove(context.Categories.FirstOrDefault(x => x.Id == categoryId));
            return true;
        }

        public List<Categories> GetCategories()
        {
            return context.Categories.Include(x=>x.Books).ToList();
        }

        public Categories GetCategoriesById(int categoryId,bool IncludeBooks)
        {
            if(IncludeBooks)
                return context.Categories.Where(x => x.Id == categoryId).Include(x=>x.Books).FirstOrDefault();
            else
                return context.Categories.Where(x => x.Id == categoryId).FirstOrDefault();
        }

        public List<Categories> GetUserFavoriteCategories(int userId)
        {
            return context.UserFavoritesCategories.Where(x => x.userId == userId).Include(x => x.Category).Select(x => x.Category).ToList();
        }

        public bool MakeFavorite(int userId, int categoryId)
        {
            context.UserFavoritesCategories.Add(new UserFavoritesCategories() { categoryId = categoryId, userId = userId });
            return Convert.ToBoolean(context.SaveChanges());
        }

        public bool RemoveFavorite(int userId, int categoryId)
        {
            context.UserFavoritesCategories.Remove(context.UserFavoritesCategories.FirstOrDefault(x => x.categoryId == categoryId && x.userId==userId));
            return Convert.ToBoolean(context.SaveChanges());
        }
    }
}
