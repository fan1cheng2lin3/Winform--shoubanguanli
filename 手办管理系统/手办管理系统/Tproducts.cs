using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 手办管理系统
{
    public partial class Tproducts : Form
    {
        public Tproducts()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Tproducts_Load(object sender, EventArgs e)
        {

            DB.GetCn();
            string str = "select * from shangpinbiao where Goods_ID = " + Form1.Productid + "";
            DataTable dt = DB.GetDataSet(str);

            label1.Text = Form1.Productid;
            label5.Text = dt.Rows[0][1].ToString();
            label8.Text = dt.Rows[0][2].ToString();
            
            label10.Text = dt.Rows[0][4].ToString();
            label9.Text = dt.Rows[0][5].ToString();
            

            try
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + dt.Rows[0][8].ToString());
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch
            {

                pictureBox1.Image = Image.FromFile(Application.StartupPath + "//" + "780.jpg");
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }

        }
    }
}
