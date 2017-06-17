using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFCategoryRepository : ICategoryRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Category> Categories
        {
            get
            {
                return context.Categories.Include(x => x.Contents);
            }
        }

        public Category Delete(int id)
        {
            Category result = null;
            if (id > 0)
            {
                var dbEntry = context.Categories.Find(id);
                if (dbEntry != null)
                {
                    result = context.Categories.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
            return result;
        }

        public Category Get(int id)
        {
            return context.Categories.Find(id);
        }

        public void Save(Category category)
        {
            if (category != null && category.ID >= 0)
            {
                if (category.ID == 0)
                {
                    context.Categories.Add(category);
                }
                if (category.ID > 0)
                {
                    var dbEntry = context.Categories.Find(category.ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Name = category.Name;
                        dbEntry.Contents = category.Contents;
                        dbEntry.Description = category.Description;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}