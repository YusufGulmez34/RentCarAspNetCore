using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userManager;

        public UserController(IUserService userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _userManager.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _userManager.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            var result = _userManager.Add(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            var result = _userManager.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(User user)
        {
            var result = _userManager.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
