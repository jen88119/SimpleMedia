using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMedia.Entities;
using SimpleMedia.Interfaces;
using SimpleMedia.Models.Dto;

[Route("[controller]")]
[Authorize]
public class CommentController : Controller
{
    private readonly SimpleMediaContext _simpleMediaContext;
    private readonly ICommentService _commentService;

    public CommentController(SimpleMediaContext simpleMediaContext,ICommentService commentService)
    {
        _simpleMediaContext = simpleMediaContext;
        _commentService = commentService;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create(Comment comment)
    {
        var userId = User.Identity.Name;
        await _commentService.CreateCommentAsync(comment, userId);

        return RedirectToAction("Detail", "Post", new { id = comment.PostID });
    }

    [HttpPut("Edit/{commentID}")]
    public async Task<IActionResult> Edit(int commentID,[FromBody] EditCommentDto Content)
    {
        await _commentService.UpdateCommentAsync(Content, commentID);
        return Ok();
    }

    [HttpDelete("Delete/{commentID}")]
    public async Task<IActionResult> Delete(int commentID)
    {
        await _commentService.DeleteCommentAsync(commentID);
        return Ok();
    }

}
