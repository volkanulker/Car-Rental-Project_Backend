using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : ControllerBase
    {
        private ITransmissionService _transmissionService;

        public TransmissionsController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }

        [HttpPost("add")]
        public IActionResult Add(Transmission transmission)
        {
            var result = _transmissionService.Add(transmission);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("update")]
        public IActionResult Update(Transmission transmission)
        {
            var result = _transmissionService.Update(transmission);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpPost("delete")]
        public IActionResult Delete(Transmission transmission)
        {
            var result = _transmissionService.Delete(transmission);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);

        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _transmissionService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getfuelbyid")]
        public IActionResult GetTransmissionById(int transmissionId)
        {
            var result = _transmissionService.GetTransmissionById(transmissionId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
