using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Dapper;

namespace W02_BibliotecaWinformUI
{
    public partial class BibliotecaMainForm : Form
    {
        private string connectionString =
            "Server=localhost;Port=3306;Database=biblioteca;Uid=lector;Pwd=seCret_16;";
        bool existsAuthorsForm = false;
        AuthorsForm authorsForm = null;

        public BibliotecaMainForm()
        {
            InitializeComponent();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            List<string> books = new List<string>();
            MySqlConnection connection = new MySqlConnection(connectionString);
            string sql = $"SELECT ID_LLIB, TITOL FROM LLIBRES" +
                $" WHERE TITOL LIKE '%{searchTextBox.Text}%'";
            books = connection.Query<string>(sql).ToList();

            foreach (var book in books)
            {
                booksListBox.Items.Add(book + ":\t" + book);
            }

            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //  Or Close()?
            // create new only if not exists
            if (!existsAuthorsForm)
            {
                authorsForm = new AuthorsForm();
                authorsForm.Show();
                //position right to this
                authorsForm.Location = new Point(this.Location.X + this.Size.Width + 10,
                    this.Location.Y);
                existsAuthorsForm = true;
            }

            authorsForm?.Dispose();
        }

        private void booksListBox_DoubleClick(object sender, EventArgs e)
        {
            Book selectedBook = booksListBox.SelectedItem as Book;
            BookDetailsFormDialog bookDetailsForm =
                new BookDetailsFormDialog();

            //Button prop DialogResult

            DialogResult result = bookDetailsForm.ShowDialog(this);

            if ( result == DialogResult.OK)
            {
                // Read the contents of testDialog's TextBox.
                //this.txtResult.Text = testDialog.TextBox1.Text;
            }
            else if (result == DialogResult.Cancel)
            {
                //this.txtResult.Text = "Cancelled";

            }
            bookDetailsForm.Dispose();
        }
    }
}
