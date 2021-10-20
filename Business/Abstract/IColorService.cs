using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IColorService
    {
        List<Color> GetColorById(int colorId);

        List<Color> GetAll();

        void Add(Color color);

        void Update(Color color);

        void Delete(Color color);
    }
}
