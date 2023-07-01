using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dtos;

namespace Application
{
    public class PriceCalculator : ICalculatePrice
    {
        private readonly List<ICalculatePrice> _calculators;

        public PriceCalculator(List<ICalculatePrice> calculators)
        {
            _calculators = calculators;
        }

        public void CalculatePrice(CarDetailsDto carDetailsDto) {
            
            foreach(var calculator in _calculators)
            {
                calculator.CalculatePrice(carDetailsDto);
            }

        }
    }
}

//