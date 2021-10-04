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
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerService _customerManager;

        public CustomerController(ICustomerService customerManager)
        {
            _customerManager = customerManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _customerManager.GetAll();
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest();
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _customerManager.GetById(id);
            if (result.Success)
            {
                return Ok(result);

            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult Add(Customer customer)
        {
            var result = _customerManager.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpPut]
        public IActionResult Update(Customer customer)
        {
            var result = _customerManager.Update(customer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult Delete(Customer customer)
        {
            var result = _customerManager.Delete(customer);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
