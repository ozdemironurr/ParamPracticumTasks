using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ParamMarkatinDBContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (ParamMarkatinDBContext context = new ParamMarkatinDBContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInstock,
                                 UnitPrice= p.UnitPrice,


                             };
                return result.ToList();
            }
        }
    }
}
