using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = db.Authors.Select(a => new { a.FirstName, a.LastName}).ToList();


                dataGridView1.DataSource = bs;
            }
        }
    }
}
