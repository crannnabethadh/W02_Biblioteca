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
    public partial class BookDetailsFormDialog : Form
    {
        Book _selectedBook;
        public BookDetailsFormDialog(Book selectedBook)
        {
            InitializeComponent();
            _selectedBook = selectedBook;
            // TODO: Connect to database,
            // get details of book and show them in form
        
        
        }
    }
}
