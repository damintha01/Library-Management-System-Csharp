using System;

namespace WinFormsApp1
{
    public class BorrowRecord
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public bool IsReturned { get; set; } = false;

        // Navigation properties (for display purposes)
        public string BookTitle { get; set; } = string.Empty;
        public string MemberName { get; set; } = string.Empty;
    }
}