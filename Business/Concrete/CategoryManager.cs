using Business.Abstarct;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.LogAspect;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Layout.Loggers;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Add(Category category)
        {
           
            _categoryDal.Add(category);
            return new SuccessResult(Messages.CategoryAdded);
        }
        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Delete(Category category)
        {
            _categoryDal.Delete(category);
            return new SuccessResult(Messages.CategoryDeleted);
        }
        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect("IProductService.Get")]
        [LogAspect(typeof(FileLogger))]
        public IResult Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessResult(Messages.CategoryUpdated);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(), Messages.CategoryListed);
        }

        [PerformanceAspect(5)]
        [CacheAspect(duration: 10)]
        public IDataResult<Category> GetById(int categoryId)
        {
            var result = new SuccessDataResult<Category>(_categoryDal.Get(c => c.CategoryId == categoryId), Messages.CategoryListed);
            if (result.Data.CategoryId == null)
            {
                return new ErrorDataResult<Category>(Messages.WrongIdEntry);
            }
            return result;
        }
       
       
    }
}
