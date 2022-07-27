using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetList();


        void CategoryAdd(Category category);

        Category GetByID(int id);

        void CategoryDelete(Category category);

        void CategoryUpdate(Category category);

    }
}
