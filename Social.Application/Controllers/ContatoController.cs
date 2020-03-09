using System;
using Microsoft.AspNetCore.Mvc;
using Social.Domain.Entities;
using Social.Domain.Interfaces;

namespace Social.Application.Controllers
{
    [Produces("application/json")]
    [Route("api/Contato")]
    public class ContatoController : Controller
    { 
         private readonly IContatoService _service;

        public ContatoController(IContatoService service)
        {
            this._service = service;
        }

        public IActionResult Post([FromBody] Contato item)
        {
            try
            {
                _service.Post(item);

                return new ObjectResult(item.Id);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Put([FromBody] Contato item)
        {
            try
            {
                _service.Put(item);

                return new ObjectResult(item);
            }
            catch(ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);

                return new NoContentResult();
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Get()
        {
            try
            {
                return new ObjectResult(_service.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(_service.Get(id));
            }
            catch(ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}