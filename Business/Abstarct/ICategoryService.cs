using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstarct
{
    public interface ICategoryService
    {
        IDataResult<List<Category>> GetAll();
        IDataResult<Category> GetById(int categoryId);
        IDataResult<List<CategoryDetailDto>> GetCategoryDetails(int categoryId);
        IResult Add(Category category);
        IResult Update(Category category);
        IResult Delete(Category category);
    }
}
