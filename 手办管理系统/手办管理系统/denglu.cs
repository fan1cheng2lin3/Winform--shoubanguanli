using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 手办管理系统
{
    public partial class denglu : Form
    {

        public static string a = string.Empty;
        public static int CustomerId;
        public static string Employee_Id = " ";
        public static bool Dflag = false;//false:是昔通员工，true是销售部员工
        public static bool Bflag = false;//false:是昔通员工，true是管理员

        public denglu()
        {
            InitializeComponent();
        }



        private void denglu_Load(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {




            if(txtName.Text == ""||txtPwd.Text == "")
            {
                MessageBox.Show("请输入账号密码");

            }
            else
            {

                if (radioButton1.Checked)
                {
                    DB.GetCn();
                    string t1 = "select * from yonghubiao where username = '" + txtName.Text + "' and pwd = '" + txtPwd.Text + "'";

                    DataTable r1 = DB.GetDataSet(t1);

                    if (r1.Rows.Count > 0)
                    {

                        Name = txtName.Text;
                        Form1.Aflog = true;
                        Dflag = false;
                        a = txtName.Text;
                        CustomerId = Convert.ToInt32(r1.Rows[0]["Customerld"]);
                        this.Close();
                        MessageBox.Show("登录成功");
                        
                    }
                    else
                    {
                        MessageBox.Show("登录失败");
                    }
                }

                if (radioButton2.Checked)
                {

                    DB.GetCn();
                    string t1 = "select * from yuangongbiao where Name = '" + txtName.Text + "' and Telephone = '" + txtPwd.Text + "'";

                    DataTable r1 = DB.GetDataSet(t1);
                    if (r1.Rows.Count > 0)
                    {

                        Name = txtName.Text;
                        Form1.Aflog = true;
                        Dflag = true;
                        a = txtName.Text;
                        Employee_Id = Convert.ToString(r1.Rows[0]["Employee_ID"]);
                        Front t2 = new Front();
                        t2.ShowDialog();
                        this.Close();
                        
                    }
                    else
                    {
                        MessageBox.Show("登录失败");
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
