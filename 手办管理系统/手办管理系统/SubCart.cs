using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 手办管理系统
{
    public partial class SubCart : Form
    {
        public SubCart()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.GetCn();
            string str = "insert into dindanbiao values('" + denglu.a + "','" + DateTime.Today + "','" + textBox1.Text + "','"
                + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text
                + "','未审核', null)";// ShopCart.profit +
            ShopCart.profit = 0;
            DB.sqlEx(str);
            MessageBox.Show("已结算");
            this.Close();
        }

        private void SubCart_Load(object sender, EventArgs e)
        {

        }
    }
}
