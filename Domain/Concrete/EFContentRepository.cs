using System.Collections.Generic;
using Domain.Abstract;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFContentRepository : IContentRepository
    {
       EFDbContext context = new EFDbContext();

        public IEnumerable<Content> Contents
        {
            get
            {
                return context.Contents.Include(x => x.ContentType).Include(x => x.Category).Include(x => x.Rates);
            }
        }

        public Content Delete(int id)
        {
            Content result = null;
            if (id > 0)
            {
                var dbEntry = context.Contents.Find(id);
                if (dbEntry != null)
                {
                    result = context.Contents.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
            return result;
        }

        public Content Get(int id)
        {
            return context.Contents.Find(id);
        }

        public void Save(Content content)
        {
            if (content != null && content.ID >= 0)
            {
                if (content.ID == 0)
                {
                    context.Contents.Add(content);
                }
                if (content.ID > 0)
                {
                    var dbEntry = context.Contents.Find(content.ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Category = content.Category;
                        dbEntry.Description = content.Description;
                        dbEntry.ContentType = content.ContentType;
                        dbEntry.Data = content.Data;
                        dbEntry.Name = content.Name;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}