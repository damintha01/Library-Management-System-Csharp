using System;

namespace WinFormsApp1
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Genre { get; set; } = string.Empty;
        public DateTime PublicationDate { get; set; }
        public bool IsAvailable { get; set; } = true;
        public int? BorrowedByMemberId { get; set; }
        public DateTime? BorrowDate { get; set; }
        public DateTime? DueDate { get; set; }

        public override string ToString()
        {
            return $"{Title} by {Author} - {(IsAvailable ? "Available" : "Borrowed")}";
        }
    }
}