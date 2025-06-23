namespace SimpleMedia.Dto
{
	public class EditPostDto
	{
		public int PostID { get; set; }

		public string UserID { get; set; } = null!;
		public string Content { get; set; } = null!;
		public byte[]? Image { get; set; }
	}
}