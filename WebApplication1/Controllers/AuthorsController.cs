﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;
using WebApplication1.Classes;

namespace WebApplication1.Controllers
{
    [Route("/api")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly AuthorService _authorService;
        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [Route("[controller]")]
        public IActionResult GetAuthors()
        {
            var authors = _authorService.GetAllAuthors();
            if (authors == null)
            {
                return NotFound($"Authors do not exist.");
            }
            return Ok(authors);
        }

        [HttpGet]
        [Route("[controller]/{id}")]
        public ActionResult<Author> GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
            {
                return NotFound($"Author with id {id} does not exist.");
            }
            return Ok(author);
        }

        [HttpPost]
        [Route("[controller]")]
        public ActionResult PostAuthor(Author author)
        {
            try
            {
                _authorService.AddAuthor(author);
                return Created("New author added successfully.", author);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("[controller]/{id}")]
        public ActionResult DeleteAuthor(int id)
        {
            try
            {
                _authorService.DeleteAuthor(id);
                return Ok("Deleted author successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
