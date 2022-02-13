using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarCardDto:IDto
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public string Model { get; set; }

        public int DailyPrice { get; set; }

        public string ColorName { get; set; }

        public  string FuelName { get; set; }

        public string TransmissionName { get; set; }

        public string ImagePath { get; set; }

        public int NumberOfSeats { get; set; }
    }
}
