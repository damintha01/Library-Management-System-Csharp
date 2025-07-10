using System.ComponentModel;
using System.Drawing;

namespace WinFormsApp1
{
    public partial class AddEditMemberForm : Form
    {
        public Member Member { get; private set; }

        public AddEditMemberForm(Member member = null)
        {
            InitializeComponent();
            ApplyCustomStyling();
            
            if (member != null)
            {
                Member = new Member
                {
                    Id = member.Id,
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,
                    Phone = member.Phone,
                    MembershipDate = member.MembershipDate,
                    IsActive = member.IsActive
                };
                
                txtFirstName.Text = member.FirstName;
                txtLastName.Text = member.LastName;
                txtEmail.Text = member.Email;
                txtPhone.Text = member.Phone;
                dtpMembershipDate.Value = member.MembershipDate;
                chkIsActive.Checked = member.IsActive;
                
                this.Text = "?? Edit Member";
            }
            else
            {
                Member = new Member();
                dtpMembershipDate.Value = DateTime.Now;
                chkIsActive.Checked = true;
                this.Text = "? Add New Member";
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
            StyleTextBox(txtFirstName);
            StyleTextBox(txtLastName);
            StyleTextBox(txtEmail);
            StyleTextBox(txtPhone);
            
            // Style checkbox
            chkIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            chkIsActive.ForeColor = Color.FromArgb(40, 167, 69);
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
                Member.FirstName = txtFirstName.Text.Trim();
                Member.LastName = txtLastName.Text.Trim();
                Member.Email = txtEmail.Text.Trim();
                Member.Phone = txtPhone.Text.Trim();
                Member.MembershipDate = dtpMembershipDate.Value;
                Member.IsActive = chkIsActive.Checked;
                
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
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFirstName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtLastName.Text))
            {
                MessageBox.Show("Last Name is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLastName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email is required.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return false;
            }

            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }

    partial class AddEditMemberForm
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
            this.lblFirstName = new Label();
            this.txtFirstName = new TextBox();
            this.lblLastName = new Label();
            this.txtLastName = new TextBox();
            this.lblEmail = new Label();
            this.txtEmail = new TextBox();
            this.lblPhone = new Label();
            this.txtPhone = new TextBox();
            this.lblMembershipDate = new Label();
            this.dtpMembershipDate = new DateTimePicker();
            this.chkIsActive = new CheckBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.SuspendLayout();

            // lblFirstName
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblFirstName.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblFirstName.Location = new Point(20, 25);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new Size(85, 19);
            this.lblFirstName.TabIndex = 0;
            this.lblFirstName.Text = "?? First Name:";

            // txtFirstName
            this.txtFirstName.Font = new Font("Segoe UI", 10F);
            this.txtFirstName.Location = new Point(160, 22);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new Size(280, 25);
            this.txtFirstName.TabIndex = 1;

            // lblLastName
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblLastName.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblLastName.Location = new Point(20, 60);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new Size(84, 19);
            this.lblLastName.TabIndex = 2;
            this.lblLastName.Text = "?? Last Name:";

            // txtLastName
            this.txtLastName.Font = new Font("Segoe UI", 10F);
            this.txtLastName.Location = new Point(160, 57);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new Size(280, 25);
            this.txtLastName.TabIndex = 3;

            // lblEmail
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblEmail.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblEmail.Location = new Point(20, 95);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new Size(54, 19);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "?? Email:";

            // txtEmail
            this.txtEmail.Font = new Font("Segoe UI", 10F);
            this.txtEmail.Location = new Point(160, 92);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(280, 25);
            this.txtEmail.TabIndex = 5;

            // lblPhone
            this.lblPhone.AutoSize = true;
            this.lblPhone.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblPhone.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblPhone.Location = new Point(20, 130);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new Size(59, 19);
            this.lblPhone.TabIndex = 6;
            this.lblPhone.Text = "?? Phone:";

            // txtPhone
            this.txtPhone.Font = new Font("Segoe UI", 10F);
            this.txtPhone.Location = new Point(160, 127);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new Size(280, 25);
            this.txtPhone.TabIndex = 7;

            // lblMembershipDate
            this.lblMembershipDate.AutoSize = true;
            this.lblMembershipDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.lblMembershipDate.ForeColor = Color.FromArgb(73, 80, 87);
            this.lblMembershipDate.Location = new Point(20, 165);
            this.lblMembershipDate.Name = "lblMembershipDate";
            this.lblMembershipDate.Size = new Size(133, 19);
            this.lblMembershipDate.TabIndex = 8;
            this.lblMembershipDate.Text = "?? Membership Date:";

            // dtpMembershipDate
            this.dtpMembershipDate.Font = new Font("Segoe UI", 10F);
            this.dtpMembershipDate.Format = DateTimePickerFormat.Short;
            this.dtpMembershipDate.Location = new Point(160, 162);
            this.dtpMembershipDate.Name = "dtpMembershipDate";
            this.dtpMembershipDate.Size = new Size(280, 25);
            this.dtpMembershipDate.TabIndex = 9;

            // chkIsActive
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.chkIsActive.ForeColor = Color.FromArgb(40, 167, 69);
            this.chkIsActive.Location = new Point(160, 200);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new Size(87, 23);
            this.chkIsActive.TabIndex = 10;
            this.chkIsActive.Text = "? Active";
            this.chkIsActive.UseVisualStyleBackColor = true;

            // btnSave
            this.btnSave.BackColor = Color.FromArgb(40, 167, 69);
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Location = new Point(264, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(85, 35);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "?? Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Location = new Point(355, 240);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new Size(85, 35);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "? Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // AddEditMemberForm
            this.BackColor = Color.FromArgb(248, 249, 250);
            this.ClientSize = new Size(470, 300);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.dtpMembershipDate);
            this.Controls.Add(this.lblMembershipDate);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.lblFirstName);
            this.Font = new Font("Segoe UI", 9F);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditMemberForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Member Form";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Label lblFirstName;
        private TextBox txtFirstName;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblMembershipDate;
        private DateTimePicker dtpMembershipDate;
        private CheckBox chkIsActive;
        private Button btnSave;
        private Button btnCancel;
    }
}