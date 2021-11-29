using System;
using System.Collections.Generic;
using System.Linq;
using Chat_ddsv.Data;
using Chat_ddsv.Models;
using Microsoft.AspNetCore.Mvc;

namespace Chat_ddsv.Controllers
{
    [ApiController]
    [Route("api/amigo")]
    public class AmigoController : ControllerBase
    {
        private readonly DataContext _context;
        public AmigoController(DataContext context)
        {
            _context = context;
        }

        //POST: /api/Amigo/create
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Amigo amigo)
        {
            _context.Amigos.Add(amigo);
            _context.SaveChanges();
            return Created("", amigo);
        }

        //GET: /api/Amigo/list
        [Route("list")]
        [HttpGet]
        public IActionResult List() => Ok(_context.Amigos.ToList());

        //GET: api/Amigo/getbyemail/1
        [HttpGet]
        [Route("getbycpf/{email}")]
        public IActionResult GetByEmail([FromRoute] string email)
        {
            //Buscar um objeto pela chave primária
            Amigo amigo = _context.Amigos.FirstOrDefault(amigo => amigo.Email == email);
            if (amigo == null)
            {
                return NotFound();
            }
            return Ok(amigo);
        }

        //GET: api/Amigo/delete/1
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            //Where -> Expressão lambda
            //Buscar um objeto pelo nome
            Amigo amigo = _context.Amigos.Find(id);
            if (amigo == null)
            {
                return NotFound();
            }
            _context.Amigos.Remove(amigo);
            _context.SaveChanges();
            return Ok(_context.Amigos.ToList());
        }
    }
}