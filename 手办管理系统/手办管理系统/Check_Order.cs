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
    public partial class Check_Order : Form
    {
        public Check_Order()
        {
            InitializeComponent();
        }


        SqlDataAdapter daorder;
        DataSet ds = new DataSet();
        void init()
        {
            DB.GetCn();
            string str = "select * from dindanbiao";
            daorder = new SqlDataAdapter(str, DB.cn);
            daorder.Fill(ds, "order_info");
        }



        void showAll()
        {
            init();
        }

        void showXz()
        {

            DataGridViewCheckBoxColumn acCode = new DataGridViewCheckBoxColumn();
            acCode.Name = "acCode";
            acCode.HeaderText = "选择";
            dataGridView1.Columns.Add(acCode);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.Rows.Count;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString() == "True")
                {
                    dataGridView1.Rows[i].Cells["Status"].Value = "已审核";
                    if (string.IsNullOrEmpty(dataGridView1.Rows[i].Cells["Employeeld"].Value?.ToString()))
                    {
                        dataGridView1.Rows[i].Cells["Employeeld"].Value = denglu.Employee_Id;

                    }
                    UpdateDB();
                }
                else
                {
                    s = s - 1;

                }

            }
            if (s == 0)
            {
                MessageBox.Show("请选择要审核的项");
            }
        }

        void UpdateDB()
        {
            try
            {
                SqlCommandBuilder dbOrder = new SqlCommandBuilder(daorder);
                daorder.Update(ds, "Order_info");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void Check_Order_Load(object sender, EventArgs e)
        {
            if (denglu.Dflag == false)
            {
                MessageBox.Show("需要销售部员工身份登录");
                this.Close();
            }
            else
            {
                showXz();
                showAll();
                DataView dvOrder = new DataView(ds.Tables["order_info"]);
                dataGridView1.DataSource = dvOrder;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewCheckBoxCell ck = dataGridView1.Rows[i].Cells["acCode"] as DataGridViewCheckBoxCell;
                    if (i != e.RowIndex)
                    {
                        ck.Value = false;
                    }
                    else
                    {
                        ck.Value = true;
                    }
                }

            }
        }
    }
}
