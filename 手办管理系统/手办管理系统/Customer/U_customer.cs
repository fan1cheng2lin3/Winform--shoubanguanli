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

namespace 手办管理系统.Customer
{
    public partial class U_customer : Form
    {
        public U_customer()
        {
            InitializeComponent();
        }

        SqlDataAdapter daCustomers, daLog;
        DataSet ds = new DataSet();


        void init()
        {
            DB.GetCn();
            string str = "select * from yonghubiao";
            daCustomers = new SqlDataAdapter(str, DB.cn);
            string sdr = "select * from rizhibiao";
            daLog = new SqlDataAdapter(sdr, DB.cn);
            daCustomers.Fill(ds, "yonghubiao_info");
            daLog.Fill(ds, "log_info");
        }

        void showAll()
        {
            DataView dvCustomers = new DataView(ds.Tables["yonghubiao_info"]);
            dataGridView1.DataSource = dvCustomers;
        }

        private void U_customer_Load(object sender, EventArgs e)
        {
            init();
            showAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells["Customerld"].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells["username"].Value.ToString();
            txtPhone.Text = dataGridView1.CurrentRow.Cells["pwd"].Value.ToString();
            txtEmail.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("客户姓名和电话不能为空");
            }
            else
            {
                DialogResult dr = MessageBox.Show("你确定要修改吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.OK)
                {
                    int a = dataGridView1.CurrentRow.Index;
                    string str = dataGridView1.Rows[a].Cells["Customerld"].Value.ToString();
                    DataRow[] CustRows = ds.Tables["yonghubiao_info"].Select("Customerld='" + str + "'");
                    CustRows[0]["username"] = txtName.Text.Trim();
                    CustRows[0]["pwd"] = txtPhone.Text.Trim();
                    CustRows[0]["email"] = txtEmail.Text.Trim();
                    MessageBox.Show("修改成功");

                    DataRow drLog = ds.Tables["log_info"].NewRow();
                    drLog["username"] = denglu.a;
                    drLog["type"] = "修改";
                    drLog["action_date"] = DateTime.Now;
                    drLog["action_table"] = "yonghubiao表";
                    ds.Tables["log_info"].Rows.Add(drLog);

                    SqlTransaction st = TransactionInit();

                    try
                    {
                        daCustomers.Update(ds, "yonghubiao_info");
                        daLog.Update(ds, "log_info");
                        st.Commit();
                        DB.cn.Close();
                    }
                    catch (SqlException ex)
                    {
                        st.Rollback();
                        DB.cn.Close();
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private SqlTransaction TransactionInit()
        {
            DB.GetCn();
            SqlCommandBuilder dbCustomers = new SqlCommandBuilder(daCustomers);
            SqlCommandBuilder dbLog = new SqlCommandBuilder(daLog);

            daCustomers.UpdateCommand = dbCustomers.GetUpdateCommand();
            daLog.InsertCommand = dbLog.GetInsertCommand();

            SqlTransaction st = DB.cn.BeginTransaction();

            daCustomers.UpdateCommand.Transaction = st;
            daLog.InsertCommand.Transaction = st;

            daCustomers.UpdateCommand.Connection = DB.cn;
            daLog.InsertCommand.Connection = DB.cn;

            return st;
        }
    }

}

