using BusBooking.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusBooking.Repository
{
     public interface ICategoryRespository
        {
            void AddCategory(Category category);
            IEnumerable<Category> GetCategoryDetails();
            void Delete(int id);
            void Update(Category category);
            Category GetCategoryById(int id);
        }
        public class CategoryRepository : ICategoryRespository
        {
            public void AddCategory(Category category)   //Add Category .
            {
                using (BusTicketBookingDbContext busTicketBookingDbContext = new BusTicketBookingDbContext())
                {
                busTicketBookingDbContext.Categories.Add(category);
                busTicketBookingDbContext.SaveChanges();
                }

            }
            public IEnumerable<Category> GetCategoryDetails()   //Fetch Category from Database.
            {
                using (BusTicketBookingDbContext busTicketBookingDbContext = new BusTicketBookingDbContext())
                {

                    return busTicketBookingDbContext.Categories.ToList(); ;

                }
            }

            public void Delete(int id) //Delete Category from Database table.
            {
                using (BusTicketBookingDbContext busTicketBookingDbContext = new BusTicketBookingDbContext())
                {
                    Category category = busTicketBookingDbContext.Categories.Find(id);
                busTicketBookingDbContext.Categories.Remove(category);
                busTicketBookingDbContext.SaveChanges();
                }
            }

            public void Update(Category category) //Update Category to the Database.
            {
                using (BusTicketBookingDbContext busTicketBookingDbContext = new BusTicketBookingDbContext())
                {
                Category updateCategory = GetCategoryById(category.CategoryId);
                updateCategory.CategoryName = category.CategoryName;
                //busTicketBookingDbContext.Entry(category).State = System.Data.Entity.EntityState.Modified;
                busTicketBookingDbContext.SaveChanges();
                }
            }

            public Category GetCategoryById(int id) //Get Category 
            {
                using (BusTicketBookingDbContext busTicketBookingDbContext = new BusTicketBookingDbContext())
                {
                    return busTicketBookingDbContext.Categories.Where(category => category.CategoryId == id).FirstOrDefault();
                }
            }
        }
    }

