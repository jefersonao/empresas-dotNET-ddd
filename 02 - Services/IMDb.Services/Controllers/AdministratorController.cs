using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using IMDb.Infra.Data.Context;

namespace IMDb.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private readonly DB _context;

        public AdministratorController(DB context)
        {
            _context = context;
        }
 
        [HttpPost]
        //[Route("Cadastro")]
        public async Task<ActionResult<User>> PostAdmin(User admin)
        {

            try
            {

                admin.isAdmin = true;
                _context.users.Add(admin);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetUser", new { id = admin.Id }, admin);

            }
            catch (Exception e)
            {
                var t = e;
                return BadRequest(e);
            }


        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        // [HttpPut("{id}")]
        [HttpPut]
        [Route("Edição")]
        public async Task<IActionResult> PutAdmin(int id, User admin)
        {
            if (id != admin.Id)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;
            admin.isAdmin = true;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Somente Deleção Lógica
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut]
        [Route("DesativarAdmin")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Entry(user).State = EntityState.Modified;

            user.isDeleted = true;
            await _context.SaveChangesAsync();
            return user;
        }

        private bool AdminExists(int id)
        {
            return _context.users.Any(e => e.Id == id);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpGet]
        [Route("ObterUsuariosNaoAdminAtivos")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsersNoAdmin()
        {
            return await _context.users.Where(u => u.isAdmin == false && u.isDeleted == false).ToListAsync();
        }


    }
}
