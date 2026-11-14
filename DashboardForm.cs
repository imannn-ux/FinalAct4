using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class DashboardForm : Form
    {
        DataGridView table = new DataGridView();

        TextBox name = new TextBox();
        TextBox description = new TextBox();
        TextBox quantity = new TextBox();
        TextBox price = new TextBox();
        TextBox reorder = new TextBox();

        public DashboardForm(UserAccount account)
        {
            InitializeComponent();

            Controls.Clear();

            Text = "Product Management";
            Size = new Size(1000, 700);
            BackColor = Color.White;

            // Welcome
            Label welcome = new Label();
            welcome.Text = "Welcome!";
            welcome.Location = new Point(20, 20);
            welcome.AutoSize = true;
            Controls.Add(welcome);

            Button logout = new Button();
            logout.Text = "Logout";
            logout.Location = new Point(850, 15);
            logout.Click += (s, e) => Close();
            Controls.Add(logout);

            // Title
            Label title = new Label();
            title.Text = "Product Management";
            title.Font = new Font("Arial", 16, FontStyle.Bold);
            title.Location = new Point(20, 65);
            title.AutoSize = true;
            Controls.Add(title);

            Label subtitle = new Label();
            subtitle.Text = "Manage your inventory products";
            subtitle.Location = new Point(20, 100);
            subtitle.AutoSize = true;
            Controls.Add(subtitle);

            // Summary Cards
            string[] cards =
            {
                "Total Products: 0",
                "In Stock: 0",
                "Low Stock: 0",
                "Out of Stock: 0"
            };

            for (int i = 0; i < 4; i++)
            {
                Label card = new Label();
                card.Text = cards[i];
                card.Size = new Size(210, 75);
                card.Location = new Point(20 + (i * 225), 140);
                card.BackColor = Color.LightBlue;
                card.TextAlign = ContentAlignment.MiddleCenter;
                Controls.Add(card);
            }

            // Product Inputs
            Label formTitle = new Label();
            formTitle.Text = "Product Information";
            formTitle.Location = new Point(20, 235);
            formTitle.AutoSize = true;
            Controls.Add(formTitle);

            AddInput("Product Name", name, 20, 265);
            AddInput("Description", description, 230, 265);
            AddInput("Quantity", quantity, 440, 265);
            AddInput("Unit Price", price, 650, 265);
            AddInput("Reorder Level", reorder, 20, 325);

            // Buttons
            Button add = new Button();
            add.Text = "Add Product";
            add.Location = new Point(650, 325);
            add.Click += AddProduct;
            Controls.Add(add);

            Button clear = new Button();
            clear.Text = "Clear";
            clear.Location = new Point(760, 325);
            clear.Click += (s, e) => ClearInputs();
            Controls.Add(clear);

            // Product List
            Label listTitle = new Label();
            listTitle.Text = "Product List";
            listTitle.Location = new Point(20, 390);
            listTitle.AutoSize = true;
            Controls.Add(listTitle);

            // Table
            table.Location = new Point(20, 420);
            table.Size = new Size(930, 200);
            table.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            table.AllowUserToAddRows = false;
            table.Columns.Add("ID", "Product ID");
            table.Columns.Add("Name", "Product Name");
            table.Columns.Add("Description", "Description");
            table.Columns.Add("Quantity", "Quantity");
            table.Columns.Add("Price", "Unit Price");
            table.Columns.Add("Total", "Total Value");
            table.Columns.Add("Status", "Status");

            Controls.Add(table);
        }

        void AddInput(string label, TextBox box, int x, int y)
        {
            Label text = new Label();
            text.Text = label;
            text.Location = new Point(x, y);
            text.AutoSize = true;
            Controls.Add(text);

            box.Location = new Point(x, y + 20);
            box.Size = new Size(180, 25);
            Controls.Add(box);
        }

        void AddProduct(object sender, EventArgs e)
        {
            int qty;
            decimal unitPrice;

            if (name.Text == "" ||
                !int.TryParse(quantity.Text, out qty) ||
                !decimal.TryParse(price.Text, out unitPrice))
            {
                MessageBox.Show("Please enter valid product details.");
                return;
            }

            decimal total = qty * unitPrice;

            string status = qty == 0 ? "Out of Stock" :
                            qty <= 5 ? "Low Stock" : "In Stock";

            table.Rows.Add(
                table.Rows.Count + 1,
                name.Text,
                description.Text,
                qty,
                unitPrice,
                total,
                status
            );

            ClearInputs();
        }

        void ClearInputs()
        {
            name.Clear();
            description.Clear();
            quantity.Clear();
            price.Clear();
            reorder.Clear();
        }
    }
}