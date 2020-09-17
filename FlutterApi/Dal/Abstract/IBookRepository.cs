using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Abstract
{
    public interface IBookRepository : IGenericRepository<Books>
    {
        List<Books> GetMostPopular();
        List<Books> GetMostSold();
        List<Books> GetBookWithCategory(int categoryId);
        List<Books> SearchBook(string name);
        Books GetRandomBook();
        Books GetBookbyId(int userId, int bookIdId);
        Books GetBookWithISBN(int userId, string ISBNNumber);
        int MakeComment(int bookId, int userId, string comments, double starCount);
        bool RemoveComment(int commentId);
        bool ChangeComment(int commentId, string comments, double starCount);
        int addBook(Books book);
        bool deleteBook(int bookId);
    }
}
