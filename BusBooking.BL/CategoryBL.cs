using BusBooking.Entity;
using BusBooking.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.BL
{
    public interface ICategoryBL
    {
        void AddCategory(Category category);
        IEnumerable<Category> GetCategoryDetails();
       
        void Delete(int id);
        void Update(Category category);
        Category GetCategoryByID(int id);
    }
    public class CategoryBL : ICategoryBL
    {
        public CategoryRepository categoryRepository = new CategoryRepository();
        public void AddCategory(Category category)
        {
            categoryRepository.AddCategory(category);
        }

        public IEnumerable<Category> GetCategoryDetails()
        {
            return categoryRepository.GetCategoryDetails();
        }

        public void Delete(int id)
        {
            categoryRepository.Delete(id);
        }
        public void Update(Category category)
        {
            categoryRepository.Update(category);
        }
        public Category GetCategoryByID(int id)
        {
            return categoryRepository.GetCategoryById(id);
        }
    }
}
