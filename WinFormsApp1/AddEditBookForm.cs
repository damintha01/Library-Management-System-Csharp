using System.ComponentModel;

namespace WinFormsApp1
{
    public partial class AddEditBookForm : Form
    {
        public Book Book { get; private set; }

        public AddEditBookForm(Book book = null)
        {
            InitializeComponent();
            ApplyCustomStyling();
            
            if (book != null)
            {
                Book = new Book
                {
                    Id = book.Id,
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    Genre = book.Genre,
                    PublicationDate = book.PublicationDate,
                    IsAvailable = book.IsAvailable,
                    BorrowedByMemberId = book.BorrowedByMemberId,
                    BorrowDate = book.BorrowDate,
                    DueDate = book.DueDate
                };
                
                txtTitle.Text = book.Title;
                txtAuthor.Text = book.Author;
                txtISBN.Text = book.ISBN;
                txtGenre.Text = book.Genre;
                dtpPublicationDate.Value = book.PublicationDate;
                
                this.Text = "?? Edit Book";
            }
            else
            {
                Book = new Book();
                dtpPublicationDate.Value = DateTime.Now;
                this.Text = "? Add New Book";
            }
        }

        private void ApplyCustomStyling()
        {
            // Form styling
            this.BackColor = Color.FromArgb(248, 249, 250);
            
            // Add hover effects for buttons
            AddHoverEffect(btnSave, Color.FromArgb(40, 167, 69), Color.FromArgb(32, 134, 55));
            AddHoverEffect(btnCancel, Color.FromArgb(108, 117, 125), Color.FromArgb(90, 98, 104));
            
            // Style text boxes
            StyleTextBox(txtTitle);
            StyleTextBox(txtAuthor);
            StyleTextBox(txtISBN);
            StyleTextBox(txtGenre);
        }

        private void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Segoe UI", 10F);
            textBox.BackColor = Color.White;
            textBox.ForeColor = Color.FromArgb(33, 37, 41);
        }

        private void AddHoverEffect(Button button, Color normalColor, Color hoverColor)
        {
            button.MouseEnter += (s, e) => button.BackColor = hoverColor;
            button.MouseLeave += (s, e) => button.BackColor = normalColor;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                Book.Title = txtTitle.Text.Trim();
                Book.Author = txtAuthor.Text.Trim();
                Book.ISBN = txtISBN.Text.Trim();
                Book.Genre = txtGenre.Text.Trim();
                Book.PublicationDate = dtpPublicationDate.Value;
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Author is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAuthor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtISBN.Text))
            {
                MessageBox.Show("ISBN is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtISBN.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGenre.Text))
            {
                MessageBox.Show("Genre is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGenre.Focus();
                return false;
            }

            return true;
        }
    }

    partial class AddEditBookForm
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
            this.lblTitle = new Label();
            this.txtTitle = new TextBox();
            this.lblAuthor = new Label();
            this.txtAuthor = new TextBox();
            this.lblISBN = new Label();
            this.txtISBN = new TextBox();
            this.lblGenre = new Label();
            this.txtGenre = new TextBox();
            this.lblPublicationDate = new Label();
            this.dtpPublicationDate = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblTitle.Location = new Point(20, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(45, 19);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? Title:";

            // txtTitle
            this.txtTitle.Font = new Font("Segoe UI", 10F);
            this.txtTitle.Location = new Point(150, 22);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new Size(280, 25);
            this.txtTitle.TabIndex = 1;

            // lblAuthor
            this.lblAuthor.AutoSize = true;
            this.lblAuthor.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblAuthor.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblAuthor.Location = new Point(20, 60);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new Size(64, 19);
            this.lblAuthor.TabIndex = 2;
            this.lblAuthor.Text = "?? Author:";

            // txtAuthor
            this.txtAuthor.Font = new Font("Segoe UI", 10F);
            this.txtAuthor.Location = new Point(150, 57);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new Size(280, 25);
            this.txtAuthor.TabIndex = 3;

            // lblISBN
            this.lblISBN.AutoSize = true;
            this.lblISBN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblISBN.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblISBN.Location = new Point(20, 95);
            this.lblISBN.Name = "lblISBN";
            this.lblISBN.Size = new Size(56, 19);
            this.lblISBN.TabIndex = 4;
            this.lblISBN.Text = "?? ISBN:";

            // txtISBN
            this.txtISBN.Font = new Font("Segoe UI", 10F);
            this.txtISBN.Location = new Point(150, 92);
            this.txtISBN.Name = "txtISBN";
            this.txtISBN.Size = new Size(280, 25);
            this.txtISBN.TabIndex = 5;

            // lblGenre
            this.lblGenre.AutoSize = true;
            this.lblGenre.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblGenre.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblGenre.Location = new Point(20, 130);
            this.lblGenre.Name = "lblGenre";
            this.lblGenre.Size = new Size(58, 19);
            this.lblGenre.TabIndex = 6;
            this.lblGenre.Text = "?? Genre:";

            // txtGenre
            this.txtGenre.Font = new Font("Segoe UI", 10F);
            this.txtGenre.Location = new Point(150, 127);
            this.txtGenre.Name = "txtGenre";
            this.txtGenre.Size = new Size(280, 25);
            this.txtGenre.TabIndex = 7;

            // lblPublicationDate
            this.lblPublicationDate.AutoSize = true;
            this.lblPublicationDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPublicationDate.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblPublicationDate.Location = new Point(20, 165);
            this.lblPublicationDate.Name = "lblPublicationDate";
            this.lblPublicationDate.Size = new Size(124, 19);
            this.lblPublicationDate.TabIndex = 8;
            this.lblPublicationDate.Text = "?? Publication Date:";

            // dtpPublicationDate
            this.dtpPublicationDate.Font = new Font("Segoe UI", 10F);
            this.dtpPublicationDate.Format = DateTimePickerFormat.Short;
            this.dtpPublicationDate.Location = new Point(150, 162);
            this.dtpPublicationDate.Name = "dtpPublicationDate";
            this.dtpPublicationDate.Size = new Size(280, 25);
            this.dtpPublicationDate.TabIndex = 9;

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(40, 167, 69);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(254, 210);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(85, 35);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "?? Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(345, 210);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(85, 35);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "? Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // AddEditBookForm
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(460, 270);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dtpPublicationDate);
            this.Controls.Add(this.lblPublicationDate);
            this.Controls.Add(this.txtGenre);
            this.Controls.Add(this.lblGenre);
            this.Controls.Add(this.txtISBN);
            this.Controls.Add(this.lblISBN);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditBookForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Book Form";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblTitle;
        private TextBox txtTitle;
        private Label lblAuthor;
        private TextBox txtAuthor;
        private Label lblISBN;
        private TextBox txtISBN;
        private Label lblGenre;
        private TextBox txtGenre;
        private Label lblPublicationDate;
        private DateTimePicker dtpPublicationDate;
        private Button btnSave;
        private Button btnCancel;
    }
}