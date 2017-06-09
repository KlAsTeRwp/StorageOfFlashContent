using Domain.Entities;
using System.Collections.Generic;

namespace Domain.Abstract
{
    public interface ICategoryRepository
    {
        //method for getting series of Content
        IEnumerable<Category> Categories { get; }
        //method for adding new Content in database or modifing of issued
        void Save(Category category);
        //method for getting defined Content by primary key
        Category Get(int id);
        //method for deleting defined Content by primary key
        Category Delete(int id);
    }
}