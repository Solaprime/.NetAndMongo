using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaceDriversApi.Models;
using RaceDriversApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceDriversApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly DriversService _driverService;
        //  public DriversController(DriversService drivers) => _driverService = drivers;
        public DriversController(DriversService driverService)
        {
            _driverService = driverService;
        }
        [HttpGet("{id:length(24)}", Name="GetSingle")]
        public async Task<IActionResult> GetSingle(string id)
        {
            var existingDriver = await _driverService.GetSingleAsync(id);
            if (existingDriver == null)
                return NotFound();
            return Ok(existingDriver);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var existingDriver = await _driverService.GetAsync();
            if (!existingDriver.Any())
                return NotFound();
            return Ok(existingDriver);
        }
        [HttpPost()]
        public async Task<IActionResult> CreateSingle(Driver driver)
        {
            await _driverService.CreateAsync(driver);

            return CreatedAtRoute("GetSingle", new { id = driver.Id }, driver);
          //  return CreatedAtRoute(nameof(GetSingle), new { id = driver.Id }, driver);

        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> UpdateSingle(string id, Driver driver)
        {
            var existingDriver =await  _driverService.GetSingleAsync(id);
            if (existingDriver == null)
            {
                return BadRequest();
            }
            driver.Id = existingDriver.Id;
           await _driverService.UpdateAsync1(driver);
            return NoContent();
            
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteSingle(string id)
        {
            var existingDriver = await _driverService.GetSingleAsync(id);
            if (existingDriver == null)
            {
                return BadRequest();
            }
            await _driverService.RemoveAsync(id);
            return NoContent();
        }

    }
}


//{
//_id: ObjectId("64d5501ab03bc5de2bf10551"),
//    Name: 'Lewis Hamiltonial',
//    Number: 44,
//    Team: 'Mercedes-Amg'
//  },
//  {
//_id: ObjectId("64d5501ab03bc5de2bf10552"),
//    Name: 'Sergio Perez',
//    Number: 45,
//    Team: 'Red Bull'
//  },
//  {
//_id: ObjectId("64d55094b03bc5de2bf10553"),
//    Name: 'Max Vesterpen',
//    Number: 47,
//    Team: 'Bentlez'
//  },
//  {
//_id: ObjectId("64d55094b03bc5de2bf10554"),
//    Name: 'Marcos ',
//    Number: 46,
//    Team: 'BMW'
//  }