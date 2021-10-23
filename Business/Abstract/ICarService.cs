﻿using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);

        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IDataResult<Car> GetCarById(int id);

        IDataResult<List<Car>> GetAll();

        IResult Add(Car car);

        IResult Update(Car car);

        IResult Delete(Car car);
    }
}
