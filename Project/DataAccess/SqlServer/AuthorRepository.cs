using Project.Domain.Abstraction;
using Project.Domain.AdditionalClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.SqlServer
{
    public class AuthorRepository : IAuthorRepository
    {
        public DataClassesDataContext DataContext { get; set; }
        public AuthorRepository()
        {
            DataContext = new DataClassesDataContext();
        }
        public void AddData(Author data)
        {
            throw new NotImplementedException();
        }

        public void DeleteData(Author data)
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<Author> GetAllData()
        {
            var authors = from a in DataContext.Authors
                        select a;
            return ObserverHelper.ToObservableCollection(authors);
        }

        public Author GetData(int id)
        {
           return  DataContext.Authors.Single(x => x.Id == id);
        }

        public void UpdateData(Author data)
        {
            throw new NotImplementedException();
        }
    }
}
