namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public int AuthorId { get; set; }
    public required string Title { get; set; }
    public DateTime Created_At { get; set; }
    public DateTime Updated_At { get; set; }

    public DateTime Published { get; set;}
    public string Content { get; set; }
}
