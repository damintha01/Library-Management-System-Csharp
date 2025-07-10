using System.ComponentModel;

namespace WinFormsApp1
{
    public partial class BorrowBookForm : Form
    {
        private LibraryManager libraryManager;
        private List<Book> availableBooks;
        private List<Member> activeMembers;

        public BorrowBookForm(LibraryManager manager)
        {
            InitializeComponent();
            ApplyCustomStyling();
            libraryManager = manager;
            LoadData();
        }

        private void ApplyCustomStyling()
        {
            // Form styling
            this.BackColor = Color.FromArgb(248, 249, 250);
            
            // Add hover effects for buttons
            AddHoverEffect(btnBorrow, Color.FromArgb(40, 167, 69), Color.FromArgb(32, 134, 55));
            AddHoverEffect(btnCancel, Color.FromArgb(108, 117, 125), Color.FromArgb(90, 98, 104));
            
            // Style combo boxes
            StyleComboBox(cmbBooks);
            StyleComboBox(cmbMembers);
            
            // Style info labels
            lblBookInfo.Font = new Font("Segoe UI", 9F);
            lblBookInfo.ForeColor = Color.FromArgb(73, 80, 87);
            lblBookInfo.BackColor = Color.White;
            lblBookInfo.BorderStyle = BorderStyle.FixedSingle;
            lblBookInfo.Padding = new Padding(10);
            
            lblMemberInfo.Font = new Font("Segoe UI", 9F);
            lblMemberInfo.ForeColor = Color.FromArgb(73, 80, 87);
            lblMemberInfo.BackColor = Color.White;
            lblMemberInfo.BorderStyle = BorderStyle.FixedSingle;
            lblMemberInfo.Padding = new Padding(10);
        }

        private void StyleComboBox(ComboBox comboBox)
        {
            comboBox.Font = new Font("Segoe UI", 10F);
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = Color.FromArgb(33, 37, 41);
        }

        private void AddHoverEffect(Button button, Color normalColor, Color hoverColor)
        {
            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = normalColor;
        }

        private void LoadData()
        {
            // Load available books
            availableBooks = libraryManager.GetAllBooks().Where(b => b.IsAvailable).ToList();
            cmbBooks.DataSource = availableBooks;
            cmbBooks.DisplayMember = "Title";
            cmbBooks.ValueMember = "Id";

            // Load active members
            activeMembers = libraryManager.GetAllMembers().Where(m => m.IsActive).ToList();
            cmbMembers.DataSource = activeMembers;
            cmbMembers.DisplayMember = "FullName";
            cmbMembers.ValueMember = "Id";

            // Set default due date (2 weeks from now)
            dtpDueDate.Value = DateTime.Now.AddDays(14);
        }

        private void cmbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBooks.SelectedItem is Book selectedBook)
            {
                lblBookInfo.Text = $"?? Author: {selectedBook.Author}\n?? Genre: {selectedBook.Genre}\n?? ISBN: {selectedBook.ISBN}\n?? Published: {selectedBook.PublicationDate.ToShortDateString()}";
            }
        }

        private void cmbMembers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMembers.SelectedItem is Member selectedMember)
            {
                lblMemberInfo.Text = $"?? Email: {selectedMember.Email}\n?? Phone: {selectedMember.Phone}\n?? Member Since: {selectedMember.MembershipDate.ToShortDateString()}\n? Status: {(selectedMember.IsActive ? "Active" : "Inactive")}";
            }
        }

        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (cmbBooks.SelectedValue == null || cmbMembers.SelectedValue == null)
            {
                MessageBox.Show("Please select both a book and a member.", "Selection Required", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var bookId = (int)cmbBooks.SelectedValue;
            var memberId = (int)cmbMembers.SelectedValue;

            if (libraryManager.BorrowBook(bookId, memberId))
            {
                MessageBox.Show("Book borrowed successfully!", "Success", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to borrow book. Please check if the book is available and the member is active.", 
                    "Borrow Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

    partial class BorrowBookForm
    {
        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblSelectBook = new Label();
            this.cmbBooks = new ComboBox();
            this.lblBookInfo = new Label();
            this.lblSelectMember = new Label();
            this.cmbMembers = new ComboBox();
            this.lblMemberInfo = new Label();
            this.lblDueDate = new Label();
            this.dtpDueDate = new DateTimePicker();
            this.btnBorrow = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblSelectBook
            this.lblSelectBook.AutoSize = true;
            this.lblSelectBook.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSelectBook.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblSelectBook.Location = new Point(20, 25);
            this.lblSelectBook.Name = "lblSelectBook";
            this.lblSelectBook.Size = new Size(89, 19);
            this.lblSelectBook.TabIndex = 0;
            this.lblSelectBook.Text = "?? Select Book:";

            // cmbBooks
            this.cmbBooks.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbBooks.Font = new Font("Segoe UI", 10F);
            this.cmbBooks.FormattingEnabled = true;
            this.cmbBooks.Location = new Point(130, 22);
            this.cmbBooks.Name = "cmbBooks";
            this.cmbBooks.Size = new Size(370, 25);
            this.cmbBooks.TabIndex = 1;
            this.cmbBooks.SelectedIndexChanged += new EventHandler(this.cmbBooks_SelectedIndexChanged);

            // lblBookInfo
            this.lblBookInfo.Font = new Font("Segoe UI", 9F);
            this.lblBookInfo.Location = new Point(130, 55);
            this.lblBookInfo.Name = "lblBookInfo";
            this.lblBookInfo.Size = new Size(370, 80);
            this.lblBookInfo.TabIndex = 2;
            this.lblBookInfo.Text = "?? Select a book to see details";

            // lblSelectMember
            this.lblSelectMember.AutoSize = true;
            this.lblSelectMember.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblSelectMember.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblSelectMember.Location = new Point(20, 155);
            this.lblSelectMember.Name = "lblSelectMember";
            this.lblSelectMember.Size = new Size(104, 19);
            this.lblSelectMember.TabIndex = 3;
            this.lblSelectMember.Text = "?? Select Member:";

            // cmbMembers
            this.cmbMembers.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbMembers.Font = new Font("Segoe UI", 10F);
            this.cmbMembers.FormattingEnabled = true;
            this.cmbMembers.Location = new Point(130, 152);
            this.cmbMembers.Name = "cmbMembers";
            this.cmbMembers.Size = new Size(370, 25);
            this.cmbMembers.TabIndex = 4;
            this.cmbMembers.SelectedIndexChanged += new EventHandler(this.cmbMembers_SelectedIndexChanged);

            // lblMemberInfo
            this.lblMemberInfo.Font = new Font("Segoe UI", 9F);
            this.lblMemberInfo.Location = new Point(130, 185);
            this.lblMemberInfo.Name = "lblMemberInfo";
            this.lblMemberInfo.Size = new Size(370, 80);
            this.lblMemberInfo.TabIndex = 5;
            this.lblMemberInfo.Text = "?? Select a member to see details";

            // lblDueDate
            this.lblDueDate.AutoSize = true;
            this.lblDueDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblDueDate.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblDueDate.Location = new Point(20, 285);
            this.lblDueDate.Name = "lblDueDate";
            this.lblDueDate.Size = new Size(78, 19);
            this.lblDueDate.TabIndex = 6;
            this.lblDueDate.Text = "?? Due Date:";

            // dtpDueDate
            this.dtpDueDate.Font = new Font("Segoe UI", 10F);
            this.dtpDueDate.Format = DateTimePickerFormat.Short;
            this.dtpDueDate.Location = new Point(130, 282);
            this.dtpDueDate.Name = "dtpDueDate";
            this.dtpDueDate.Size = new Size(200, 25);
            this.dtpDueDate.TabIndex = 7;

            // btnBorrow
            this.btnBorrow.BackColor = Color.FromArgb(40, 167, 69);
            this.btnBorrow.FlatAppearance.BorderSize = 0;
            this.btnBorrow.FlatStyle = FlatStyle.Flat;
            this.btnBorrow.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnBorrow.ForeColor = Color.White;
            this.btnBorrow.Location = new Point(324, 330);
            this.btnBorrow.Name = "btnBorrow";
            this.btnBorrow.Size = new Size(85, 35);
            this.btnBorrow.TabIndex = 8;
            this.btnBorrow.Text = "?? Borrow";
            this.btnBorrow.UseVisualStyleBackColor = false;
            this.btnBorrow.Click += new EventHandler(this.btnBorrow_Click);

            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(415, 330);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(85, 35);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "? Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // BorrowBookForm
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(530, 390);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBorrow);
            this.Controls.Add(this.dtpDueDate);
            this.Controls.Add(this.lblDueDate);
            this.Controls.Add(this.lblMemberInfo);
            this.Controls.Add(this.cmbMembers);
            this.Controls.Add(this.lblSelectMember);
            this.Controls.Add(this.lblBookInfo);
            this.Controls.Add(this.cmbBooks);
            this.Controls.Add(this.lblSelectBook);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BorrowBookForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "?? Borrow Book";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblSelectBook;
        private ComboBox cmbBooks;
        private Label lblBookInfo;
        private Label lblSelectMember;
        private ComboBox cmbMembers;
        private Label lblMemberInfo;
        private Label lblDueDate;
        private DateTimePicker dtpDueDate;
        private Button btnBorrow;
        private Button btnCancel;
    }
}