using System;
using Microsoft.AspNetCore.Mvc;
using Application;
using Application.Interfaces;
using Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/calculation")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatePrice _priceCalculator;

        public CalculatorController(ICalculatePrice priceCalculator)
        {
           
            _priceCalculator = priceCalculator;
        }




        // POST api/<ProductBatcherController>
        [HttpPost]
        public double CalculateCarPrice([FromBody] CarDetailsDto carDetailsDto)
        {
            
            _priceCalculator.CalculatePrice(carDetailsDto);
            return carDetailsDto.Price;

        }











    }
}
