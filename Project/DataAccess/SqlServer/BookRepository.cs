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
    public class BookRepository : IBookRepository
    {
        public DataClassesDataContext DataContext { get; set; }
        public BookRepository()
        {
            DataContext = new DataClassesDataContext();
        }

        public Book GetData(int id)
        {
            var book = DataContext.Books.FirstOrDefault(b => b.Id == id);
            return book;
        }
        public ObservableCollection<Book> GetAllData()
        {
            var books = from b in DataContext.Books
                        select b;
            return ObserverHelper.ToObservableCollection(books);
        }

        public void AddData(Book data)
        {
            DataContext.Books.InsertOnSubmit(data);
            DataContext.SubmitChanges();
        }

        public void UpdateData(Book data)
        {
            var book = GetData(data.Id);
            book = data;
            DataContext.SubmitChanges();
            
        }

        public void DeleteData(Book data)
        {
            DataContext.Books.DeleteOnSubmit(data);
            DataContext.SubmitChanges();
        }
    }
}
