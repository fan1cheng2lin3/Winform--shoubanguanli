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

namespace 手办管理系统.Partment
{
    public partial class U_department : Form
    {
        public U_department()
        {
            InitializeComponent();
        }

        private void U_department_Load(object sender, EventArgs e)
        {
            init();
            showALL();
            dgvHead();
        }

        SqlDataAdapter daDepartment;
        DataSet ds = new DataSet();

        void init()
        {
            DB.GetCn();
            string str = "select * from bumenbiao";
            daDepartment = new SqlDataAdapter(str, DB.cn);
            daDepartment.Fill(ds, "department_info");
        }

        void showALL()
        {
            DataView dvDepartment = new DataView(ds.Tables["department_info"]);
            dataGridView1.DataSource = dvDepartment;
            dataGridView1.Columns[3].Width = 100;

        }


        void dgvHead()
        {
            this.dataGridView1.Columns[0].HeaderText = "部门编号";
            this.dataGridView1.Columns[1].HeaderText = "部门名称";
            this.dataGridView1.Columns[2].HeaderText = "部门经历";
            this.dataGridView1.Columns[3].HeaderText = "部门描述";
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells["department_id"].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells["department_name"].Value.ToString();
            txtManager.Text = dataGridView1.CurrentRow.Cells["manager_Id"].Value.ToString();
            txtDescn.Text = dataGridView1.CurrentRow.Cells["department_description"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("姓名不能为空");
            }
            else
            {
                DialogResult dr = MessageBox.Show("你确定要修改吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (dr == DialogResult.OK)
                {
                    int a = dataGridView1.CurrentRow.Index;
                    string str = dataGridView1.Rows[a].Cells["department_id"].Value.ToString();
                    DataRow[] CustRows = ds.Tables["department_info"].Select("department_id='" + str + "'");
                    CustRows[0]["department_id"] = txtId.Text.Trim();
                    CustRows[0]["department_name"] = txtName.Text.Trim();
                    CustRows[0]["manager_Id"] = txtManager.Text.Trim();
                    CustRows[0]["department_description"] = txtDescn.Text.Trim();
                    MessageBox.Show("修改成功");


                    // 使用存储过程修改日志信息
                    SqlCommand cmd = new SqlCommand("add_log", DB.cn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("username", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("type", SqlDbType.NVarChar));
                    cmd.Parameters.Add(new SqlParameter("action_date", SqlDbType.DateTime));
                    cmd.Parameters.Add(new SqlParameter("action_table", SqlDbType.NVarChar));

                    cmd.Parameters["username"].Value = denglu.a;
                    cmd.Parameters["type"].Value = "修改";
                    cmd.Parameters["action_date"].Value = DateTime.Now;
                    cmd.Parameters["action_table"].Value = "bumenbiao";


                    try
                    {
                        SqlCommandBuilder dbProuct = new SqlCommandBuilder(daDepartment);
                        daDepartment.Update(ds, "department_info");
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        DB.cn.Close();
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
    }
}
