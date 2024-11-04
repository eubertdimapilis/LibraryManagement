using Model;
namespace Manager
{
    public class BookManager
    {
        private readonly List<Book> _books = new List<Book>();

        public IEnumerable<Book> GetAllBooks() => _books;

        public Book GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);

        public void AddBook(Book book)
        {
            book.Id = _books.Count > 0 ? _books.Max(b => b.Id) + 1 : 1;
            _books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = GetBookById(book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.IsAvailable = book.IsAvailable;
            }
        }

        public void DeleteBook(int id)
        {
            var book = GetBookById(id);
            if (book != null)
            {
                _books.Remove(book);
            }
        }
    }
}
