using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car : IEntity
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public int ColorId { get; set; }

        public int ModelYear { get; set; }

        public int DailyPrice { get; set; }
        public string Description { get; set; }

        override
        public string ToString()
        {
            return "[id=" + this.Id + " BrandId=" + BrandId + " ColorId=" + ColorId + " ModelYear=" + ModelYear + " Daily Price=" + DailyPrice + " Description=" + Description + " ]";
        }

    }
}
