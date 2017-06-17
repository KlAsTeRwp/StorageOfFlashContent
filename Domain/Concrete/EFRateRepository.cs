using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Domain.Abstract;
using Domain.Concrete;
using Domain.Entities;

namespace Domain.Concrete
{
    public class EFRateRepository : IRateRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Rate> Rates 
        {
            get
            {
                return context.Rates.Include(x => x.Content);
            }
        }

        public Rate Delete(int id)
        {
            Rate result = null;
            if (id > 0)
            {
                var dbEntry = context.Rates.Find(id);
                if (dbEntry != null)
                {
                    result = context.Rates.Remove(dbEntry);
                    context.SaveChanges();
                }
            }
            return result;
        }

        public Rate Get(int id)
        {
            return context.Rates.Find(id);
        }

        public void Save(Rate rate)
        {
            if (rate != null && rate.ID >= 0)
            {
                if (rate.ID == 0)
                {
                    context.Rates.Add(rate);
                }
                if (rate.ID > 0)
                {
                    var dbEntry = context.Rates.Find(rate.ID);
                    if (dbEntry != null)
                    {
                        dbEntry.Content = rate.Content;
                        dbEntry.Description = rate.Description;
                        dbEntry.Value = rate.Value;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
