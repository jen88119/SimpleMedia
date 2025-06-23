using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMedia.Dto;
using SimpleMedia.Interfaces;

[Authorize]
public class PostController : Controller
{
    private readonly IPostService _postService;

    public PostController(IPostService postService)
    {
        _postService = postService;
    }

    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        var posts = await _postService.GetAllPostsAsync();
        return View(posts);
    }

    /// <summary>
    /// 新增貼文
    /// <summary>
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreatePostDto post)
    {
        var userId = User.Identity.Name;
        await _postService.CreatePostAsync(post, userId);

        return RedirectToAction("Index");
    }

    /// <summary>
    /// 貼文詳細頁
    /// <summary>
    [AllowAnonymous]
    public async Task<IActionResult> Detail(int id)
    {
        var detail = await _postService.GetAllDetailAsync(id);

        return View(detail);
    }

    /// <summary>
    /// 編輯貼文
    /// <summary>
    public async Task<IActionResult> Edit(int id)
    {
        var post = await _postService.GetPostContentAsync(id);

        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EditPostDto post)
    {
        await _postService.UpdatePostAsync(post);

        return RedirectToAction("Index");
    }

    /// <summary>
    /// 刪除貼文
    /// <summary>
    public async Task<IActionResult> Delete(int id)
    {
        await _postService.DeletePostAsync(id);

        return RedirectToAction("Index");
    }
}
