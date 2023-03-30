﻿using AnimesCWebMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using IPostHttpService = AnimesCWebMVC.Services.IPostHttpService;

namespace AnimesCWebMVC.Controllers;

public class PostController : Controller
{
    private readonly IPostHttpService _postHttpService;

    public PostController(IPostHttpService postService)
    {
        _postHttpService = postService;
    }

    public async Task<ActionResult<IEnumerable<PostViewModel>>> Index()
    {
        var result = await _postHttpService.GetPosts();
        if (result == null)
        {
            return View("Error");
        }
        return View(result.OrderByDescending(post => post.CreatedAt));
    }

    [HttpGet]
    public IActionResult CreateNewPost()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult<PostViewModel>> CreateNewPost(PostViewModel postVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _postHttpService.CreatePost(postVM);
            if (result != null)
            {
                return RedirectToAction(nameof(Index));
            }
        }
        ViewBag.Erro = "Erro ao criar Publicação";
        return View(postVM);
    }
    //metodo que vai localizar o post
    [HttpGet]
    public async Task<IActionResult> UpdatePost(int id)
    {
        var result = await _postHttpService.GetPostByID(id);
        if (result is null)
        {
            return View("Error");
        }

        return View(result);
    }
    [HttpPost]
    public async Task<ActionResult<PostViewModel>> UpdatePost(int id, PostViewModel postVM)
    {
        if (ModelState.IsValid)
        {
            var result = await _postHttpService.UpdatePost(id, postVM);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Erro = "Erro ao atualizar Categoria";
        }
        return View(postVM);
    }

    [HttpGet]
    public async Task<IActionResult> DeletePost(int id)
    {
        var result = await _postHttpService.GetPostByID(id);
        if (result is null)
            return View("Error");

        return View(result);
    }

    [HttpPost, ActionName("DeletePost")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var result = await _postHttpService.DeletePost(id);

        if (result)
            return RedirectToAction(nameof(Index));

        return View("Error");
    }
}
