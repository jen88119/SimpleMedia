namespace SimpleMedia.Dto
{
    public class QueryCommentDto
    {
        public int CommentID { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime LastMaintainDt { get; set; }
    }
}
