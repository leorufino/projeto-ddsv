using System;
using System.Collections.Generic;
using System.Linq;
using Chat_ddsv.Data;
using Chat_ddsv.Models;
using Chat_ddsv.Services;
using Microsoft.AspNetCore.Mvc;
namespace Chat_ddsv.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly DataContext _context;
        public UsuarioController(DataContext context)
        {
            _context = context;
        }
        //POST: /api/Usuario/create
        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Created("", usuario);
        }
        //GET: /api/Usuario/list
        [Route("list")]
        [HttpGet]
        public IActionResult List() => Ok(_context.Usuarios.ToList());
        //GET: api/Usuario/getbyid/1
        [HttpGet]
        [Route("getbyid/{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            //Buscar um objeto pela chave primária
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        //GET: api/Usuario/getbycpf/1
        [HttpGet]
        [Route("getbycpf/{cpf}")]
        public IActionResult GetByCpf([FromRoute] string cpf)
        {
            //Buscar um objeto pela chave primária
            Usuario usuario = _context.Usuarios.FirstOrDefault(usuario => usuario.Cpf == cpf);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }
        //GET: api/Usuario/delete/1
        [HttpDelete]
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            //Where -> Expressão lambda
            //Buscar um objeto pelo nome
            Usuario usuario = _context.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
            return Ok(_context.Usuarios.ToList());
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
        // GET: api/usuario/login
        [HttpGet]
        [Route("login")]
        public IActionResult Login([FromBody] Usuario usuario)
        {
            usuario = _context.Usuarios.FirstOrDefault
                (u => u.Email == usuario.Email && u.Senha == usuario.Senha);
            if (usuario == null)
            {
                return NotFound(new { message = "Usuário ou senha inválidos" });
            }

            usuario.Token = TokenService.CriarToken(usuario);
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();

            return Ok(usuario);
        }
        // GET: api/usuario/Logout
        [HttpGet]
        [Route("Logout")]
        public IActionResult Logout([FromBody] Usuario usuario)
        {
            usuario = _context.Usuarios.FirstOrDefault
                (u => u.Email == usuario.Email);
            if (usuario.Token == null)
            {
                return NotFound(new { message = "Este usuário não está logado no sistema" });
            }

            usuario.Token = null;

            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
    }
}