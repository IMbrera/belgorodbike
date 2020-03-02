using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BB.Services
{
   public class CategoryService
    {
        BBDbContext context = new BBDbContext();
        public IEnumerable<Category> GetCategories()
        {
            context = new BBDbContext();
            return context.Categories.ToList();
        }
        public IEnumerable<Category> SearchCategory(string search)
        {
            var context = new BBDbContext();

            var category = context.Categories.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                category = category.Where(a => a.Name.ToLower().Contains(search.ToLower()));
            }

            return category.ToList();
        }
        public Category GetCategoryID(int ID)
        {
            var context = new BBDbContext();

            return context.Categories.Find(ID);
        }
        public bool SaveCategory(Category category)
        {
            var context = new BBDbContext();

            context.Categories.Add(category);

            return context.SaveChanges() > 0;
        }
        public bool UpdateCategory(Category category)
        {
            var context = new BBDbContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Modified;

            return context.SaveChanges() > 0;
        }
        public bool DeleteCategory(Category category)
        {
            var context = new BBDbContext();

            context.Entry(category).State = System.Data.Entity.EntityState.Deleted;

            return context.SaveChanges() > 0;
        }
    }
}
