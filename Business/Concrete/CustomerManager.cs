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
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(">> New customer is added.");
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(">> Customer is deleted.");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var customers = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(customers,">> All customers are listed.");
        }

        public IDataResult<Customer> GetCustomerById(int id)
        {
            Customer customer = _customerDal.GetAll(c => c.Id == id).First();
            return new SuccessDataResult<Customer>(customer, ">> Customer is got by id.");
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);

            return new SuccessResult(">> Customer is updated.");
        }
    }
}
