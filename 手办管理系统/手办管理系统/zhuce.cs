using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace 手办管理系统
{
    public partial class zhuce : Form
    {
        public zhuce()
        {
            InitializeComponent();
        }







        private void zhuce_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            DB.GetCn();
            string t1 = "select * from yonghubiao where username = '" + txtName.Text + "'";
            DataTable r1 = DB.GetDataSet(t1);

            if(r1.Rows.Count > 0)
            {
                MessageBox.Show("此用户名已存在，请重新输入");
            }
            else
            {
                DB.GetCn();
                if (txtName.Text == ""|| txtPwd.Text == ""||txtEmail.Text == "")
                {
                    MessageBox.Show("请正确输入账号密码和邮箱");
                }
                else
                {
                    string t2 = "insert into yonghubiao(username, pwd, email) values('" + txtName.Text + "', '" + txtPwd.Text + "', '" + txtEmail.Text + "')";
                    bool success = DB.sqlEx(t2);  

                    if (success)
                    {
                        MessageBox.Show("注册成功");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("注册失败");
                    }
                    this.Close();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
