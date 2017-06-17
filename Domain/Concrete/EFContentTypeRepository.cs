using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using System.Data;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFContentTypeRepository : IContentTypeRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<ContentType> ContentTypes
        {
            get
            {
                return context.ContentTypes.Include(x => x.Contents);
            }
        } 

        public ContentType Delete(int id)
        {
            ContentType result = null;
            if (id > 0)
            {
                var dbEntry = context.ContentTypes.Find(id);
                if (dbEntry != null)
                {
                    result = context.ContentTypes.Remove(dbEntry);
                    context.SaveChanges();
                }                
            }
            return result;
        }

        public ContentType Get(int id)
        {
            return context.ContentTypes.Find(id);
        }

        public void Save(ContentType contentType)
        {
            if (contentType != null && contentType.ID >= 0)
            {
                if (contentType.ID == 0)
                {
                    context.ContentTypes.Add(contentType);
                }
                if (contentType.ID > 0)
                {
                    var dbEntry = context.ContentTypes.Find(contentType.ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Type = contentType.Type;
                        dbEntry.Extensions = contentType.Extensions;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
