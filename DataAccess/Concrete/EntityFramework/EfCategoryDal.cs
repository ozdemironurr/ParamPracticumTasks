using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCategoryDal : EfEntityRepositoryBase<Category, ParamMarketingDBContext>, ICategoryDal
    {
        public List<CategoryDetailDto> GetCategoryDetails(int categoryId)
        {
            using (var context = new ParamMarketingDBContext())
            {
                var result = from c in context.Categories
                             join p in context.Products
                                 on c.CategoryId equals p.CategoryId
                             where c.CategoryId == categoryId
                             select new CategoryDetailDto
                             {
                                 ProductName= p.ProductName,
                                 CategoryName=c.CategoryName,
                                 UnitPrice= p.UnitPrice,
                                 UnitsInStock= p.UnitsInStock,

                             };
                return result.ToList();


            }
        }
    }
}
