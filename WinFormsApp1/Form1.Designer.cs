namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabBooks = new System.Windows.Forms.TabPage();
            this.btnDeleteBook = new System.Windows.Forms.Button();
            this.btnEditBook = new System.Windows.Forms.Button();
            this.btnAddBook = new System.Windows.Forms.Button();
            this.txtSearchBooks = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBooks = new System.Windows.Forms.DataGridView();
            this.tabMembers = new System.Windows.Forms.TabPage();
            this.btnDeleteMember = new System.Windows.Forms.Button();
            this.btnEditMember = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.txtSearchMembers = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvMembers = new System.Windows.Forms.DataGridView();
            this.tabBorrowing = new System.Windows.Forms.TabPage();
            this.btnReturnBook = new System.Windows.Forms.Button();
            this.btnBorrowBook = new System.Windows.Forms.Button();
            this.dgvBorrowRecords = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.tabOverdue = new System.Windows.Forms.TabPage();
            this.dgvOverdueBooks = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).BeginInit();
            this.tabMembers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).BeginInit();
            this.tabBorrowing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowRecords)).BeginInit();
            this.tabOverdue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueBooks)).BeginInit();
            this.SuspendLayout();
            
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabBooks);
            this.tabControl1.Controls.Add(this.tabMembers);
            this.tabControl1.Controls.Add(this.tabBorrowing);
            this.tabControl1.Controls.Add(this.tabOverdue);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 700);
            this.tabControl1.TabIndex = 0;
            // 
            // tabBooks
            // 
            this.tabBooks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.tabBooks.Controls.Add(this.btnDeleteBook);
            this.tabBooks.Controls.Add(this.btnEditBook);
            this.tabBooks.Controls.Add(this.btnAddBook);
            this.tabBooks.Controls.Add(this.txtSearchBooks);
            this.tabBooks.Controls.Add(this.label1);
            this.tabBooks.Controls.Add(this.dgvBooks);
            this.tabBooks.Location = new System.Drawing.Point(4, 26);
            this.tabBooks.Name = "tabBooks";
            this.tabBooks.Padding = new System.Windows.Forms.Padding(20);
            this.tabBooks.Size = new System.Drawing.Size(1192, 670);
            this.tabBooks.TabIndex = 0;
            this.tabBooks.Text = "📚 Books";
            this.tabBooks.UseVisualStyleBackColor = false;
            // 
            // btnDeleteBook
            // 
            this.btnDeleteBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteBook.FlatAppearance.BorderSize = 0;
            this.btnDeleteBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteBook.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBook.Location = new System.Drawing.Point(338, 60);
            this.btnDeleteBook.Name = "btnDeleteBook";
            this.btnDeleteBook.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteBook.TabIndex = 5;
            this.btnDeleteBook.Text = "🗑️ Delete";
            this.btnDeleteBook.UseVisualStyleBackColor = false;
            this.btnDeleteBook.Click += new System.EventHandler(this.btnDeleteBook_Click);
            // 
            // btnEditBook
            // 
            this.btnEditBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEditBook.FlatAppearance.BorderSize = 0;
            this.btnEditBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditBook.ForeColor = System.Drawing.Color.Black;
            this.btnEditBook.Location = new System.Drawing.Point(242, 60);
            this.btnEditBook.Name = "btnEditBook";
            this.btnEditBook.Size = new System.Drawing.Size(90, 35);
            this.btnEditBook.TabIndex = 4;
            this.btnEditBook.Text = "✏️ Edit";
            this.btnEditBook.UseVisualStyleBackColor = false;
            this.btnEditBook.Click += new System.EventHandler(this.btnEditBook_Click);
            // 
            // btnAddBook
            // 
            this.btnAddBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddBook.FlatAppearance.BorderSize = 0;
            this.btnAddBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddBook.ForeColor = System.Drawing.Color.White;
            this.btnAddBook.Location = new System.Drawing.Point(130, 60);
            this.btnAddBook.Name = "btnAddBook";
            this.btnAddBook.Size = new System.Drawing.Size(106, 35);
            this.btnAddBook.TabIndex = 3;
            this.btnAddBook.Text = "➕ Add Book";
            this.btnAddBook.UseVisualStyleBackColor = false;
            this.btnAddBook.Click += new System.EventHandler(this.btnAddBook_Click);
            // 
            // txtSearchBooks
            // 
            this.txtSearchBooks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchBooks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchBooks.Location = new System.Drawing.Point(130, 25);
            this.txtSearchBooks.Name = "txtSearchBooks";
            this.txtSearchBooks.PlaceholderText = "Search by title, author, genre, or ISBN...";
            this.txtSearchBooks.Size = new System.Drawing.Size(400, 25);
            this.txtSearchBooks.TabIndex = 2;
            this.txtSearchBooks.TextChanged += new System.EventHandler(this.txtSearchBooks_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.label1.Location = new System.Drawing.Point(23, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "🔍 Search Books:";
            // 
            // dgvBooks
            // 
            this.dgvBooks.AllowUserToAddRows = false;
            this.dgvBooks.AllowUserToDeleteRows = false;
            this.dgvBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBooks.ColumnHeadersHeight = 35;
            this.dgvBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvBooks.Location = new System.Drawing.Point(23, 110);
            this.dgvBooks.MultiSelect = false;
            this.dgvBooks.Name = "dgvBooks";
            this.dgvBooks.ReadOnly = true;
            this.dgvBooks.RowHeadersVisible = false;
            this.dgvBooks.RowTemplate.Height = 30;
            this.dgvBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBooks.Size = new System.Drawing.Size(1146, 537);
            this.dgvBooks.TabIndex = 0;
            // 
            // tabMembers
            // 
            this.tabMembers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.tabMembers.Controls.Add(this.btnDeleteMember);
            this.tabMembers.Controls.Add(this.btnEditMember);
            this.tabMembers.Controls.Add(this.btnAddMember);
            this.tabMembers.Controls.Add(this.txtSearchMembers);
            this.tabMembers.Controls.Add(this.label2);
            this.tabMembers.Controls.Add(this.dgvMembers);
            this.tabMembers.Location = new System.Drawing.Point(4, 26);
            this.tabMembers.Name = "tabMembers";
            this.tabMembers.Padding = new System.Windows.Forms.Padding(20);
            this.tabMembers.Size = new System.Drawing.Size(1192, 670);
            this.tabMembers.TabIndex = 1;
            this.tabMembers.Text = "👥 Members";
            this.tabMembers.UseVisualStyleBackColor = false;
            // 
            // btnDeleteMember
            // 
            this.btnDeleteMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteMember.FlatAppearance.BorderSize = 0;
            this.btnDeleteMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteMember.ForeColor = System.Drawing.Color.White;
            this.btnDeleteMember.Location = new System.Drawing.Point(358, 60);
            this.btnDeleteMember.Name = "btnDeleteMember";
            this.btnDeleteMember.Size = new System.Drawing.Size(90, 35);
            this.btnDeleteMember.TabIndex = 11;
            this.btnDeleteMember.Text = "🗑️ Delete";
            this.btnDeleteMember.UseVisualStyleBackColor = false;
            this.btnDeleteMember.Click += new System.EventHandler(this.btnDeleteMember_Click);
            // 
            // btnEditMember
            // 
            this.btnEditMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnEditMember.FlatAppearance.BorderSize = 0;
            this.btnEditMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnEditMember.ForeColor = System.Drawing.Color.Black;
            this.btnEditMember.Location = new System.Drawing.Point(262, 60);
            this.btnEditMember.Name = "btnEditMember";
            this.btnEditMember.Size = new System.Drawing.Size(90, 35);
            this.btnEditMember.TabIndex = 10;
            this.btnEditMember.Text = "✏️ Edit";
            this.btnEditMember.UseVisualStyleBackColor = false;
            this.btnEditMember.Click += new System.EventHandler(this.btnEditMember_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAddMember.FlatAppearance.BorderSize = 0;
            this.btnAddMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddMember.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddMember.ForeColor = System.Drawing.Color.White;
            this.btnAddMember.Location = new System.Drawing.Point(130, 60);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(126, 35);
            this.btnAddMember.TabIndex = 9;
            this.btnAddMember.Text = "➕ Add Member";
            this.btnAddMember.UseVisualStyleBackColor = false;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // txtSearchMembers
            // 
            this.txtSearchMembers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchMembers.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearchMembers.Location = new System.Drawing.Point(150, 25);
            this.txtSearchMembers.Name = "txtSearchMembers";
            this.txtSearchMembers.PlaceholderText = "Search by name or email...";
            this.txtSearchMembers.Size = new System.Drawing.Size(400, 25);
            this.txtSearchMembers.TabIndex = 8;
            this.txtSearchMembers.TextChanged += new System.EventHandler(this.txtSearchMembers_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.label2.Location = new System.Drawing.Point(23, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "🔍 Search Members:";
            // 
            // dgvMembers
            // 
            this.dgvMembers.AllowUserToAddRows = false;
            this.dgvMembers.AllowUserToDeleteRows = false;
            this.dgvMembers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMembers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMembers.BackgroundColor = System.Drawing.Color.White;
            this.dgvMembers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvMembers.ColumnHeadersHeight = 35;
            this.dgvMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvMembers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvMembers.Location = new System.Drawing.Point(23, 110);
            this.dgvMembers.MultiSelect = false;
            this.dgvMembers.Name = "dgvMembers";
            this.dgvMembers.ReadOnly = true;
            this.dgvMembers.RowHeadersVisible = false;
            this.dgvMembers.RowTemplate.Height = 30;
            this.dgvMembers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMembers.Size = new System.Drawing.Size(1146, 537);
            this.dgvMembers.TabIndex = 6;
            // 
            // tabBorrowing
            // 
            this.tabBorrowing.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.tabBorrowing.Controls.Add(this.btnReturnBook);
            this.tabBorrowing.Controls.Add(this.btnBorrowBook);
            this.tabBorrowing.Controls.Add(this.dgvBorrowRecords);
            this.tabBorrowing.Controls.Add(this.label3);
            this.tabBorrowing.Location = new System.Drawing.Point(4, 26);
            this.tabBorrowing.Name = "tabBorrowing";
            this.tabBorrowing.Padding = new System.Windows.Forms.Padding(20);
            this.tabBorrowing.Size = new System.Drawing.Size(1192, 670);
            this.tabBorrowing.TabIndex = 2;
            this.tabBorrowing.Text = "📖 Borrowing";
            this.tabBorrowing.UseVisualStyleBackColor = false;
            // 
            // btnReturnBook
            // 
            this.btnReturnBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(110)))), ((int)(((byte)(253)))));
            this.btnReturnBook.FlatAppearance.BorderSize = 0;
            this.btnReturnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReturnBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnReturnBook.ForeColor = System.Drawing.Color.White;
            this.btnReturnBook.Location = new System.Drawing.Point(242, 25);
            this.btnReturnBook.Name = "btnReturnBook";
            this.btnReturnBook.Size = new System.Drawing.Size(126, 35);
            this.btnReturnBook.TabIndex = 15;
            this.btnReturnBook.Text = "📥 Return Book";
            this.btnReturnBook.UseVisualStyleBackColor = false;
            this.btnReturnBook.Click += new System.EventHandler(this.btnReturnBook_Click);
            // 
            // btnBorrowBook
            // 
            this.btnBorrowBook.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnBorrowBook.FlatAppearance.BorderSize = 0;
            this.btnBorrowBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrowBook.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnBorrowBook.ForeColor = System.Drawing.Color.White;
            this.btnBorrowBook.Location = new System.Drawing.Point(80, 25);
            this.btnBorrowBook.Name = "btnBorrowBook";
            this.btnBorrowBook.Size = new System.Drawing.Size(126, 35);
            this.btnBorrowBook.TabIndex = 14;
            this.btnBorrowBook.Text = "📤 Borrow Book";
            this.btnBorrowBook.UseVisualStyleBackColor = false;
            this.btnBorrowBook.Click += new System.EventHandler(this.btnBorrowBook_Click);
            // 
            // dgvBorrowRecords
            // 
            this.dgvBorrowRecords.AllowUserToAddRows = false;
            this.dgvBorrowRecords.AllowUserToDeleteRows = false;
            this.dgvBorrowRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBorrowRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBorrowRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvBorrowRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBorrowRecords.ColumnHeadersHeight = 35;
            this.dgvBorrowRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvBorrowRecords.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvBorrowRecords.Location = new System.Drawing.Point(23, 80);
            this.dgvBorrowRecords.MultiSelect = false;
            this.dgvBorrowRecords.Name = "dgvBorrowRecords";
            this.dgvBorrowRecords.ReadOnly = true;
            this.dgvBorrowRecords.RowHeadersVisible = false;
            this.dgvBorrowRecords.RowTemplate.Height = 30;
            this.dgvBorrowRecords.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBorrowRecords.Size = new System.Drawing.Size(1146, 567);
            this.dgvBorrowRecords.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.label3.Location = new System.Drawing.Point(23, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Actions:";
            // 
            // tabOverdue
            // 
            this.tabOverdue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(243)))), ((int)(((byte)(243)))));
            this.tabOverdue.Controls.Add(this.dgvOverdueBooks);
            this.tabOverdue.Controls.Add(this.label4);
            this.tabOverdue.Location = new System.Drawing.Point(4, 26);
            this.tabOverdue.Name = "tabOverdue";
            this.tabOverdue.Padding = new System.Windows.Forms.Padding(20);
            this.tabOverdue.Size = new System.Drawing.Size(1192, 670);
            this.tabOverdue.TabIndex = 3;
            this.tabOverdue.Text = "⚠️ Overdue Books";
            this.tabOverdue.UseVisualStyleBackColor = false;
            // 
            // dgvOverdueBooks
            // 
            this.dgvOverdueBooks.AllowUserToAddRows = false;
            this.dgvOverdueBooks.AllowUserToDeleteRows = false;
            this.dgvOverdueBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOverdueBooks.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvOverdueBooks.BackgroundColor = System.Drawing.Color.White;
            this.dgvOverdueBooks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvOverdueBooks.ColumnHeadersHeight = 35;
            this.dgvOverdueBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvOverdueBooks.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.dgvOverdueBooks.Location = new System.Drawing.Point(23, 60);
            this.dgvOverdueBooks.MultiSelect = false;
            this.dgvOverdueBooks.Name = "dgvOverdueBooks";
            this.dgvOverdueBooks.ReadOnly = true;
            this.dgvOverdueBooks.RowHeadersVisible = false;
            this.dgvOverdueBooks.RowTemplate.Height = 30;
            this.dgvOverdueBooks.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOverdueBooks.Size = new System.Drawing.Size(1146, 587);
            this.dgvOverdueBooks.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.label4.Location = new System.Drawing.Point(23, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(277, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "⚠️ Books that are overdue for return";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = null;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "Form1";
            this.Text = "📚 Library Management System - Professional Edition";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabBooks.ResumeLayout(false);
            this.tabBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooks)).EndInit();
            this.tabMembers.ResumeLayout(false);
            this.tabMembers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMembers)).EndInit();
            this.tabBorrowing.ResumeLayout(false);
            this.tabBorrowing.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBorrowRecords)).EndInit();
            this.tabOverdue.ResumeLayout(false);
            this.tabOverdue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverdueBooks)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabBooks;
        private DataGridView dgvBooks;
        private TabPage tabMembers;
        private TabPage tabBorrowing;
        private TabPage tabOverdue;
        private Button btnDeleteBook;
        private Button btnEditBook;
        private Button btnAddBook;
        private TextBox txtSearchBooks;
        private Label label1;
        private Button btnDeleteMember;
        private Button btnEditMember;
        private Button btnAddMember;
        private TextBox txtSearchMembers;
        private Label label2;
        private DataGridView dgvMembers;
        private Button btnReturnBook;
        private Button btnBorrowBook;
        private DataGridView dgvBorrowRecords;
        private Label label3;
        private DataGridView dgvOverdueBooks;
        private Label label4;
    }
}
