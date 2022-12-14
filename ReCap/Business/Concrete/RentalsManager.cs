using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalsManager : IRentalsService
    {
        IRentalsDal _ıRentalsDal;

        public RentalsManager(IRentalsDal ıRentalsDal)
        {
            _ıRentalsDal = ıRentalsDal;
        }

        public IResult Add(Rental rentals)
        {
             if (rentals.ReturnDate==null && rentals.RentDate < rentals.ReturnDate )
            {
                _ıRentalsDal.Add(rentals);
                return new SuccessResult(Messages.RentalsAdded);
            }
            else
            {
                return new ErrorResult(Messages.RentalsNotAdded);
            }
               
        }

        public IResult Deleted(Rental rentals)
        {
            _ıRentalsDal.Delete(rentals);
            return new SuccessResult(Messages.RentalsDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_ıRentalsDal.GetAll());
        }

        public IDataResult<Rental> GetById(int Id)
        {
            return new SuccessDataResult<Rental>(_ıRentalsDal.Get(r=>r.Id==Id));
        }

        public IResult Updated(Rental rentals)
        {
            _ıRentalsDal.Update(rentals);
            return new SuccessResult(Messages.RentalsUpdated);
        }
    }
}
