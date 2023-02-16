using Business.Abstarct;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;
       

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
            

        }
        public IResult Add(Product product)
        {
          
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
           
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll().OrderBy(p => p.CategoryId).ToList(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)             
        {
            var result = new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id).OrderBy(p=>p.ProductName).ToList(),Messages.CategoryListed);
            if (result.Data.Count()==0)
            {
                return new ErrorDataResult<List<Product>>(Messages.WrongIdEntry);
            }
            return result;
        }

        public IDataResult<Product> GetById(int productId)
        {
            var result = new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId),Messages.ProductListed);
            if (result.Data.ProductId==null)
            {
                return new ErrorDataResult<Product>(Messages.WrongIdEntry);
            }
            return result;
           
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails().OrderBy(p=>p.ProductName).ToList());
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductAdded);
        }
       

    }
}
