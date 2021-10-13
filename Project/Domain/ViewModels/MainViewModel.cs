using Project.Commands;
using Project.DataAccess.SqlServer;
using Project.Domain.Abstraction;
using Project.Domain.AdditionalClasses;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Project.Domain.ViewModels
{
    public class MainViewModel:BaseViewModel
    {

        private readonly IRepository<Book> _repo;
        private readonly IRepository<Author> _authorRepo;

        public MainViewModel(IBookRepository repo,IAuthorRepository authorRepo)
        {
            _repo = repo;
            _authorRepo = authorRepo;
            AllBooks = _repo.GetAllData();
            AllAuthors = _authorRepo.GetAllData();
            CurrentBook = new Book();
            CurrentAuthor = new Author();
            AddCommand = new RelayCommand((sender) =>
              {
                  //temp id
                  CurrentBook.Id_Author = (int)(CurrentAuthor?.Id);
                  CurrentBook.Id_Category = 1;
                  CurrentBook.Id_Press = 1;
                  CurrentBook.Id_Themes = 1;
                  _repo.AddData(CurrentBook);
                  AllBooks = _repo.GetAllData();
              });


            UpdateCommand = new RelayCommand((sender) =>
              {
                  //WITH ERROR
                  _repo.UpdateData(CurrentBook);
                  var book = _repo.GetData(CurrentBook.Id);
                
                  var authors = authorRepo.GetAllData();
                  var obsCollection = (IEnumerable<Author>)authors;
                  var list = new List<Author>(obsCollection);
                   
                  book.Author = list.Find(a => a.Id == CurrentAuthor.Id);

                  CurrentBook.Id_Author = book.Author.Id;
                  CurrentBook.Author = book.Author;
                  CurrentBook = new Book();
                  CurrentAuthor = new Author(); 

                  AllBooks = _repo.GetAllData();
              });

            DeleteCommand = new RelayCommand((sender) =>
              {
                  //HAVE FIX - DOES NOT WORK
                  //_repo.DeleteData(CurrentBook);
                  //CurrentBook = new Book();
                  //CurrentAuthor = new Author();
                  //AllBooks = _repo.GetAllData();
              });
        }
        public RelayCommand UpdateCommand { get; set; }
        public RelayCommand AddCommand { get; set; }
        public RelayCommand DeleteCommand { get; set; }

        private Book currentBook;

        public Book CurrentBook
        {
            get { return currentBook; }
            set { currentBook = value; OnPropertyChanged(); }
        }

        private Author currentAuthor;

        public Author CurrentAuthor
        {
            get { return currentAuthor; }
            set { currentAuthor = value; OnPropertyChanged(); }
        }


        private ObservableCollection<Book> allBooks;
        public ObservableCollection<Book> AllBooks
        {
            get { return allBooks; }
            set { allBooks = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Author> allAuthors;

        public ObservableCollection<Author> AllAuthors
        {
            get { return allAuthors; }
            set { allAuthors = value; OnPropertyChanged(); }
        }


    }
}
