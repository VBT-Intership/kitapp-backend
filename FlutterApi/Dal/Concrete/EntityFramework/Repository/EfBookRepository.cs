using Dal.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Dal.Concrete.EntityFramework.Repository
{
    public class EfBookRepository : EfGenericRepository<Books>, IBookRepository
    {
        public EfBookRepository():base()
        {
                   
        }

      
        public Books GetBookbyId(int userId, int bookId)
        {
            Books book = context.Books.FirstOrDefault(x => x.bookId == bookId);
            if (userId != 0)
            {
                book.IsUserFavorite = context.UserFavorites.FirstOrDefault(x => x.bookId == bookId && x.userId == userId) == null ? false : true;
                Stars starcount = context.Stars.FirstOrDefault(x => x.bookId == bookId && x.userId == userId);
                book.UserStarCount = starcount == null ? 0 : starcount.StarCount;
            }
           
            return book;
        }

        public List<Books> GetBookWithCategory(int categoryId)
        {
            return context.Books.Where(x => x.categoryId == categoryId).ToList();
        }

        public Books GetBookWithISBN(int userId, string ISBNNumber)
        {
            return context.Books.FirstOrDefault(x => x.Isbn == ISBNNumber);
        }

        public List<Books> GetMostPopular()
        {
            throw new NotImplementedException();
        }

        public List<Books> GetMostSold()
        {
            throw new NotImplementedException();
        }

        public Books GetRandomBook()
        {
            throw new NotImplementedException();
        }

        public int MakeComment(int bookId,int userId,string comments, double starCount)
        {
            Comments comment = new Comments() { 
                bookId=bookId,
                userId=userId,
                comment=comments,
                IsActive=true,
                PublisDate=DateTime.Now,
                UserStarCount=starCount
            };
            context.Comments.Add(comment);
            context.SaveChanges();
            return comment.CommentId;
        }
        public bool ChangeComment(int commentId, string comments, double starCount)
        {
            Comments comment = context.Comments.FirstOrDefault(x => x.CommentId == commentId);
            if (comment != null)
            {
                comment.comment = comments;
                comment.UserStarCount = starCount;
                context.Comments.Update(comment);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public bool RemoveComment(int commentId)
        {
            context.Comments.Remove(context.Comments.FirstOrDefault(x => x.CommentId == commentId));
            context.SaveChanges();
            return true;
        }

        public List<Books> SearchBook(string name)
        {
            return context.Books.Where(x => x.BookName.Contains(name)).ToList();
        }

        public int addBook(Books book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return book.bookId;
        }

        public bool deleteBook(int bookId)
        {
            context.Books.Remove(context.Books.FirstOrDefault(x => x.bookId == bookId));
            return true;
        }
    }
}
