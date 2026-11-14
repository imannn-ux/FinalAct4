namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private bool isRegisterMode;

        public Form1()
        {
            InitializeComponent();
            submitButton.Click += SubmitButton_Click;
            modeButton.Click += ModeButton_Click;
            showPasswordCheckBox.CheckedChanged += ShowPasswordCheckBox_CheckedChanged;
            AcceptButton = submitButton;
        }

        private void ModeButton_Click(object? sender, EventArgs e)
        {
            isRegisterMode = !isRegisterMode;
            UpdateMode();
            statusLabel.Text = string.Empty;
            (isRegisterMode ? nameTextBox : emailTextBox).Focus();
        }

        private void UpdateMode()
        {
            welcomeLabel.Text = isRegisterMode ? "Create account" : "Welcome back";
            subtitleLabel.Text = isRegisterMode ? "Set up your workspace in a few seconds." : "Sign in to continue to your workspace.";
            nameLabel.Visible = isRegisterMode;
            nameTextBox.Visible = isRegisterMode;
            confirmPasswordLabel.Visible = isRegisterMode;
            confirmPasswordTextBox.Visible = isRegisterMode;
            showPasswordCheckBox.Location = new Point(70, isRegisterMode ? 312 : 247);
            submitButton.Location = new Point(70, isRegisterMode ? 352 : 287);
            modePromptLabel.Location = new Point(70, isRegisterMode ? 420 : 355);
            modeButton.Location = new Point(180, isRegisterMode ? 415 : 350);
            statusLabel.Location = new Point(70, isRegisterMode ? 455 : 390);
            modePromptLabel.Text = isRegisterMode ? "Already have an account?" : "New to StockPilot?";
            modeButton.Text = isRegisterMode ? "Sign in instead" : "Create an account";
            submitButton.Text = isRegisterMode ? "Create my account" : "Sign in to dashboard";
            demoLabel.Visible = !isRegisterMode;
        }

        private void SubmitButton_Click(object? sender, EventArgs e)
        {
            statusLabel.ForeColor = Color.FromArgb(196, 72, 72);

            if (isRegisterMode)
            {
                if (passwordTextBox.Text != confirmPasswordTextBox.Text)
                {
                    statusLabel.Text = "Passwords do not match.";
                    return;
                }C:\Users\DESKTOP\source\repos\WinFormsApp4\WinFormsApp4_Project.zip

                if (!AuthService.Instance.TryRegister(nameTextBox.Text, emailTextBox.Text, passwordTextBox.Text, out var registeredAccount, out var message))
                {
                    statusLabel.Text = message;
                    return;
                }

                OpenDashboard(registeredAccount!);
                return;
            }

            if (AuthService.Instance.TryLogin(emailTextBox.Text, passwordTextBox.Text, out var account) && account is not null)
            {
                OpenDashboard(account);
            }
            else
            {
                statusLabel.Text = "Email or password is incorrect.";
            }
        }

        private void OpenDashboard(UserAccount account)
        {
            Hide();
            using var dashboard = new DashboardForm(account);
            dashboard.ShowDialog(this);
            Close();
        }

        private void ShowPasswordCheckBox_CheckedChanged(object? sender, EventArgs e)
        {
            passwordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
            confirmPasswordTextBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }

    }
}
