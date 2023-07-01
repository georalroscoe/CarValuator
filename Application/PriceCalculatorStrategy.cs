using Application.Interfaces;
using Dtos;

namespace Application
{
    public class MileageCalculation : ICalculatePrice
    {
        public void CalculatePrice(CarDetailsDto carDetailsDto)
        {
            
            if (carDetailsDto.Mileage > 100000)
            {
                carDetailsDto.Price = carDetailsDto.Price * 0.7;
            }
            
        }
    }
    public class ColourCalculation : ICalculatePrice
    {
        public void CalculatePrice(CarDetailsDto carDetailsDto)
        {
            

            switch (carDetailsDto.Colour.ToLower())
            {
                case "white":
                   carDetailsDto.Price += 50;
                    break;
                case "brown":
                    carDetailsDto.Price -= 30;
                    break;
                case "black":
                    carDetailsDto.Price += 30;
                    break;
                
                default:
                    break;
            }

            
        }
    }
    public class GradeCalculation : ICalculatePrice
    {
        public void CalculatePrice(CarDetailsDto carDetailsDto)
        {
            switch (carDetailsDto.Grade)
            {
                case 3:
                    carDetailsDto.Price *= 0.9;
                    break;
                case 4:
                    carDetailsDto.Price *= 0.8;
                    break;
                case 5:
                    carDetailsDto.Price *= 0.7;
                    break;
                    default:
                    break;
            }
        }
    }
    public class AgeCalculation : ICalculatePrice
    {
        public void CalculatePrice(CarDetailsDto carDetailsDto)
        {
            if (carDetailsDto.Age < 10)
            {
                double ageFactor = (carDetailsDto.Age * 5);
                double percentage = (100 - (ageFactor)) / 100;
                carDetailsDto.Price *= percentage;
            }
            else
            {
                carDetailsDto.Price *= 0.5;
            }
        }
    }

}