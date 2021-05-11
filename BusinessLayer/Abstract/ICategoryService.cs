using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface ICategoryService
   {
       List<Category> getCategoryList();
       void CategoryAddBL(Category category);
       Category GetByID(int id);
       void DeleteCategory(Category category);
       void UpdateCategory(Category category);
   }
}
