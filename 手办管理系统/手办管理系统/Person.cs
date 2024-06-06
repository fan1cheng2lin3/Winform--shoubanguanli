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
    public partial class Person : Form
    {
        public Person()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB.GetCn();
            string str = "update yuangongbiao set Employee_ID ='"
                + textBox1.Text + "',sex='"
                + textBox3.Text + "', [Birth_ Date] ='"
                + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', Hire_Date ='"
                + dateTimePicker2.Value.ToString("yyyy-MM-dd") + "',Address ='"
                + textBox10.Text + "',Telephone='"
                + textBox9.Text + "',Wages='"
                + Convert.ToInt32(textBox8.Text) + "',Department_id ='"
                + textBox7.Text + "',Resume='"
                + textBox5.Text + "' where Name = '" + denglu.a + "'";
            DB.sqlEx(str);
            MessageBox.Show("修改成功");



        }

        private void Person_Load(object sender, EventArgs e)
        {
            DB.GetCn();
            string str = "select * from yuangongbiao where Name ='" + denglu.a + "'";
            DataTable dt = DB.GetDataSet(str);
            textBox1.Text = dt.Rows[0][0].ToString();
            textBox2.Text = dt.Rows[0][1].ToString();
            textBox3.Text = dt.Rows[0][2].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dt.Rows[0][3]);
            dateTimePicker2.Value = Convert.ToDateTime(dt.Rows[0][4]);
            textBox10.Text = dt.Rows[0][5].ToString();
            textBox9.Text = dt.Rows[0][6].ToString();
            textBox8.Text = dt.Rows[0][7].ToString();
            textBox7.Text = dt.Rows[0][8].ToString();
            textBox5.Text = dt.Rows[0][9].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
