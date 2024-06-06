using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 手办管理系统.Customer;
using 手办管理系统.Partment;
using 手办管理系统.商品管理;

namespace 手办管理系统
{
    public partial class Front : Form
    {
        public Front()
        {
            InitializeComponent();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Person t1 = new Person();
            t1.ShowDialog();
        }

        private void 商品管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 添加商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Insert_product t1 = new Insert_product();
            t1.ShowDialog();
        }

        private void 修改商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updata_product t1 = new Updata_product();
            t1.ShowDialog();
        }

        private void 删除商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete_product t1 = new delete_product();
            t1.ShowDialog();
        }

        private void 审核订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Check_Order c1 = new Check_Order();
            c1.ShowDialog();
        }

        private void 查看日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Select_Order c1 = new Select_Order();
            c1.ShowDialog();
        }

        private void 修改部门ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            U_department c1 = new U_department();
            c1.ShowDialog();
        }

        private void 添加部门ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            I_Department c1 = new I_Department();
            c1.ShowDialog();
        }

        private void 删除部门ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            D_department d1 = new D_department();
            d1.ShowDialog();
        }

        private void 修改客户信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            U_customer u_Customer = new U_customer();
            u_Customer.ShowDialog();
        }
    }
}
