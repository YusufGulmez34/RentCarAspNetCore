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
    [Route("api/[controller]")]
    [ApiController]
    public class CarImageControler : ControllerBase
    {
        ICarImageService _carImageManager;

        public CarImageControler(ICarImageService carImageManager)
        {
            _carImageManager = carImageManager;
        }

        [HttpPost]
        public IActionResult Add([FromForm] CarImage carImage,IFormFile file)
        {
            var result = _carImageManager.Add(carImage, file);

            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageManager.Delete(carImage);

            if (!result.Success)
            {
                return BadRequest();
            }

            return Ok(result);
        }
        [HttpGet("id")]
        public IActionResult GetAll(int id)
        {
            var result = _carImageManager.GetAll(c => c.CarId == id);

            return Ok(result);
        }

        [HttpPut]
        public IActionResult Update([FromForm] CarImage carImage,IFormFile file )
        {
            var result = _carImageManager.Update(carImage, file);

            if (!result.Success)
            {
                return BadRequest();
            }
            
            return Ok(result);
        }

    }
}
