using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/rentals")]
    [ApiController]
    public class RentalController : ControllerBase
    {
        IRentalService _rentalManager;

        public RentalController(IRentalService rentalManager)
        {
            _rentalManager = rentalManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _rentalManager.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _rentalManager.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Add(Rental rental)
        {
            var result = _rentalManager.Add(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Rental rental)
        {
            var result = _rentalManager.Update(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(Rental rental)
        {
            var result = _rentalManager.Delete(rental);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }




    }
}
