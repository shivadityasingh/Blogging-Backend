using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blogging_Backend
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly BlogContext _blogContext;

        public PostsController(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        // GET: api/<PostsController>
        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            var posts = await _blogContext.Posts.ToListAsync();
            return Ok(posts);
        }

        // POST api/<PostsController>
        [HttpPost]
        public async Task<IActionResult> PostBlog([FromBody] Post post)
        {
            post.CreatedTime = DateTime.Now;
            _blogContext.Posts.Add(post);
            await _blogContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBlogs), new { Id = post.Id }, post);
        }

        // DELETE api/<PostsController>/id

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var postToBeDeleted = await _blogContext.Posts.FindAsync(id);
            if (postToBeDeleted == null)
                return NotFound();
            _blogContext.Posts.Remove(postToBeDeleted);
            await _blogContext.SaveChangesAsync();
            return Ok();
        }
    }
}
