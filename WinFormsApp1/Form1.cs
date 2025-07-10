using System.ComponentModel;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private LibraryManager libraryManager;

        public Form1()
        {
            InitializeComponent();
            libraryManager = new LibraryManager();
            ApplyCustomStyling();
        }

        private void ApplyCustomStyling()
        {
            // Style DataGridViews
            StyleDataGridView(dgvBooks);
            StyleDataGridView(dgvMembers);
            StyleDataGridView(dgvBorrowRecords);
            StyleDataGridView(dgvOverdueBooks);

            // Add button hover effects
            AddButtonHoverEffects();
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            // Header styling
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 58, 64);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);

            // Row styling
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(13, 110, 253);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5, 8, 5, 8);

            // Alternating row colors
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 249, 250);
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = Color.FromArgb(33, 37, 41);

            // Grid styling
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(222, 226, 230);
        }

        private void AddButtonHoverEffects()
        {
            // Add hover effects for buttons
            AddHoverEffect(btnAddBook, Color.FromArgb(40, 167, 69), Color.FromArgb(32, 134, 55));
            AddHoverEffect(btnEditBook, Color.FromArgb(255, 193, 7), Color.FromArgb(217, 164, 6));
            AddHoverEffect(btnDeleteBook, Color.FromArgb(220, 53, 69), Color.FromArgb(200, 35, 51));

            AddHoverEffect(btnAddMember, Color.FromArgb(40, 167, 69), Color.FromArgb(32, 134, 55));
            AddHoverEffect(btnEditMember, Color.FromArgb(255, 193, 7), Color.FromArgb(217, 164, 6));
            AddHoverEffect(btnDeleteMember, Color.FromArgb(220, 53, 69), Color.FromArgb(200, 35, 51));

            AddHoverEffect(btnBorrowBook, Color.FromArgb(40, 167, 69), Color.FromArgb(32, 134, 55));
            AddHoverEffect(btnReturnBook, Color.FromArgb(13, 110, 253), Color.FromArgb(11, 94, 215));
        }

        private void AddHoverEffect(Button button, Color normalColor, Color hoverColor)
        {
            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = normalColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadBooks();
            LoadMembers();
            LoadBorrowRecords();
            LoadOverdueBooks();
        }

        #region Books Management

        private void LoadBooks()
        {
            var books = libraryManager.GetAllBooks();
            var bookDisplay = books.Select(b => new
            {
                ID = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                Genre = b.Genre,
                PublicationDate = b.PublicationDate.ToShortDateString(),
                Status = b.IsAvailable ? "? Available" : "?? Borrowed",
                BorrowedBy = b.BorrowedByMemberId.HasValue ?
                    libraryManager.GetMemberById(b.BorrowedByMemberId.Value)?.FullName : "",
                DueDate = b.DueDate?.ToShortDateString()
            }).ToList();

            dgvBooks.DataSource = bookDisplay;

            // Style specific columns
            if (dgvBooks.Columns["Status"] != null)
            {
                dgvBooks.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void txtSearchBooks_TextChanged(object sender, EventArgs e)
        {
            var searchTerm = txtSearchBooks.Text;
            var books = libraryManager.SearchBooks(searchTerm);
            var bookDisplay = books.Select(b => new
            {
                ID = b.Id,
                Title = b.Title,
                Author = b.Author,
                ISBN = b.ISBN,
                Genre = b.Genre,
                PublicationDate = b.PublicationDate.ToShortDateString(),
                Status = b.IsAvailable ? "? Available" : "?? Borrowed",
                BorrowedBy = b.BorrowedByMemberId.HasValue ?
                    libraryManager.GetMemberById(b.BorrowedByMemberId.Value)?.FullName : "",
                DueDate = b.DueDate?.ToShortDateString()
            }).ToList();

            dgvBooks.DataSource = bookDisplay;
        }

        private void btnAddBook_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditBookForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    libraryManager.AddBook(form.Book);
                    LoadBooks();
                }
            }
        }

        private void btnEditBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var bookId = (int)dgvBooks.SelectedRows[0].Cells["ID"].Value;
                var book = libraryManager.GetBookById(bookId);

                using (var form = new AddEditBookForm(book))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        libraryManager.UpdateBook(form.Book);
                        LoadBooks();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a book to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteBook_Click(object sender, EventArgs e)
        {
            if (dgvBooks.SelectedRows.Count > 0)
            {
                var bookId = (int)dgvBooks.SelectedRows[0].Cells["ID"].Value;
                var book = libraryManager.GetBookById(bookId);

                if (book != null && !book.IsAvailable)
                {
                    MessageBox.Show("Cannot delete a book that is currently borrowed.", "Cannot Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Are you sure you want to delete '{book?.Title}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    libraryManager.DeleteBook(bookId);
                    LoadBooks();
                }
            }
            else
            {
                MessageBox.Show("Please select a book to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Members Management

        private void LoadMembers()
        {
            var members = libraryManager.GetAllMembers();
            var memberDisplay = members.Select(m => new
            {
                ID = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                Phone = m.Phone,
                MembershipDate = m.MembershipDate.ToShortDateString(),
                Status = m.IsActive ? "? Active" : "? Inactive"
            }).ToList();

            dgvMembers.DataSource = memberDisplay;

            // Style specific columns
            if (dgvMembers.Columns["Status"] != null)
            {
                dgvMembers.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void txtSearchMembers_TextChanged(object sender, EventArgs e)
        {
            var searchTerm = txtSearchMembers.Text;
            var members = libraryManager.SearchMembers(searchTerm);
            var memberDisplay = members.Select(m => new
            {
                ID = m.Id,
                FirstName = m.FirstName,
                LastName = m.LastName,
                Email = m.Email,
                Phone = m.Phone,
                MembershipDate = m.MembershipDate.ToShortDateString(),
                Status = m.IsActive ? "? Active" : "? Inactive"
            }).ToList();

            dgvMembers.DataSource = memberDisplay;
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            using (var form = new AddEditMemberForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    libraryManager.AddMember(form.Member);
                    LoadMembers();
                }
            }
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                var memberId = (int)dgvMembers.SelectedRows[0].Cells["ID"].Value;
                var member = libraryManager.GetMemberById(memberId);

                using (var form = new AddEditMemberForm(member))
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        libraryManager.UpdateMember(form.Member);
                        LoadMembers();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a member to edit.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteMember_Click(object sender, EventArgs e)
        {
            if (dgvMembers.SelectedRows.Count > 0)
            {
                var memberId = (int)dgvMembers.SelectedRows[0].Cells["ID"].Value;
                var member = libraryManager.GetMemberById(memberId);

                var activeBorrows = libraryManager.GetActiveBorrowRecords()
                    .Where(br => br.MemberId == memberId).ToList();

                if (activeBorrows.Any())
                {
                    MessageBox.Show("Cannot delete a member who has borrowed books.", "Cannot Delete",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show($"Are you sure you want to delete member '{member?.FullName}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    libraryManager.DeleteMember(memberId);
                    LoadMembers();
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Borrowing Management

        private void LoadBorrowRecords()
        {
            var borrowRecords = libraryManager.GetActiveBorrowRecords();
            var recordDisplay = borrowRecords.Select(br => new
            {
                ID = br.Id,
                BookTitle = br.BookTitle,
                MemberName = br.MemberName,
                BorrowDate = br.BorrowDate.ToShortDateString(),
                DueDate = br.DueDate.ToShortDateString(),
                DaysOverdue = br.DueDate < DateTime.Now ? (DateTime.Now - br.DueDate).Days : 0,
                Status = br.DueDate < DateTime.Now ? "?? Overdue" : "? On Time"
            }).ToList();

            dgvBorrowRecords.DataSource = recordDisplay;

            // Style specific columns
            if (dgvBorrowRecords.Columns["Status"] != null)
            {
                dgvBorrowRecords.Columns["Status"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }
        }

        private void btnBorrowBook_Click(object sender, EventArgs e)
        {
            using (var form = new BorrowBookForm(libraryManager))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadBooks();
                    LoadBorrowRecords();
                    LoadOverdueBooks();
                }
            }
        }

        private void btnReturnBook_Click(object sender, EventArgs e)
        {
            if (dgvBorrowRecords.SelectedRows.Count > 0)
            {
                var borrowId = (int)dgvBorrowRecords.SelectedRows[0].Cells["ID"].Value;
                var borrowRecord = libraryManager.GetActiveBorrowRecords()
                    .FirstOrDefault(br => br.Id == borrowId);

                if (borrowRecord != null)
                {
                    var result = MessageBox.Show($"Return book '{borrowRecord.BookTitle}' borrowed by '{borrowRecord.MemberName}'?",
                        "Confirm Return", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        libraryManager.ReturnBook(borrowRecord.BookId);
                        LoadBooks();
                        LoadBorrowRecords();
                        LoadOverdueBooks();
                        MessageBox.Show("Book returned successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a borrow record to return.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region Overdue Books

        private void LoadOverdueBooks()
        {
            var overdueBooks = libraryManager.GetOverdueBooks();
            var overdueDisplay = overdueBooks.Select(br => new
            {
                BookTitle = br.BookTitle,
                MemberName = br.MemberName,
                BorrowDate = br.BorrowDate.ToShortDateString(),
                DueDate = br.DueDate.ToShortDateString(),
                DaysOverdue = (DateTime.Now - br.DueDate).Days
            }).ToList();

            dgvOverdueBooks.DataSource = overdueDisplay;

            // Special styling for overdue grid
            if (dgvOverdueBooks.Columns["DaysOverdue"] != null)
            {
                dgvOverdueBooks.Columns["DaysOverdue"].DefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                dgvOverdueBooks.Columns["DaysOverdue"].DefaultCellStyle.ForeColor = Color.FromArgb(220, 53, 69);
            }
        }

        #endregion
    }
}
