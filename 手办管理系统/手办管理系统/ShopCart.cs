﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 手办管理系统
{
    public partial class ShopCart : Form
    {
        public ShopCart()
        {
            InitializeComponent();
        }

        public static decimal profit = 0;
        SqlDataAdapter daCartItem, daProduct;
        DataSet ds = new DataSet();

        CartItemsv cartSrv = new CartItemsv();

        void init()
        {
            DB.GetCn();
            string str = "select Product_ID,Customer_ID,Proid,ProName,ListPrice,UnPrice,Qty from CartItem where Customer_ID=" + denglu.CustomerId + "";
            daCartItem = new SqlDataAdapter(str, DB.cn);
            daCartItem.Fill(ds, "CartItem_info");

            string sdr = "select * from shangpinbiao";
            daProduct = new SqlDataAdapter(sdr, DB.cn);
            daProduct.Fill(ds, "product_info");

        }

        void showXz()
        {
            DataGridViewCheckBoxColumn acCode = new DataGridViewCheckBoxColumn();
            acCode.Name = "acCode";
            acCode.HeaderText = "选择";
            dataGridView1.Columns.Add(acCode);

        }

        void dgvHead()
        {
            dataGridView1.Columns[0].HeaderText = "购物车编号";
            dataGridView1.Columns[1].HeaderText = "用户编号";
            dataGridView1.Columns[2].HeaderText = "商品编号";
            dataGridView1.Columns[3].HeaderText = "商品名称";
            dataGridView1.Columns[4].HeaderText = "价格";
            dataGridView1.Columns[5].HeaderText = "购买数量";
        }

        void Bind()
        {
            init();

            label1.Text = cartSrv.GetTotalPriceByCustomerId(Convert.ToInt32(denglu.CustomerId)).Item1.ToString();
            //profit = cartSrv.GetTotalPriceByCustomerId(Login.CustomerId).Item2.ToString();
            DataView dvCartItem = new DataView(ds.Tables["CartItem_info"]);

            dataGridView1.DataSource = dvCartItem;
            dgvHead();
            showXz();



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


        void UpdataDB()
        {
            try
            {
                SqlCommandBuilder dbCartItem = new SqlCommandBuilder(daCartItem);
                daCartItem.Update(ds, "CartItem_info");
                SqlCommandBuilder dbProduct = new SqlCommandBuilder(daProduct);
                daProduct.Update(ds, "product_info");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int s = dataGridView1.Rows.Count;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Cells["acCode"].EditedFormattedValue.ToString() == "True")
                {
                    dataGridView1.Rows.RemoveAt(i);
                    UpdataDB();
                    label1.Text = cartSrv.GetTotalPriceByCustomerId(Convert.ToInt32(denglu.CustomerId)).Item1.ToString();
                }
                else
                {
                    s = s - 1;
                }
            }

            if (s == 0)
            {
                MessageBox.Show("请选择要删除的商品");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("请先添加商品");
            }
            else
            {
                List<int> list = new List<int>();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    list.Add(i);
                }
                foreach (int n in list)
                {
                    string str = dataGridView1.Rows[n].Cells["Proid"].Value.ToString();
                    DataRow[] CustRow = ds.Tables["product_info"].Select("Goods_ID='" + str + "'");
                    CustRow[0]["Stock_Quantity"] = Convert.ToInt32(CustRow[0]["Stock_Quantity"]) - Convert.ToInt32(dataGridView1.Rows[n].Cells["Qty"].Value);
                }
                UpdataDB();
                Clear_cartItem();
                label1.Text = cartSrv.GetTotalPriceByCustomerId(Convert.ToInt32(denglu.CustomerId)).Item1.ToString();
                this.Close();

                SubCart t1 = new SubCart();
                t1.ShowDialog();
            }
        }

        void Clear_cartItem()
        {
            List<int> List_index = new List<int>();
            if (dataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    List_index.Add(i);
                }

                int z = 0;

                foreach (int n in List_index)
                {
                    dataGridView1.Rows.RemoveAt(n - z);
                    z++;
                }
            }
            UpdataDB();
            label1.Text = cartSrv.GetTotalPriceByCustomerId(Convert.ToInt32(denglu.CustomerId)).Item1.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear_cartItem();
        }

        private void ShopCart_Load(object sender, EventArgs e)
        {
            DB.GetCn();
            cartSrv.Add(Convert.ToInt32(denglu.CustomerId), Convert.ToInt32(Form1.Productid), 1);//1.客户id，2.商品id，3.购买数量
            Bind();
        }
    }
}
