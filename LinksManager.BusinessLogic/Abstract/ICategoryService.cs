using System.Collections.Generic;
using LinksManager.Entities;

namespace LinksManager.BusinessLogic.Abstract
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories();
        Category GetCategoryById(int id);

        bool AddCategory(Category category);
        bool EditCategory(int id, Category category);
        bool DeleteCategory(int id);
    }
}
