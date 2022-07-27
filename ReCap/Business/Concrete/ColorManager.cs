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
    public class ColorManager : IColorService
    {
        IColorDal _ıColorDal;

        public ColorManager(IColorDal ıColorDal)
        {
            _ıColorDal = ıColorDal;
        }

        public IResult Add(Color color)
        {
            if (color.Name.Length<2)
            {
                return new ErrorResult(Messages.ColorNameInvalid);
            }
            else
            {
                _ıColorDal.Add(color);
                return new SuccessResult();
            }
            
        }

        public IResult Delete(Color color)
        {
            _ıColorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_ıColorDal.GetAll(),Messages.ColorListed);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new SuccessDataResult<Color>(_ıColorDal.Get(c=>c.Id == id),Messages.ColorListed);
        }

        public IResult Update(Color color)
        {
            _ıColorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
