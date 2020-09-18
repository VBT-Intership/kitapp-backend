using Dal.Abstract;
using Entities.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiparisTakip.Bll
{
    public class BookManager : GenericManager<Books>, IBookService
    {
        IBookRepository bookRepository;

        public BookManager(IBookRepository bookRepository) : base(bookRepository)
        {
            this.bookRepository = bookRepository;
        }

       
        public Books GetBookbyId(int userId, int bookId)
        {
            return bookRepository.GetBookbyId(userId, bookId);
        }

        public List<Books> GetBookWithCategory(int categoryId)
        {
            return bookRepository.GetBookWithCategory(categoryId);
        }

        public Books GetBookWithISBN(int userId, string ISBNNumber)
        {
            return bookRepository.GetBookWithISBN(userId, ISBNNumber);
        }

        public List<Books> GetMostPopular()
        {
            return bookRepository.GetMostPopular();
        }

        public List<Books> GetMostSold()
        {
            return bookRepository.GetMostSold();
        }

        public Books GetRandomBook()
        {
            return bookRepository.GetRandomBook();
        }

        public int MakeComment(int bookId, int userId, string comments, double starCount)
        {
            return bookRepository.MakeComment(bookId,userId,comments, starCount);
        }
        public bool ChangeComment(int commentId, string comments, double starCount)
        {
           return bookRepository.ChangeComment(commentId, comments, starCount);
        }

        public bool RemoveComment(int commentId)
        {
            return bookRepository.RemoveComment(commentId);

        }

        public List<Books> SearchBook(string name)
        {
            return bookRepository.SearchBook(name);
        }

        public int addBook(Books book)
        {
            return bookRepository.addBook(book);
        }

        public bool deleteBook(int bookId)
        {
            return bookRepository.deleteBook(bookId);
        }
    }
}
