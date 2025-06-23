public class CreatePostDto
{
	public string UserID { get; set; } = null!;
	public string Content { get; set; } = null!;
	public byte[]? Image { get; set; }
}