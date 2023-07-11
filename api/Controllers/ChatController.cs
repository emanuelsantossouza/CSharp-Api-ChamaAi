using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using apiChamaAi.Entities;
using chamaAi.Context;

namespace apiChamaAi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly ApiChamaAiContext _context;

        public ChatController(ApiChamaAiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chat>>> PegarTodosAsync()
        {
            return await _context.Chats.ToListAsync();
        }

        [HttpPost]
        public IActionResult Create(Chat chat)
        {
            _context.Add(chat);
            _context.SaveChanges();
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ObterChatClienteSede(uint id)
        {
            var msg = _context.Chats.Find(id);

            if(msg == null)
                return NotFound();

            return Ok(msg);

        }
    }
}
