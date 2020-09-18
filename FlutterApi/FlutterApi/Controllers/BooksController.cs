using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dal.Concrete.EntityFramework.Context;
using Entities.Models;
using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace FlutterApi.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class BooksController : Controller
    {
        IBookService bookContext;

        public static string lastText="test";
        public BooksController(IBookService book)
        {
            this.bookContext = book;
        }
        [HttpGet("{categoryId}")]
        public IActionResult GetBookwithCategoryId(int categoryId)
        {
            var product = bookContext.GetBookWithCategory(categoryId);
            return Ok(product);
        }
        [HttpGet("{userId}/{ISBNNumber}")]
        public IActionResult GetBookwithISBN(int userId, string ISBNNumber)
        {
            var product = bookContext.GetBookWithISBN(userId,ISBNNumber);
            return Ok(product);
        }
        [HttpGet("{userId}/{bookId}")]
        public IActionResult GetBook(int userId,int bookId)
        {
            var product = bookContext.GetBookbyId(userId, bookId);
            return Ok(product);
        }
        [HttpGet("")]
        public IActionResult GetMostPopular()
        {
            return Ok(bookContext.GetMostPopular());
        }
        [HttpGet("{bookName}")]
        public IActionResult SearchBook(string bookName)
        {
            var product = bookContext.SearchBook(bookName);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult MakeComment(object comments)
        {
            var datas = JsonConvert.DeserializeObject<Dictionary<string, object>>(comments.ToString());
            var product = bookContext.MakeComment(Convert.ToInt32(datas["bookId"]), Convert.ToInt32(datas["userId"]), datas["comment"].ToString(), Convert.ToDouble(datas["userStarCount"]));
            return Ok(product);
        }
        [HttpPost]
        public IActionResult ChangeComment(object comments)
        {
            var datas = JsonConvert.DeserializeObject<Dictionary<string, object>>(comments.ToString());
            var product = bookContext.ChangeComment(Convert.ToInt32(datas["commentId"]),  datas["comment"].ToString(), Convert.ToDouble(datas["userStarCount"]));
            return Ok(product);
        }
        [HttpPost]
        public IActionResult RemoveComment(int commentId)
        {
            var product = bookContext.RemoveComment(commentId);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult AddBook(Books book)
        {
            var result = bookContext.addBook(book);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult DeleteBook(int bookId)
        {
            var result = bookContext.deleteBook(bookId);
            return Ok(result);
        }
        [HttpGet]
        public IActionResult EmptyBooks()
        {
            Books books = new Books() { Comments = new List<Comments>(){ new Comments() { } },UserStars= new List<Stars>() { new Stars() { } } };
            return Ok(books);
        }
        [HttpGet]
        public IActionResult getresult()
        {
            return Ok(lastText);
        }
    }
}