using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _repositoryContext;
        public BooksController(RepositoryContext repositoryContext)
        {
            _repositoryContext= repositoryContext;
        }
       
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _repositoryContext.Books.ToList();
                return Ok(books);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name ="id")] int id)
        {
            try
            {
                //var book= _repositoryContext.Books.Find(id);
                var book = _repositoryContext.Books.Where(x=>x.Id.Equals(id)).SingleOrDefault();
                if(book is null)
                {
                    return NotFound();//404
                }
                return Ok(book);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


    }
}
