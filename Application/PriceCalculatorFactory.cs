using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class PriceCalculatorFactory
    {
        public ICalculatePrice CreateMileageCalculator()
        {
            return new MileageCalculation();
        }

        public ICalculatePrice CreateColourCalculator()
        {
            return new ColourCalculation();
        }

        public ICalculatePrice CreateGradeCalculator()
        {
            return new GradeCalculation();
        }
        public ICalculatePrice CreateAgeCalculator() { 
            return new AgeCalculation();
        
        }
    }
}
