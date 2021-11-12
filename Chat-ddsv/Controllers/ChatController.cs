/*using System;
using System.Collections.Generic;
using System.Linq;
using Chat_ddsv.Data;
using Chat_ddsv.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_ddsv.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class ChatController : ControllerBase
    {
        private readonly DataContext _context;
        public ChatController(DataContext context)
        {
            _context = context;
        }

        //POST: /api/Usuario/create
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Chat chat)
        {
            _context.Chat.Add(chat);
            _context.SaveChanges();
            return Created("", chat);
        }

        //GET: /api/Usuario/list
        [Route("list")]
        [HttpGet]
        public IActionResult List() => Ok(_context.Usuarios.ToList());

        //GET: api/Usuario/getbyid/1
        [HttpGet]
        [Route("getbyid/{sender}/{receiver}")]
        public IActionResult GetById([FromRoute] int sender, int receiver)
        {
            //Buscar um objeto pela chave primária
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }


        //PUT: /api/Usuario/create
        [Route("update")]
        [HttpPut]
        public IActionResult Update([FromBody] Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
    }
}*/