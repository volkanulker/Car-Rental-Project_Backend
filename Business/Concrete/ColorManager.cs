using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {

        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);

            return new SuccessResult(">> New color is added.");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(">> Given color is deleted.");

        }

        public IDataResult<List<Color>> GetAll()
        { 
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),">> Colors are listed.");
        }

        public IDataResult<List<Color>> GetColorById(int colorId)
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(c => c.Id == colorId),">> Colors are got by ID");
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(">> Given  color is updated.");
        }
    }
}
