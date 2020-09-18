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
            try
            {
                Books book = context.Books.Where(x => x.bookId == bookId).Include(x => x.Comments).FirstOrDefault(); 
                if (userId != 0)
                {
                    book.IsUserFavorite = context.UserFavorites.FirstOrDefault(x => x.bookId == bookId && x.userId == userId) == null ? false : true;
                    Stars starcount = context.Stars.FirstOrDefault(x => x.bookId == bookId && x.userId == userId);
                    book.UserStarCount = starcount == null ? 0 : starcount.StarCount;
                    foreach (var item in book.Comments)
                    {
                        item.userName = context.Users.FirstOrDefault(x => x.Id == item.usersId).Name;
                    }
                }
                return book;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }

        public List<Books> GetBookWithCategory(int categoryId)
        {
            try
            {
                return context.Books.Where(x => x.categoryId == categoryId).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Books GetBookWithISBN(int userId, string ISBNNumber)
        {
            try
            {
                return context.Books.FirstOrDefault(x => x.Isbn == ISBNNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            try
            {
                Comments comment = new Comments()
                {
                    booksId = bookId,
                    usersId = userId,
                    comment = comments,
                    IsActive = true,
                    PublisDate = DateTime.Now,
                    UserStarCount = starCount
                };
                context.Comments.Add(comment);
                context.SaveChanges();
                return comment.CommentId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ChangeComment(int commentId, string comments, double starCount)
        {
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool RemoveComment(int commentId)
        {
            try
            {
                context.Comments.Remove(context.Comments.FirstOrDefault(x => x.CommentId == commentId));
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Books> SearchBook(string name)
        {
            try
            {
                return context.Books.Where(x => x.BookName.Contains(name)).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int addBook(Books book)
        {
            try
            {
                context.Books.Add(book);
                context.SaveChanges();
                return book.bookId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        public bool deleteBook(int bookId)
        {
            try
            {
                context.Books.Remove(context.Books.FirstOrDefault(x => x.bookId == bookId));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
