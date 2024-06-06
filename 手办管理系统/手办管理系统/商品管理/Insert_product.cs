using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace 手办管理系统.商品管理
{
    public partial class Insert_product : Form
    {
        public Insert_product()
        {
            InitializeComponent();
        }

        public static string path_source = "";
        SqlDataAdapter daProdout, dalog;
        DataSet ds = new DataSet();

        void init()
        {
            DB.GetCn();
            string str = "select * from shangpinbiao";
            string sdr = "select * from rizhibiao";
            daProdout = new SqlDataAdapter(str,DB.cn);
            dalog = new SqlDataAdapter(sdr,DB.cn);
            daProdout.Fill(ds,"product_info");
            dalog.Fill(ds,"log_info");
        }

        void ShowAll()
        {
            DataView dvProduct = new DataView(ds.Tables["product_info"]);
            dataGridView1.DataSource = dvProduct;
        }

        private void Insert_product_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“shoubanguanliDataSet3.leibiebiao”中。您可以根据需要移动或移除它。
            this.leibiebiaoTableAdapter1.Fill(this.shoubanguanliDataSet3.leibiebiao);
            // TODO: 这行代码将数据加载到表“shoubanguanliDataSet2.shangpinbiao”中。您可以根据需要移动或移除它。
            this.shangpinbiaoTableAdapter.Fill(this.shoubanguanliDataSet2.shangpinbiao);
            // TODO: 这行代码将数据加载到表“shoubanguanliDataSet1.shangpinleibiebiao”中。您可以根据需要移动或移除它。
            this.shangpinleibiebiaoTableAdapter.Fill(this.shoubanguanliDataSet1.shangpinleibiebiao);
            // TODO: 这行代码将数据加载到表“shoubanguanliDataSet.leibiebiao”中。您可以根据需要移动或移除它。
            this.leibiebiaoTableAdapter.Fill(this.shoubanguanliDataSet.leibiebiao);

            init();
            ShowAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                path_source = dlg.FileName;
                pictureBox1.Image = Image.FromFile(path_source);
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("必填不能为空");
            }
            else
            {
                DB.GetCn();
                string str = "select * from shangpinbiao where Goods_ID ='" + textBox1.Text + "'";
                DataTable dt =DB.GetDataSet(str);
                if(dt.Rows.Count > 0)
                {
                    MessageBox.Show("此商品已存在，请重新输入编号");

                }
                else
                {
                    string filename;
                    string fileFolder;
                    string dateTime = "";
                    filename = Path.GetFileName(path_source);
                    dateTime += DateTime.Now.Year.ToString();
                    dateTime += DateTime.Now.Month.ToString();
                    dateTime += DateTime.Now.Day.ToString();
                    dateTime += DateTime.Now.Hour.ToString();
                    dateTime += DateTime.Now.Minute.ToString();
                    dateTime += DateTime.Now.Second.ToString();
                    filename = dateTime + filename;

                    fileFolder = Directory.GetCurrentDirectory()+"\\"+"Prod_Images\\"
                        +comboBox1.Text + "\\";
                    fileFolder += filename;

                    DataRow dr= ds.Tables["product_info"].NewRow();
                    dr["Goods_ID"] =int.Parse(textBox1.Text);
                    dr["Classification_ID"] = comboBox1.SelectedValue;
                    dr["Supplier_ID"] = comboBox2.SelectedValue;
                    dr["Unit_Price"] = decimal.Parse(textBox4.Text);
                    dr["chengben"] = decimal.Parse(textBox2.Text);
                    dr["Goods_Name"] = textBox5.Text;
                    dr["Order_Quantity"] = textBox3.Text;
                    dr["Stock_Quantity"] = textBox6.Text;



                    if (path_source != "")
                    {
                        File.Copy(path_source, fileFolder, true);
                        dr["image"] = "\\Prod_Images\\" + comboBox1.Text + "\\" + filename;
                    }
                    else
                    {
                        dr["image"] = "780.jpg";
                    }

                    ds.Tables["product_info"].Rows.Add(dr);

                    DataRow drlog = ds.Tables["log_info"].NewRow();
                    drlog["username"] = denglu.a;
                    drlog["type"] = "添加";
                    drlog["action_date"]=DateTime.Now;
                    drlog["action_table"] = "product表";
                    ds.Tables["log_info"].Rows.Add (drlog);

                    try
                    {
                        SqlCommandBuilder dbProuct = new SqlCommandBuilder(daProdout);
                        daProdout.Update(ds, "product_info");
                        SqlCommandBuilder dblog = new SqlCommandBuilder(dalog);
                        dalog.Update(ds, "log_info");
                        MessageBox.Show("添加成功");
                    }
                    catch (Exception ex) 
                    { 
                        MessageBox.Show(ex.Message);                    
                    }
                    DB.cn.Close();
                }
            }
        }
    }
}
