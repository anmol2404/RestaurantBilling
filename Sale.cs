using Google.Protobuf.WellKnownTypes;
using iText.Kernel.Pdf.Canvas.Draw;
using Org.BouncyCastle.Asn1.Cmp;
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

        private int x;
        private int y;

        private string datetime;
        private int checkbox;

        private int Monthlymonth, Monthlyyear, YearlyYear;

        private int optional = 0;

        private enum radiobutton
        {
            today = 1,
            monthly = 2,
            yearly = 3,
            searchbyordernumber = 4
        }
        public Sale()
        {
            InitializeComponent();
            dbclass = new dbclass();

            checkbox = (int)radiobutton.today;
            DateTimePicker.Value = DateTime.Now;
            DateTimePicker.Enabled = false;
            YearlyCombobox.Enabled = false;
            MonthlymonthsComboBox.Enabled = false;
            MonthlyYearComboBox.Enabled = false;
            SearchSalesTextBox.Enabled = false;
            LoadSalesDatagrid(checkbox);
            LoadComboBox();

            MonthlymonthsComboBox.SelectedIndex = 1;
            MonthlyYearComboBox.SelectedIndex = 1;
            YearlyCombobox.SelectedIndex=1;
            Monthlymonth = MonthlymonthsComboBox.SelectedIndex;
            SalesDataGridView.ClearSelection();

        }

        private void LoadComboBox()
        {
            string[] monthNames = {
            "Months","January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December"
            };

            MonthlymonthsComboBox.Items.AddRange(monthNames);

            int year = 2023;
            int arraysize = 100;
            int[] yearlist = new int[arraysize];

            for (int i = 0; i < 100; i++)
            {
                yearlist[i] = year;

                year++;
            }

            foreach (int item in yearlist)
            {
                MonthlyYearComboBox.Items.Add(item.ToString());
                YearlyCombobox.Items.Add(item.ToString());
            }
        }

        private void LoadSalesDatagrid(int checkbox, int Month=0, int Year=0)
        {
            try
            {
                
                int day = 0, month = 0, year = 0;
                if (checkbox == 1)
                {
                    DateTime dt = DateTimePicker.Value;
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
                    if(dataTable.Rows.Count < 1)         
                    {
                        printPreviewControl1.Document = null;
                    }

                }
                else if (checkbox == 2)
                {
                    month = Month;
                    year = Year;
                    DataTable dataTable = dbclass.getSalesData(checkbox,day, month, year);

                    if (dataTable != null)
                    {
                        SalesDataGridView.DataSource = dataTable;
                        SalesDataGridView.Columns[0].Width = 60;
                        SalesDataGridView.Columns[1].Width = 100;
                        SalesDataGridView.Columns[2].Width = 100;
                        SalesDataGridView.Columns[3].Width = 100;
                    }
                    if (dataTable.Rows.Count < 1)
                    {
                        printPreviewControl1.Document = null;
                    }
                }
                else if (checkbox == 3)
                {
                    year = Year;
                    DataTable dataTable = dbclass.getSalesData(checkbox, day, month, year);

                    if (dataTable != null)
                    {
                        SalesDataGridView.DataSource = dataTable;
                        SalesDataGridView.Columns[0].Width = 60;
                        SalesDataGridView.Columns[1].Width = 100;
                        SalesDataGridView.Columns[2].Width = 100;
                        SalesDataGridView.Columns[3].Width = 100;
                    }
                    if (dataTable.Rows.Count < 1)
                    {
                        printPreviewControl1.Document = null;
                    }
                }
                else if (checkbox == 4)
                {
                    DateTime dt = DateTimePicker.Value;
                    day = dt.Day;
                    month = dt.Month;
                    year = dt.Year;
                    DataTable dataTable = dbclass.getSalesData(checkbox, day, month, year);

                    if (dataTable != null && dataTable.Rows.Count>0)
                    {
                        SalesDataGridView.DataSource = dataTable;
                        SalesDataGridView.Columns[0].Width = 60;
                        SalesDataGridView.Columns[1].Width = 100;
                        SalesDataGridView.Columns[2].Width = 100;
                        SalesDataGridView.Columns[3].Width = 100;
                    }
                    if (dataTable.Rows.Count < 1)
                    {
                        printPreviewControl1.Document = null;
                    }
                }
                SalesDataGridView.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        //private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        //{
        //    int PrintOrderNumber = dbclass.getordernumber();

        //    DataTable OrderDetail = dbclass.GetOrderNumberDetail(PrintOrderNumber);

        //    DataTable itemList = dbclass.getSaleData(PrintOrderNumber);

        //    string tablenumber = OrderDetail.Rows[0][1].ToString();
        //    string Orderamount = OrderDetail.Rows[0][2].ToString();
            
        //    DateTime date = Convert.ToDateTime(OrderDetail.Rows[0][3]);
        //    date = date.Date;

        //    e.Graphics.DrawString("TIRUPATI", new Font("Arial", 15, FontStyle.Bold), Brushes.Black, 90, 50);
        //    e.Graphics.DrawString("VAISHNO DHABA", new Font("Arial", 12, FontStyle.Regular), Brushes.Black, 70, 75);

        //    Pen dotted = new Pen(Color.Black);
        //    dotted.DashStyle = DashStyle.DashDot;
        //    e.Graphics.DrawLine(dotted, new Point(20, 100), new Point(265, 100));
        //    dotted.Dispose();

        //    e.Graphics.DrawString("Jawalaji Road, P.W.D Rest House,", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 35, 110);
        //    e.Graphics.DrawString("Nadaun Distt. Hamirpur, H.P.", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 50, 130);
        //    e.Graphics.DrawString("Contact: 01972-313228", new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 62, 150);

        //    Pen dotted2 = new Pen(Color.Black);
        //    dotted2.DashStyle = DashStyle.DashDot;
        //    e.Graphics.DrawLine(dotted2, new Point(20, 170), new Point(265, 170));
        //    dotted2.Dispose();


        //    e.Graphics.DrawString("Order no.: " + PrintOrderNumber, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 180);
        //    e.Graphics.DrawString("Table no.: " + tablenumber, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 170, 180);

        //    e.Graphics.DrawString("Order date: " + date.ToString("dd-MM-yyyy"), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 200);

        //    Pen dotted3 = new Pen(Color.Black);
        //    dotted3.DashStyle = DashStyle.Solid;
        //    e.Graphics.DrawLine(dotted3, new Point(20, 217), new Point(265, 217));
        //    dotted3.Dispose();

        //    e.Graphics.DrawString("Particulars", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 220);
        //    e.Graphics.DrawString("Qty", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 170, 220);
        //    e.Graphics.DrawString("Price", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 230, 220);

        //    Pen dotted4 = new Pen(Color.Black);
        //    dotted4.DashStyle = DashStyle.Solid;
        //    e.Graphics.DrawLine(dotted4, new Point(20, 237), new Point(265, 237));
        //    dotted4.Dispose();

        //    y = 240;
        //    x = 20;

        //    foreach (DataRow row in itemList.Rows)
        //    {
        //        string itemname = (string)row["Particulars"];
        //        int qty = (int)row["Qty"];
        //        int price = (int)row["Item Amount"];

        //        e.Graphics.DrawString(itemname, new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);
        //        x = x + 150;
        //        e.Graphics.DrawString(qty.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);
        //        x = x + 60;
        //        e.Graphics.DrawString(price.ToString(), new Font("Arial", 8, FontStyle.Regular), Brushes.Black, x, y);

        //        y = y + 15;
        //        x = 20;
        //    }
        //    Pen dotted5 = new Pen(Color.Black);
        //    dotted5.DashStyle = DashStyle.Solid;
        //    e.Graphics.DrawLine(dotted5, new Point(20, y+5), new Point(265, y+5));
        //    dotted5.Dispose();

        //    e.Graphics.DrawString("Total : ₹" + Orderamount + "/-", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 170, y+15);

        //    Pen dotted6 = new Pen(Color.Black);
        //    dotted6.DashStyle = DashStyle.Solid;
        //    e.Graphics.DrawLine(dotted6, new Point(20, y + 35), new Point(265, y + 35));
        //    dotted6.Dispose();
            
        //    e.Graphics.DrawString("THANK YOU!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, y + 40);
        //}

        private void TodayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            if (TodayCheckBox.Checked == true)
            {
                checkbox = (int)radiobutton.today;
                resetfields();
                DateTimePicker.Enabled = false;
                LoadSalesDatagrid(checkbox);
                SalesDataGridView.ClearSelection();
            }
            else
            {
                TotalAmountLabel.Text = "----";
                TotalOrdersLabel.Text = "----";
                printPreviewControl1.Document = null;
            }
        }
        private void SalesDataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                SalesDataGridView.Rows[e.RowIndex + i].Cells["Sno"].Value = snoValue;
            }

            if (checkbox == 1 || checkbox == 2 || checkbox == 3)
            {
                TotalTextBoxValue();
            }
            if (checkbox == 4)
            {
                TotalAmountLabel.Text = "----";
                TotalOrdersLabel.Text = "----";
            }
        }
        private void TotalTextBoxValue()
        {
            int sum = 0;
            int TotalOrders = 0;
            foreach (DataGridViewRow row in SalesDataGridView.Rows)
            {
                if (row.Cells["Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        TotalAmountLabel.Text = sum.ToString();
                    }
                }
                else
                {
                    TotalAmountLabel.Text = "----";
                    printPreviewControl1.Document = null;
                }
            }

            TotalOrders = SalesDataGridView.Rows.Count;

            if (TotalOrders > 0)
            {
                TotalOrdersLabel.Text = TotalOrders.ToString();
            }
            else
            {
                TotalOrdersLabel.Text = "----";
            }
        }

        private void MonthlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            
            if (MonthlyCheckBox.Checked == true)
            {
                checkbox = (int)radiobutton.monthly;
                resetfields();
                DateTimePicker.Enabled = false;
                YearlyCombobox.Enabled = false;

                MonthlymonthsComboBox.Enabled = true;
                MonthlyYearComboBox.Enabled = true;

                LoadSalesDatagrid(checkbox, Monthlymonth, Monthlyyear);
                SalesDataGridView.ClearSelection();

            }
            else
            {
                MonthlymonthsComboBox.Enabled = false;
                MonthlyYearComboBox.Enabled = false;
                TotalAmountLabel.Text = "----";
                TotalOrdersLabel.Text = "----";
                printPreviewControl1.Document = null;
            }
        }

        private void YearlyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           
            if (YearlyCheckBox.Checked == true)
            {
                checkbox = (int)radiobutton.yearly;
                resetfields();
                DateTimePicker.Enabled = false;
                YearlyCombobox.Enabled = true;
                LoadSalesDatagrid(checkbox, optional, YearlyYear);
                SalesDataGridView.ClearSelection();
            }
            else
            {
                YearlyCombobox.Enabled = false;
                TotalAmountLabel.Text = "----";
                TotalOrdersLabel.Text = "----";
                printPreviewControl1.Document = null;
            }
        }
        private void CustomRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (CustomRadioButton.Checked == true)
            {
                checkbox = (int)radiobutton.today;
                resetfields();
                DateTimePicker.Enabled = true;
                LoadSalesDatagrid(checkbox);
                SalesDataGridView.ClearSelection();
            }
            else
            {
                DateTimePicker.Enabled = false;
                TotalAmountLabel.Text = "----";
                TotalOrdersLabel.Text = "----";
                printPreviewControl1.Document = null;
            }
        }

        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TotalAmountLabel.Text = "----";
            TotalOrdersLabel.Text = "----";
            LoadSalesDatagrid(checkbox);
        }

        private void MonthlyYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Monthlyyear = Convert.ToInt32(MonthlyYearComboBox.SelectedItem.ToString());
            LoadSalesDatagrid(checkbox, Monthlymonth, Monthlyyear);
        }

        private void YearlyCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            YearlyYear = Convert.ToInt32(YearlyCombobox.SelectedItem.ToString());
            LoadSalesDatagrid(checkbox, optional, YearlyYear);
        }

        private void SearchByOrderNumber_CheckedChanged(object sender, EventArgs e)
        {
            if (SearchByOrderNumber.Checked == true)
            {
                SearchSalesTextBox.Enabled = true;
                checkbox = (int)radiobutton.searchbyordernumber;
                DataTable dt =dbclass.GetOrderNumberDetail(optional,checkbox);
                if (dt != null)
                {
                    SalesDataGridView.DataSource = dt;
                    SalesDataGridView.Columns[0].Width = 60;
                    SalesDataGridView.Columns[1].Width = 100;
                    SalesDataGridView.Columns[2].Width = 100;
                    SalesDataGridView.Columns[3].Width = 100;
                }
                if(dt.Rows.Count < 1)
                {
                    printPreviewControl1.Document = null;
                }
                SalesDataGridView.ClearSelection();
                printPreviewControl1.Document = null;
            }
            else 
            {
                SearchSalesTextBox.Enabled = false;
                TotalAmountLabel.Text = "----";
                TotalOrdersLabel.Text = "----";
                printPreviewControl1.Document = null;
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            (SalesDataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("Convert(Order_No, 'System.String') LIKE '{0}%'", SearchSalesTextBox.Text);
            if (string.IsNullOrWhiteSpace(SearchSalesTextBox.Text))
            {
                SearchByOrderNumber_CheckedChanged(sender, e);
            }
            SalesDataGridView.ClearSelection();
            printPreviewControl1.Document = null;
            printPreviewControl1.Zoom = 1;
        }

        private void PrintSalesButton_Click(object sender, EventArgs e)
        {
            if (printPreviewControl1.Document != null)
            {
                printPreviewControl1.Document.Print();
            }
        }

        private void ClearRefreshSalesButton_Click(object sender, EventArgs e)
        {
            resetfields();
            TodayCheckBox.Checked = true;
        }

        private void Sale_Load(object sender, EventArgs e)
        {
            SalesDataGridView.ClearSelection();
        }

        private void SalesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (SalesDataGridView.SelectedRows.Count == 0 && (checkbox == 1 || checkbox == 4) && TotalOrdersLabel.Text != "----")
            {
                // today and cusotm
                DateTime Date = DateTimePicker.Value;
                int totalorders = Convert.ToInt16(TotalOrdersLabel.Text.ToString());
                int totalamount = Convert.ToInt16(TotalAmountLabel.Text.ToString());

                printPreviewControl1.Document = null;
                printPreviewControl1.Zoom = 1;
                printPreviewControl1.Document = TodayCustomPreview(Date, totalorders, totalamount);
            }
            else if (SalesDataGridView.SelectedRows.Count == 0 && checkbox == 2)
            {
                // monthly
                string monthname = MonthlymonthsComboBox.SelectedItem.ToString();
                int totalorders = Convert.ToInt16(TotalOrdersLabel.Text.ToString());
                int totalamount = Convert.ToInt16(TotalAmountLabel.Text.ToString());

                printPreviewControl1.Document = null;
                printPreviewControl1.Zoom = 1;
                printPreviewControl1.Document = MonthlyReport(monthname,Monthlyyear,totalorders,totalamount);
            }
            else if (SalesDataGridView.SelectedRows.Count == 0 && checkbox == 3)
            {
                //yearly
                int totalorders = Convert.ToInt16(TotalOrdersLabel.Text.ToString());
                int totalamount = Convert.ToInt16(TotalAmountLabel.Text.ToString());
                printPreviewControl1.Document = null;
                printPreviewControl1.Zoom = 1;
                printPreviewControl1.Document = YearlyReport(YearlyYear, totalorders,totalamount);
            }
            else if (SalesDataGridView.SelectedRows.Count == 1)
            {
                int rowdata = Convert.ToInt16(SalesDataGridView.SelectedRows[0].Cells[1].Value.ToString());
                printPreviewControl1.Document = null;
                printPreviewControl1.Zoom = 1;
                printPreviewControl1.Document = Billpreview(rowdata);
            } 
        }

        private void MonthlymonthsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Monthlymonth = MonthlymonthsComboBox.SelectedIndex;
            LoadSalesDatagrid(checkbox, Monthlymonth, Monthlyyear);
        }

        private void resetfields()
        {
            SearchSalesTextBox.Text = string.Empty;
            DateTimePicker.Value = DateTime.Now;
            MonthlymonthsComboBox.SelectedIndex = 1;
            YearlyCombobox.SelectedIndex = 1;
            MonthlyYearComboBox.SelectedIndex = 1;
        }

        private PrintDocument Billpreview(int ordernumber)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("custom", 285, 700);
            
            pd.PrintPage += (sender, e) =>
            {
                DataTable OrderDetail = dbclass.GetOrderNumberDetail(ordernumber);

                DataTable itemList = dbclass.getSaleData(ordernumber);

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


                e.Graphics.DrawString("Order no.: " + ordernumber, new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 20, 180);
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
                e.Graphics.DrawLine(dotted5, new Point(20, y + 5), new Point(265, y + 5));
                dotted5.Dispose();

                e.Graphics.DrawString("Total : ₹" + Orderamount + "/-", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 165, y + 15);

                Pen dotted6 = new Pen(Color.Black);
                dotted6.DashStyle = DashStyle.Solid;
                e.Graphics.DrawLine(dotted6, new Point(20, y + 35), new Point(265, y + 35));
                dotted6.Dispose();

                e.Graphics.DrawString("THANK YOU!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, y + 40);
            };

            return pd;
        }

        private PrintDocument TodayCustomPreview(DateTime date, int totalorders, int totalamount)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("custom", 285, 700);

            pd.PrintPage += (sender, e) =>
            {
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

                e.Graphics.DrawString("Reciept date: " + date.ToString("dd-MM-yyyy"), new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 180);

                e.Graphics.DrawString("Total Orders: " + totalorders, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 200);
                e.Graphics.DrawString("Total Amount: ₹" + totalamount + "/-", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 220);

                Pen dotted3 = new Pen(Color.Black);
                dotted3.DashStyle = DashStyle.Solid;
                e.Graphics.DrawLine(dotted3, new Point(20, 237), new Point(265, 237));
                dotted3.Dispose();
            };
            return pd;
        }

        private PrintDocument MonthlyReport(string month, int year, int totalorders, int totalamount)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("custom", 285, 700);

            pd.PrintPage += (sender, e) =>
            {
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

                e.Graphics.DrawString("Montly Report", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 80, 180);

                e.Graphics.DrawString("Month: " + month, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 20, 205);
                e.Graphics.DrawString("Year: " + year, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 170, 205);

                e.Graphics.DrawString("Total Orders: " + totalorders, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 225);
                e.Graphics.DrawString("Total Amount: ₹" + totalamount + "/-", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 245);


                Pen dotted3 = new Pen(Color.Black);
                dotted3.DashStyle = DashStyle.Solid;
                e.Graphics.DrawLine(dotted3, new Point(20, 262), new Point(265, 262));
                dotted3.Dispose();
            };
            return pd;
        }

        private PrintDocument YearlyReport(int year, int totalorders, int totalamount)
        {
            PrintDocument pd = new PrintDocument();
            pd.DefaultPageSettings.PaperSize = new PaperSize("custom", 285, 700);

            pd.PrintPage += (sender, e) =>
            {
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

                e.Graphics.DrawString("Yearly Report", new Font("Arial", 12, FontStyle.Bold), Brushes.Black, 75, 180);

                e.Graphics.DrawString("Year: " + year, new Font("Arial", 10, FontStyle.Regular), Brushes.Black, 20, 205);

                e.Graphics.DrawString("Total Orders: " + totalorders, new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 225);
                e.Graphics.DrawString("Total Amount: ₹" + totalamount + "/-", new Font("Arial", 9, FontStyle.Regular), Brushes.Black, 20, 245);


                Pen dotted3 = new Pen(Color.Black);
                dotted3.DashStyle = DashStyle.Solid;
                e.Graphics.DrawLine(dotted3, new Point(20, 262), new Point(265, 262));
                dotted3.Dispose();
            };
            return pd;
        }
    }
     
}
