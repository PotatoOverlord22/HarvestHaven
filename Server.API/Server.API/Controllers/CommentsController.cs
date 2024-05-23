﻿using Microsoft.AspNetCore.Mvc;
using Server.API.Models;
using Server.API.Services;

namespace Server.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // Get all comments
        // GET: api/comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comment>>> GetComments()
        {
            var comments = await commentService.GetCommentsAsync();
            return comments;
        }

        // Get Comments by id
        // api/comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Achievement>> GetCommentById(Guid id)
        {
            var comment = await commentService.GetCommentByIdAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return comment;
        }

        // UPDATE a comment
        // PUT: api/comments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(Guid id, Comment comment)
        {
            try
            {
                await commentService.UpdateCommentAsync(id, comment);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            return NoContent();
        }

        // Add comment
        // POST: api/comments
        [HttpPost]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            try
            {
                await commentService.AddCommentAsync(comment);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
            return NoContent();
        }

        // DELETE: api/comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(Guid id)
        {
            try
            {
                await commentService.DeleteCommentAsync(id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}