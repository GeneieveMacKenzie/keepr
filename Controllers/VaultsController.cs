using System;
using System.Collections.Generic;
using System.Security.Claims;
using keepr.Models;
using keepr.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class VaultsController : ControllerBase
    {
        private readonly VaultsService _vs;
        public VaultsController(VaultsService vs)
        {
            _vs = vs;
        }
        [HttpPost]
        public ActionResult<Vault> Create([FromBody]Vault newVault)
        {
            try
            {
                newVault.userId = HttpContext.User.FindFirstValue("Id");
                return Ok(_vs.Create(newVault));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Vault>> Get()
        {
            try
            {
                var userid = HttpContext.User.FindFirstValue("Id");
                return Ok(_vs.Get(userid));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public ActionResult<Vault> Get(int id)
        {
            try
            {
                return Ok(_vs.Get(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                var userid = HttpContext.User.FindFirstValue("Id");
                return Ok(_vs.Delete(id, userid));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
