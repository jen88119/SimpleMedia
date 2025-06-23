using SimpleMedia.Models.Dto;

namespace SimpleMedia.Dto
{
	public class QueryPostDto
	{
		public int PostID { get; set; }

		public string UserID { get; set; }

		public string UserName { get; set; }

		public string Content { get; set; }
		public byte[]? Image { get; set; }
		public DateTime LastMaintainDt { get; set; }
        public List<QueryCommentDto> Comments { get; set; } = new List<QueryCommentDto>();

    }
}