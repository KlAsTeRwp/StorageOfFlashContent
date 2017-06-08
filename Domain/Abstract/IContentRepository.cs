using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IContentRepository
    {
        //method for getting series of Content
        IEnumerable<Content> Contents { get; }
        //method for adding new Content in database or modifing of issued
        void Save(Content content);
        //method for getting defined Content by primary key
        Content Get(int id);
        //method for deleting defined Content by primary key
        Content Delete(int id);
    }
}