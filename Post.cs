using System.ComponentModel.DataAnnotations;

namespace Blogging_Backend
{
    public class Post
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Blog { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
