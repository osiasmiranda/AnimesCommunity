using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SocialNetwork.Application.DTOs;
using SocialNetwork.Application.Interfaces;
using SocialNetwork.Domain.Entites;
using SocialNetwork.Domain.Exceptions;
using SocialNetwork.Infrastructure.Context;

namespace SocialNetwork.API.Controllers;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private readonly IPostService _postService;

    public PostsController(IPostService postService)
    {
        _postService = postService;
        
    }

    // GET: api/Posts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PostDTO>>> Get()
    {
        var posts = await _postService.GetPosts();
        return Ok(posts);
    }
    // GET: api/Posts/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Post>> GetPost(int id)
    {
        var post = await _postService.GetById(id);

        if (post == null)
        {
            return NotFound();
        }
        return Ok(post);
    }

    // PUT: api/Posts/5
    [HttpPut("{id}")]

    public async Task<IActionResult> PutPost(int id, PostDTO postDTO)
    {

        if(id != postDTO.Id)
        {
            return BadRequest();
        }
        try
        {

            await _postService.Update(postDTO);
        }
        catch (EntityValidationException e)
        {
            ModelState.AddModelError(e.PropertyName, e.Message);
            return BadRequest(ModelState);
        }

        return Ok(postDTO);
     }

    // POST: api/Posts
    [HttpPost]
    public async Task<ActionResult> PostPost(PostDTO postDTO)

    {

        await _postService.Add(postDTO);
        return CreatedAtAction("GetPost", new { id = postDTO.Id }, postDTO);

    }

    // DELETE: api/Posts/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePost(int id)
    {
        var postDTO = await _postService.GetById(id);

        if(postDTO == null)
        {
            return NotFound();
        }
        await _postService.Remove(id);
        return Ok(postDTO);
    }
}
