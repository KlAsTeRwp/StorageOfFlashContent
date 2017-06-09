using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IRateRepository
    {
        //method for getting series of Rate
        IEnumerable<Rate> Rates { get; }
        //method for adding new Rate in database or modifing of issued
        void Save(Rate content);
        //method for getting defined Rate by primary key
        Rate Get(int id);
        //method for deleting defined Rate by primary key
        Rate Delete(int id);
    }
}
