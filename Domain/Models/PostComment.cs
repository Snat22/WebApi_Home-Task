namespace Domain.Models;

public class PostComment
{
    public int Id { get; set; }
    public int Post_Id { get; set; }
    public required string Title { get; set; }
    public DateTime Published { get; set; }
}
