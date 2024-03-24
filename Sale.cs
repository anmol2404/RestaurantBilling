using iText.Kernel.Pdf.Canvas.Draw;
using Org.BouncyCastle.Crypto.Digests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Sale : Form
    {
        private dbclass dbclass;

        public int x;
        public int y;

        public string datetime;
        public int checkbox;

        public enum radiobutton
        {
            today = 1,
            monthly = 2,
            yearly = 3
        }
        public Sale()
        {
            InitializeComponent();
            dbclass = new dbclass();

            checkbox = (int)radiobutton.today;
            DateTimePicker.Value = DateTime.Now;
            DateTimePicker.Enabled = false;
            LoadSalesDatagrid(checkbox);
        }

        public void LoadSalesDatagrid(int checkbox)
        {
            try
            {
                DateTime dt = DateTimePicker.Value;
                int day = 0, month = 0, year = 0;
                if (checkbox == 1)
                {
                    day = dt.Day;
                    month = dt.Month;
                    year = dt.Year;
                    DataTable dataTable = dbclass.getSalesData(checkbox, day, month, year);

                    if (dataTable != null)
                    {
                        SalesDataGridView.DataSource = dataTable;
                        SalesDataGridView.Columns[0].Width = 60;
                        SalesDataGridView.Columns[1].Width = 100;
                        SalesDataGridView.Columns[2].Width = 100;
                        SalesDataGridView.Columns[3].Width = 100;
                    }

                }
                else if (checkbox == 2)
                {
                    month = dt.Month;
                    year = dt.Year;
                    DataTable dataTable = dbclass.getSalesData(checkbox,day, month, year);

                    if (dataTable != null)
                    {
                        SalesDataGridView.DataSource = dataTable;
                        SalesDataGridView.Columns[0].Width = 60;
                        SalesDataGridView.Columns[1].Width = 100;
                        SalesDataGridView.Columns[2].Width = 100;
                        SalesDataGridView.Columns[3].Width = 100;
                    }
                }
                else if (checkbox == 3)
                {
                    year = dt.Year;
                    DataTable dataTable = dbclass.getSalesData(checkbox, day, month, year);

                    if (dataTable != null)
                    {
                        SalesDataGridView.DataSource = dataTable;
                        SalesDataGridView.Columns[0].Width = 60;
                        SalesDataGridView.Columns[1].Width = 100;
                        SalesDataGridView.Columns[2].Width = 100;
                        SalesDataGridView.Columns[3].Width = 100;
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int PrintOrderNumber = dbclass.getordernumber();

            DataTable OrderDetail = dbclass.GetOrderNumberDetail(PrintOrderNumber);

            DataTable itemList = dbclass.getSaleData(PrintOrderNumber);

            string tablenumber = OrderDetail.Rows[0][1].ToString();
            string Orderamount = OrderDetail.Rows[0][2].ToString();
            
            DateTime date = Convert.ToDateTime(OrderDetail.Rows[0][3]);
            date = date.Date;

            e.Graphics.DrawString("TIRUPATI", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 90, 50);
            e.Graphics.DrawString("VAISHNO DHABA", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 70, 75);

            Pen dotted = new Pen(Color.Black);
            dotted.DashStyle = DashStyle.DashDot;
            e.Graphics.DrawLine(dotted, new Point(20, 100), new Point(265, 100));
            dotted.Dispose();

            e.Graphics.DrawString("Jawalaji Road, P.W.D Rest House,", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 35, 110);
            e.Graphics.DrawString("Nadaun Distt. Hamirpur, H.P.", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 50, 130);
            e.Graphics.DrawString("Contact: 01972-313228", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 62, 150);

            Pen dotted2 = new Pen(Color.Black);
            dotted2.DashStyle = DashStyle.DashDot;
            e.Graphics.DrawLine(dotted2, new Point(20, 170), new Point(265, 170));
            dotted2.Dispose();


            e.Graphics.DrawString("Order no.: " + PrintOrderNumber, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 180);
            e.Graphics.DrawString("Table no.: " + tablenumber, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 170, 180);

            e.Graphics.DrawString("Order date: " + date.ToString("dd-MM-yyyy"), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 200);

            Pen dotted3 = new Pen(Color.Black);
            dotted3.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted3, new Point(20, 217), new Point(265, 217));
            dotted3.Dispose();

            e.Graphics.DrawString("Particulars", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 220);
            e.Graphics.DrawString("Qty", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 170, 220);
            e.Graphics.DrawString("Price", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 230, 220);

            Pen dotted4 = new Pen(Color.Black);
            dotted4.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted4, new Point(20, 237), new Point(265, 237));
            dotted4.Dispose();

            y = 240;
            x = 20;

            foreach (DataRow row in itemList.Rows)
            {
                string itemname = (string)row["Particulars"];
                int qty = (int)row["Qty"];
                int price = (int)row["Item Amount"];

                e.Graphics.DrawString(itemname, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);
                x = x + 150;
                e.Graphics.DrawString(qty.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);
                x = x + 60;
                e.Graphics.DrawString(price.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);

                y = y + 15;
                x = 20;
            }
            Pen dotted5 = new Pen(Color.Black);
            dotted5.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted5, new Point(20, y+5), new Point(265, y+5));
            dotted5.Dispose();

            e.Graphics.DrawString("Total : ₹" + Orderamount + "/-", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 170, y+15);

            Pen dotted6 = new Pen(Color.Black);
            dotted6.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted6, new Point(20, y + 35), new Point(265, y + 35));
            dotted6.Dispose();
            
            e.Graphics.DrawString("THANK YOU!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, y + 40);
        }

        private void TodayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            if (TodayCheckBox.Checked == true)
            {
                checkbox = (int)radiobutton.today;
                DateTimePicker.Enabled = false;
                LoadSalesDatagrid(checkbox);
            }

        }

        private void OpenBilling_Click(object sender, EventArgs e)
        {
            Billing form = new Billing();
            form.ShowDialog();

            Sale sale = new Sale();
            sale.Close();
        }

        private void SalesDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                SalesDataGridView.Rows[e.RowIndex + i].Cells["Sno"].Value = snoValue;
            }
        }

        private void MonthlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            if (MonthlyCheckBox.Checked == true)
            {
                checkbox = (int)radiobutton.monthly;
                DateTimePicker.Enabled = true;
                LoadSalesDatagrid(checkbox);
            }
        }

        private void YearlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           
            if (YearlyCheckBox.Checked == true)
            {
                checkbox = (int)radiobutton.monthly;
                DateTimePicker.Enabled = true;
                LoadSalesDatagrid(checkbox);
            }
        }
    }
}
