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
    public partial class I_Department : Form
    {
        public I_Department()
        {
            InitializeComponent();
        }

        private void I_Department_Load(object sender, EventArgs e)
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
            DB.cn.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("部门编号或部门名称不能为空");
            }
            else
            {
                DB.GetCn();
                DialogResult dr = MessageBox.Show("你确定要添加吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    string s_id = "select * from bumenbiao where department_id='" + txtId.Text + "'";
                    DataTable dt1 = DB.GetDataSet(s_id);

                    string s_name = "select * from bumenbiao where department_name='" + txtName.Text + "'";
                    DataTable dt2 = DB.GetDataSet(s_name);

                    if (dt1.Rows.Count > 0)
                    {
                        MessageBox.Show("该部门编号已存在，请重新输入");
                    }
                    else if (dt2.Rows.Count > 0)
                    {
                        MessageBox.Show("该部门名称已存在，请重新输入");
                    }
                    else
                    {
                        DataRow DepRow = ds.Tables["department_info"].NewRow();

                        DepRow["department_id"] = txtId.Text.Trim();
                        DepRow["department_name"] = txtName.Text.Trim();
                        DepRow["manager_Id"] = txtManager.Text.Trim();
                        DepRow["department_description"] = txtDescn.Text.Trim();

                        ds.Tables["department_info"].Rows.Add(DepRow);


                        // 使用存储过程添加日志信息
                        SqlCommand cmd = new SqlCommand("add_log", DB.cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("username", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("type", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("action_date", SqlDbType.DateTime));
                        cmd.Parameters.Add(new SqlParameter("action_table", SqlDbType.NVarChar));

                        cmd.Parameters["username"].Value = denglu.a;
                        cmd.Parameters["type"].Value = "添加";
                        cmd.Parameters["action_date"].Value = DateTime.Now;
                        cmd.Parameters["action_table"].Value = "bumenbiao";

                        try
                        {
                            SqlCommandBuilder dbDepartment = new SqlCommandBuilder(daDepartment);
                            daDepartment.Update(ds, "department_info");
                            cmd.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
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

