using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetailsWithImageDto : IDto
    {
        public int Id { get; set; }

        public string BrandName { get; set; }

        public string ColorName { get; set; }

        public string Model { get; set; }

        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
    }
}
