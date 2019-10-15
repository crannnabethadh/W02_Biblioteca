using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace W02_BibliotecaWinformUI
{
    public partial class AuthorsForm : Form
    {
        private string connectionString =
            "Server=localhost;Port=3307;Database=biblioteca;Uid=lector;Pwd=seCret_16;";

        public AuthorsForm()
        {
            InitializeComponent();
        }

        private void authorFindButton_Click(object sender, EventArgs e)
        {
            List<Author> authors = new List<Author>();
            MySqlConnection connection = new MySqlConnection();
            string sql = $"SELECT ID_AUT, NOM_AUT FROM AUTORS" +
                $" WHERE NOM_AUT LIKE '%{authorSearchTextBox.Name}%'";
            authors = connection.Query<Author>(sql);
            authorsListBox.DataSource = authors;
            authorsListBox.DisplayMember = "FullInfo";

            connection.Close();
        }

        private void gotoSearchBooksButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var forms = Application.OpenForms;
            foreach (Form form in forms)
            {
                if (form.Name == "BibliotecaMainForm")
                {
                    form.Show();
                }
            }
        }

        private void AuthorsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
