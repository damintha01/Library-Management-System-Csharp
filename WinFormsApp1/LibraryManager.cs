using System;
using System.Collections.Generic;
using System.Linq;

namespace WinFormsApp1
{
    public class LibraryManager
    {
        private List<Book> books;
        private List<Member> members;
        private List<BorrowRecord> borrowRecords;
        private int nextBookId = 1;
        private int nextMemberId = 1;
        private int nextBorrowId = 1;

        public LibraryManager()
        {
            books = new List<Book>();
            members = new List<Member>();
            borrowRecords = new List<BorrowRecord>();
            
            // Add some sample data
            InitializeSampleData();
        }

        private void InitializeSampleData()
        {
            // Sample books
            AddBook(new Book 
            { 
                Title = "The Great Gatsby", 
                Author = "F. Scott Fitzgerald", 
                ISBN = "9780743273565", 
                Genre = "Classic Literature",
                PublicationDate = new DateTime(1925, 4, 10)
            });
            
            AddBook(new Book 
            { 
                Title = "To Kill a Mockingbird", 
                Author = "Harper Lee", 
                ISBN = "9780446310789", 
                Genre = "Fiction",
                PublicationDate = new DateTime(1960, 7, 11)
            });

            AddBook(new Book 
            { 
                Title = "1984", 
                Author = "George Orwell", 
                ISBN = "9780451524935", 
                Genre = "Dystopian Fiction",
                PublicationDate = new DateTime(1949, 6, 8)
            });

            // Sample members
            AddMember(new Member 
            { 
                FirstName = "John", 
                LastName = "Doe", 
                Email = "john.doe@email.com", 
                Phone = "123-456-7890",
                MembershipDate = DateTime.Now.AddMonths(-6)
            });

            AddMember(new Member 
            { 
                FirstName = "Jane", 
                LastName = "Smith", 
                Email = "jane.smith@email.com", 
                Phone = "987-654-3210",
                MembershipDate = DateTime.Now.AddMonths(-3)
            });
        }

        // Book management
        public void AddBook(Book book)
        {
            book.Id = nextBookId++;
            books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Genre = book.Genre;
                existingBook.PublicationDate = book.PublicationDate;
            }
        }

        public void DeleteBook(int bookId)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            if (book != null && book.IsAvailable)
            {
                books.Remove(book);
            }
        }

        public List<Book> GetAllBooks()
        {
            return books.ToList();
        }

        public List<Book> SearchBooks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAllBooks();

            searchTerm = searchTerm.ToLower();
            return books.Where(b => 
                b.Title.ToLower().Contains(searchTerm) ||
                b.Author.ToLower().Contains(searchTerm) ||
                b.Genre.ToLower().Contains(searchTerm) ||
                b.ISBN.Contains(searchTerm)
            ).ToList();
        }

        // Member management
        public void AddMember(Member member)
        {
            member.Id = nextMemberId++;
            members.Add(member);
        }

        public void UpdateMember(Member member)
        {
            var existingMember = members.FirstOrDefault(m => m.Id == member.Id);
            if (existingMember != null)
            {
                existingMember.FirstName = member.FirstName;
                existingMember.LastName = member.LastName;
                existingMember.Email = member.Email;
                existingMember.Phone = member.Phone;
                existingMember.IsActive = member.IsActive;
            }
        }

        public void DeleteMember(int memberId)
        {
            var member = members.FirstOrDefault(m => m.Id == memberId);
            if (member != null)
            {
                // Check if member has borrowed books
                var hasBorrowedBooks = borrowRecords.Any(br => br.MemberId == memberId && !br.IsReturned);
                if (!hasBorrowedBooks)
                {
                    members.Remove(member);
                }
            }
        }

        public List<Member> GetAllMembers()
        {
            return members.ToList();
        }

        public List<Member> SearchMembers(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return GetAllMembers();

            searchTerm = searchTerm.ToLower();
            return members.Where(m => 
                m.FirstName.ToLower().Contains(searchTerm) ||
                m.LastName.ToLower().Contains(searchTerm) ||
                m.Email.ToLower().Contains(searchTerm)
            ).ToList();
        }

        // Borrowing management
        public bool BorrowBook(int bookId, int memberId)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            var member = members.FirstOrDefault(m => m.Id == memberId);

            if (book != null && member != null && book.IsAvailable && member.IsActive)
            {
                book.IsAvailable = false;
                book.BorrowedByMemberId = memberId;
                book.BorrowDate = DateTime.Now;
                book.DueDate = DateTime.Now.AddDays(14); // 2 weeks loan period

                var borrowRecord = new BorrowRecord
                {
                    Id = nextBorrowId++,
                    BookId = bookId,
                    MemberId = memberId,
                    BorrowDate = DateTime.Now,
                    DueDate = DateTime.Now.AddDays(14),
                    BookTitle = book.Title,
                    MemberName = member.FullName
                };

                borrowRecords.Add(borrowRecord);
                return true;
            }

            return false;
        }

        public bool ReturnBook(int bookId)
        {
            var book = books.FirstOrDefault(b => b.Id == bookId);
            var borrowRecord = borrowRecords.FirstOrDefault(br => br.BookId == bookId && !br.IsReturned);

            if (book != null && borrowRecord != null)
            {
                book.IsAvailable = true;
                book.BorrowedByMemberId = null;
                book.BorrowDate = null;
                book.DueDate = null;

                borrowRecord.IsReturned = true;
                borrowRecord.ReturnDate = DateTime.Now;

                return true;
            }

            return false;
        }

        public List<BorrowRecord> GetAllBorrowRecords()
        {
            return borrowRecords.ToList();
        }

        public List<BorrowRecord> GetActiveBorrowRecords()
        {
            return borrowRecords.Where(br => !br.IsReturned).ToList();
        }

        public List<BorrowRecord> GetOverdueBooks()
        {
            return borrowRecords.Where(br => !br.IsReturned && br.DueDate < DateTime.Now).ToList();
        }

        public Book GetBookById(int bookId)
        {
            return books.FirstOrDefault(b => b.Id == bookId);
        }

        public Member GetMemberById(int memberId)
        {
            return members.FirstOrDefault(m => m.Id == memberId);
        }
    }
}