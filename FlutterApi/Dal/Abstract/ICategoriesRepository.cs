using Dal.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.AbstractInterfaces
{
    public interface ICategoriesRepository : IGenericRepository<Categories>
    {
        List<Categories> GetCategories();
        Categories GetCategoriesById(int categoryId,bool IncludeBooks);
        List<Categories> GetUserFavoriteCategories(int userId);
        bool MakeFavorite(int userId, int categoryId);
        bool RemoveFavorite(int userId, int categoryId);
        int addCategory(Categories category);
        bool deleteCategory(int categoryId);
    }
}
