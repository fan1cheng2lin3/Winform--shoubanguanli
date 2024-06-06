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
    public partial class D_department : Form
    {
        public D_department()
        {
            InitializeComponent();
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
            dataGridView1.Columns[3].Width = 500;

        }

        void showXz()
        {
            DataGridViewCheckBoxColumn acCode = new DataGridViewCheckBoxColumn();
            acCode.Name = "acCode";
            acCode.HeaderText = "选择";
            dataGridView1.Columns.Add(acCode);
        }

        private void D_department_Load(object sender, EventArgs e)
        {
            showXz();
            init();
            showALL();
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

        private void button1_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.Rows.Count;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString() == "True")
                {
                    DialogResult dr = MessageBox.Show("你确认要删除吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (dr == DialogResult.OK)
                    {

                        dataGridView1.Rows.RemoveAt(i);
                        DB.GetCn();

                        // 使用存储过程删除日志信息
                        SqlCommand cmd = new SqlCommand("add_log", DB.cn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add(new SqlParameter("username", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("type", SqlDbType.NVarChar));
                        cmd.Parameters.Add(new SqlParameter("action_date", SqlDbType.DateTime));
                        cmd.Parameters.Add(new SqlParameter("action_table", SqlDbType.NVarChar));

                        cmd.Parameters["username"].Value = denglu.a;
                        cmd.Parameters["type"].Value = "删除";
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
                else
                {
                    s = s - 1;
                }
            }
            if (s == 0)
            {
                MessageBox.Show("请选择要删除的项");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

