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
        [HttpGet("{bookname}")]
        public IActionResult SearchBook(string bookName)
        {
            var product = bookContext.SearchBook(bookName);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult MakeComment(int userId,int bookId,string comment,double starCount)
        {
            var product = bookContext.MakeComment(userId,bookId,comment,starCount);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult ChangeComment(int commentId,string comment, double starCount)
        {
            var product = bookContext.ChangeComment(commentId, comment, starCount);
            return Ok(product);
        }
        [HttpPost]
        public IActionResult RemoveComment(int commentId)
        {
            var product = bookContext.RemoveComment(commentId);
            return Ok(product);
        }
    }
}