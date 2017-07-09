using System;
using System.Collections.Generic;
using LinksManager.BusinessLogic.Abstract;
using LinksManager.DataAccess.Abstract;
using LinksManager.Entities;

namespace LinksManager.BusinessLogic.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategoryById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must me positive number", nameof(id));
            }

            return _categoryRepository.Get(id);
        }

        public bool AddCategory(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }

            var newCategory = _categoryRepository.Get(category.Id);
            if (newCategory != null)
            {
                return false;
            }

            _categoryRepository.Add(category);
            _categoryRepository.Save();
            return true;
        }

        public bool EditCategory(int id, Category category)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must be positive number", nameof(id));
            }
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null");
            }

            var editCategory = _categoryRepository.Get(id);
            if (editCategory == null)
            {
                return false;
            }

            editCategory.Name = category.Name;
            _categoryRepository.Edit(editCategory);
            _categoryRepository.Save();
            return true;
        }

        public bool DeleteCategory(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException("id must me positive number", nameof(id));
            }

            var deleteCategory = _categoryRepository.Get(id);
            if (deleteCategory == null)
            {
                return false;
            }

            _categoryRepository.Delete(deleteCategory);
            _categoryRepository.Save();
            return true;
        }
    }
}
