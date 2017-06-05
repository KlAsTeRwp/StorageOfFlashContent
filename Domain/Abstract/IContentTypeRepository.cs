using System.Collections.Generic;
using Domain.Entities;

//interface of content type repository
namespace Domain.Abstract
{
    public interface IContentTypeRepository
    {
        //method for getting series of ContentType
        IEnumerable<ContentType> ContentTypes { get; }
        //method for adding new ContentType in database or modifing of issued
        void Save(ContentType contentType);
        //method for getting defined ContentType by primary key
        ContentType Get(int id);
        //method for deleting defined ContentType by primary key
        ContentType Delete(int id);
    }
}
