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
    public class VaultkeepsController : ControllerBase
    {
        private readonly VaultkeepsService _vks;
        public VaultkeepsController(VaultkeepsService vks)
        {
            _vks = vks;
        }

        [HttpPost]
        public ActionResult<Vaultkeep> AddKeepToVault([FromBody] Vaultkeep newvaultkeep)
        {
            try
            {
                newvaultkeep.userId = HttpContext.User.FindFirstValue("Id");
                return Ok(_vks.AddKeep(newvaultkeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{vaultId}")]
        public ActionResult<IEnumerable<Keep>> Get(int vaultId)
        {
            try
            {
                var userId = HttpContext.User.FindFirstValue("Id");
                return Ok(_vks.Get(vaultId, userId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public ActionResult<string> Delete([FromBody] Vaultkeep vaultkeep)
        {
            try
            {
                vaultkeep.userId = HttpContext.User.FindFirstValue("Id");
                 return Ok(_vks.Delete(vaultkeep));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}

