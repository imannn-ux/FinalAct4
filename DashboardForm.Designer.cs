namespace WinFormsApp4;

partial class DashboardForm
{
    private System.ComponentModel.IContainer? components = null;
    private Panel sidebar = null!;
    private Label welcomeLabel = null!;
    private Label userLabel = null!;
    private Button logoutButton = null!;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        sidebar = new Panel();
        welcomeLabel = new Label();
        userLabel = new Label();
        logoutButton = new Button();

        sidebar.BackColor = Color.FromArgb(21, 33, 54);
        sidebar.Dock = DockStyle.Left;
        sidebar.Size = new Size(210, 450);
        sidebar.Controls.Add(userLabel);
        sidebar.Controls.Add(logoutButton);

        userLabel.AutoSize = false;
        userLabel.ForeColor = Color.White;
        userLabel.Location = new Point(20, 25);
        userLabel.Size = new Size(170, 55);

        logoutButton.BackColor = Color.Transparent;
        logoutButton.FlatAppearance.BorderSize = 0;
        logoutButton.FlatStyle = FlatStyle.Flat;
        logoutButton.ForeColor = Color.White;
        logoutButton.Location = new Point(20, 370);
        logoutButton.Size = new Size(150, 35);
        logoutButton.Text = "Sign out";
        logoutButton.UseVisualStyleBackColor = false;

        welcomeLabel.AutoSize = false;
        welcomeLabel.Dock = DockStyle.Fill;
        welcomeLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
        welcomeLabel.ForeColor = Color.FromArgb(21, 33, 54);
        welcomeLabel.Text = "Welcome to the Dashboard";
        welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;

        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(248, 250, 252);
        ClientSize = new Size(850, 450);
        Controls.Add(welcomeLabel);
        Controls.Add(sidebar);
        Font = new Font("Segoe UI", 9F);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        StartPosition = FormStartPosition.CenterScreen;
        Text = "StockPilot | Dashboard";
    }
}