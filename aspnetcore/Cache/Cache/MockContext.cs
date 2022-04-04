namespace Cache
{
    public class MockContext
    {
        public MockContext()
        {
        }

        public class Book
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
        }
        public static List<Book> Books { get; set; } = new()
        {
            new Book { Id = 1, Name = "Effective C++",Author = "jack"},
            new Book { Id = 1, Name = "Effective Java",Author = "jack"},
            new Book { Id = 1, Name = "Effective Python",Author = "jack"},
            new Book { Id = 1, Name = "Effective C#",Author = "jack"},
        };

        public Book getBookById(int id)
        {
            return Books.Single(B=>B.Id==id);
        }
        
        public List<Book> AllBooks()
        {
            return Books;
        }
    }
}
