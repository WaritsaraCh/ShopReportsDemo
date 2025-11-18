using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        dbshopRealEntities1 dbshopRealEntities = new dbshopRealEntities1();
        public Form1()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var resultProduct = dbshopRealEntities.tb_product;
            crystalReport11.Database.Tables["Demo_tb_product"].SetDataSource(resultProduct);
            crystalReportViewer1.ReportSource = crystalReport11;
            crystalReportViewer1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resultProduct = dbshopRealEntities.tb_product;
            crystalReportGroup1.Database.Tables["Demo_tb_product"].SetDataSource(resultProduct);
            crystalReportViewer1.ReportSource = crystalReportGroup1;
            crystalReportViewer1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int curid = int.Parse(textBox1.Text);
            var customer = dbshopRealEntities.tb_customer.Include("tb_buy");
            crystalReportJoin1.Database.Tables["Demo_tb_customer"].SetDataSource(customer);

            var product = dbshopRealEntities.tb_product.Include("ProductType").Include("tb_buy");
            crystalReportJoin1.Database.Tables["Demo_tb_product"].SetDataSource(product);

            var buy = dbshopRealEntities.tb_buy.Include("tb_customer").Include("tb_product");
            crystalReportJoin1.Database.Tables["Demo_tb_buy"].SetDataSource(buy);

            var productType = dbshopRealEntities.ProductTypes.Include("tb_product");
            crystalReportJoin1.Database.Tables["Demo_ProductType"].SetDataSource(productType);

            crystalReportJoin1.SetParameterValue("cusid", curid);
            crystalReportViewer1.ReportSource = crystalReportJoin1;
            crystalReportViewer1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int typeid = int.Parse(textBox2.Text);
            var product = dbshopRealEntities.tb_product.Include("ProductType").Include("tb_buy");
            crystalReportJoinTypeID1.Database.Tables["Demo_tb_product"].SetDataSource(product);

            var productType = dbshopRealEntities.ProductTypes.Include("tb_product");
            crystalReportJoinTypeID1.Database.Tables["Demo_ProductType"].SetDataSource(productType);

            crystalReportJoinTypeID1.SetParameterValue("typeid", typeid);
            crystalReportViewer1.ReportSource = crystalReportJoinTypeID1;
            crystalReportViewer1.Show();
        }
    }
}
