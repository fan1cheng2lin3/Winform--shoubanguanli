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
    public partial class ChangPwd : Form
    {
        public ChangPwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("请输入原密码");
            }
            else
            {
                DB.GetCn();
                string str = "slect * from yuangongbiao where Name = '" + textBox1.Text + "'and Telephone ='" + textBox3.Text + "'";
                DataTable dt = new DataTable(str);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("原密码错误，请重新输入");
                }
                else
                {
                    if(textBox4.Text != textBox3.Text)
                    {
                        MessageBox.Show("两次密码不一致");
                    }
                    else
                    {
                        string sdr = "update yuangongbiao set Telephone='"+textBox3.Text + "'where Name='"+ textBox1.Text + "'";
                        DB.sqlEx(sdr);
                        MessageBox.Show("修改成功");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
