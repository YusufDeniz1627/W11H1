using Business.Abstarct;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Business.Constants;
using DataAccess.Abstract;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _ıBrandDal;

        public BrandManager(IBrandDal ıBrandDal)
        {
            _ıBrandDal = ıBrandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.Name.Length<2)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }
            _ıBrandDal.Add(brand);
            return new SuccessResult();
        }

        public IResult Delete(Brand brand)
        {
            _ıBrandDal.Delete(brand);
            return new SuccessResult(Messages.BrandDeleted);
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_ıBrandDal.GetAll(),Messages.BrandListed);
        }

        public IDataResult<Brand> GetbyId(int id)
        {
            return new SuccessDataResult<Brand>(_ıBrandDal.Get(b => b.Id == id),Messages.BrandListed);
        }

        public IResult Update(Brand brand)
        {
            _ıBrandDal.Update(brand);
            return new SuccessResult(Messages.BrandUpdated);
        }
    }
}
