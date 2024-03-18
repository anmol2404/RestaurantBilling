//using iText.Kernel.Colors;
//using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using iText.Kernel.Pdf.Action;
using System.Drawing.Drawing2D;

namespace WindowsFormsApp1
{
    public partial class Billing : Form
    {
        private dbclass dbclass;

        public int itemID;
        public string Itemname;
        public int hprice;
        public int fprice;

        public int table2itemID;
        public string table2Itemname;
        public int table2hprice;
        public int table2fprice;

        public int table3itemID;
        public string table3Itemname;
        public int table3hprice;
        public int table3fprice;

        public int table4itemID;
        public string table4Itemname;
        public int table4hprice;
        public int table4fprice;

        public int table5itemID;
        public string table5Itemname;
        public int table5hprice;
        public int table5fprice;

        public int table6itemID;
        public string table6Itemname;
        public int table6hprice;
        public int table6fprice;

        public int table7itemID;
        public string table7Itemname;
        public int table7hprice;
        public int table7fprice;

        public int table8itemID;
        public string table8Itemname;
        public int table8hprice;
        public int table8fprice;

        public string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public int x, y;

        public Billing()
        {
            InitializeComponent();

            dbclass = new dbclass();

            CreateFolder();
            GetDefaultPrinterName();

            Linkcombobox();
            Table2Linkcombobox();
            Table3Linkcombobox();
            Table4Linkcombobox();
            Table5Linkcombobox();
            Table6Linkcombobox();
            Table7Linkcombobox();
            Table8Linkcombobox();

            TotalTextBox.Enabled = false;
            Table2TotalTextBox.Enabled = false;
            Table3TotalTextBox.Enabled = false;
            Table4TotalTextBox.Enabled = false;
            Table5TotalTextBox.Enabled = false;
            Table6TotalTextBox.Enabled = false;
            Table7TotalTextBox.Enabled = false;
            Table8TotalTextBox.Enabled = false;

            RemoveItembutton.Enabled = false;
            Table2RemoveButton.Enabled = false;
            Table3RemoveButton.Enabled = false;
            Table4RemoveButton.Enabled = false;
            Table5RemoveButton.Enabled = false;
            Table6RemoveButton.Enabled = false;
            Table7RemoveButton.Enabled = false;
            Table8RemoveButton.Enabled = false;

            SavePrintButton.Enabled = false;
            Table2Savebutton.Enabled = false;
            Table3SaveButton.Enabled = false;
            Table4SaveButton.Enabled = false;
            Table5SaveButton.Enabled = false;
            Table6SaveButton.Enabled = false;
            Table7SaveButton.Enabled = false;
            Table8SaveButton.Enabled = false;
        }


        public string CreateFolder()
        {
            string folderpath = System.IO.Path.Combine(desktopPath, "ORDERS");

            if (!Directory.Exists(folderpath))
            {
                Directory.CreateDirectory(folderpath);

                return folderpath;
            }
            return folderpath;
        }

        private string GetDefaultPrinterName()
        {
            PrinterSettings settings = new PrinterSettings();
            return settings.PrinterName;
        }
        #region table 1 
        private void Linkcombobox()
        {
            ItemNamecombobox.DataSource = dbclass.getData();
            ItemNamecombobox.DisplayMember = "Particulars";
            ItemNamecombobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            ItemNamecombobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void ItemNamecombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)ItemNamecombobox.SelectedItem;

            itemID = (int)selectedrow["S.No."];
            Itemname = (string)selectedrow["Particulars"];
            hprice = (int)selectedrow["Half P price"];
            fprice = (int)selectedrow["Full P price"];
            if (selectedrow != null)
            {
                FullPlatePriceButton.Text = "Full " + fprice;
                HalfPlatePriceButton.Text = "Half " + hprice;
                if (hprice == 0)
                {
                    HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    HalfPlatePriceButton.Enabled = true;
                }
            }
        }
        private void ClearButton_Click(object sender, EventArgs e)
        {
            Linkcombobox();
            TableOneDatagrid.Rows.Clear();
            TotalTextBox.Text = "";
            Qtytextbox.Value = 1;
        }
        private void FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)ItemNamecombobox.SelectedItem;

            itemID = (int)selectedrow["S.No."];
            Itemname = (string)selectedrow["Particulars"];
            fprice = (int)selectedrow["Full P price"];

            int qty = (int)Qtytextbox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in TableOneDatagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["ItemPrice"].Value.ToString());
                if (ItemIDExist == itemID && itempriceexist == fprice)
                {
                    int currentqty = int.Parse(row.Cells["Quantity"].Value.ToString());
                    row.Cells["Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * fprice;
                    row.Cells["Amount"].Value = amount;

                    TotalTextBoxValue();
                    Qtytextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * fprice;
                TableOneDatagrid.Rows.Add("", itemID, Itemname, qty, fprice, amount);
                Qtytextbox.Value = 1;
            }
        }
        private void TotalTextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in TableOneDatagrid.Rows)
            {
                if (row.Cells["Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void TableOneDatagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                TableOneDatagrid.Rows[e.RowIndex + i].Cells["Sno"].Value = snoValue;
            }
            RemoveItembutton.Enabled = true;
            SavePrintButton.Enabled = true;
            TotalTextBoxValue();
        }
        private void RemoveItembutton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(TableOneDatagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    TableOneDatagrid.Rows.RemoveAt(index);
                }
                if (TableOneDatagrid.Rows.Count == 0)
                {
                    TotalTextBox.Text = string.Empty;
                    RemoveItembutton.Enabled = false;
                    SavePrintButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }
        private void HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)ItemNamecombobox.SelectedItem;

            itemID = (int)selectedrow["S.No."];
            Itemname = (string)selectedrow["Particulars"];
            hprice = (int)selectedrow["Half P price"];

            Itemname = Itemname + " (Half Plate)";

            int qty = (int)Qtytextbox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in TableOneDatagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["ItemPrice"].Value.ToString());

                if (ItemIDExist == itemID && itempriceexist == hprice)
                {
                    int currentqty = int.Parse(row.Cells["Quantity"].Value.ToString());
                    row.Cells["Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * hprice;
                    row.Cells["Amount"].Value = amount;

                    TotalTextBoxValue();
                    Qtytextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * hprice;
                TableOneDatagrid.Rows.Add("", itemID, Itemname, qty, hprice, amount);
                Qtytextbox.Value = 1;
            }
        }
        private void TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TotalTextBox.Text))
            {
                SavePrintButton.Enabled = false;
            }
        }
        #endregion

        #region table 2
        private void Table2Linkcombobox()
        {
            Table2Combobox.DataSource = dbclass.getData();
            Table2Combobox.DisplayMember = "Particulars";
            Table2Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table2Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table2TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table2DataGrid.Rows)
            {
                if (row.Cells["Table2Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table2Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table2Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table2TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table2TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void Table2Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table2Combobox.SelectedItem;

            table2itemID = (int)selectedrow["S.No."];
            table2Itemname = (string)selectedrow["Particulars"];
            table2hprice = (int)selectedrow["Half P price"];
            table2fprice = (int)selectedrow["Full P price"];
            if (selectedrow != null)
            {
                Table2FullPlateButton.Text = "Full " + table2fprice;
                Table2HalfPlateButton.Text = "Half " + table2hprice;
                if (table2hprice == 0)
                {
                    Table2HalfPlateButton.Enabled = false;
                }
                else
                {
                    Table2HalfPlateButton.Enabled = true;
                }
            }
        }
        private void Table2DataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table2DataGrid.Rows[e.RowIndex + i].Cells["Table2Sno"].Value = snoValue;
            }
            Table2RemoveButton.Enabled = true;
            Table2Savebutton.Enabled = true;
            Table2TextBoxValue();
        }
        private void Table2RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table2DataGrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table2DataGrid.Rows.RemoveAt(index);
                }
                if (Table2DataGrid.Rows.Count == 0)
                {
                    Table2TotalTextBox.Text = string.Empty;
                    Table2RemoveButton.Enabled = false;
                    Table2Savebutton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }
        private void Table2HalfPlateButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table2Combobox.SelectedItem;

            table2itemID = (int)selectedrow["S.No."];
            table2Itemname = (string)selectedrow["Particulars"];
            table2hprice = (int)selectedrow["Half P price"];

            table2Itemname = table2Itemname + " (Half Plate)";

            int qty = (int)Table2QuantityTextbox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table2DataGrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table2Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table2ItemPrice"].Value.ToString());

                if (ItemIDExist == table2itemID && itempriceexist == table2hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table2Quantity"].Value.ToString());
                    row.Cells["Table2Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table2hprice;
                    row.Cells["Table2Amount"].Value = amount;

                    Table2TextBoxValue();
                    Table2QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table2hprice;
                Table2DataGrid.Rows.Add("", table2itemID, table2Itemname, qty, table2hprice, amount);
                Table2QuantityTextbox.Value = 1;
            }
        }
        private void Table2FullPlateButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table2Combobox.SelectedItem;

            table2itemID = (int)selectedrow["S.No."];
            table2Itemname = (string)selectedrow["Particulars"];
            table2fprice = (int)selectedrow["Full P price"];

            int qty = (int)Table2QuantityTextbox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table2DataGrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table2Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table2ItemPrice"].Value.ToString());
                if (ItemIDExist == table2itemID && itempriceexist == table2fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table2Quantity"].Value.ToString());
                    row.Cells["Table2Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table2fprice;
                    row.Cells["Table2Amount"].Value = amount;

                    Table2TextBoxValue();
                    Table2QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table2fprice;

                Table2DataGrid.Rows.Add("", table2itemID, table2Itemname, qty, table2fprice, amount);
                Table2QuantityTextbox.Value = 1;
            }
        }
        private void Table2ClearRefreshbutton_Click(object sender, EventArgs e)
        {
            Table2Linkcombobox();
            Table2DataGrid.Rows.Clear();
            Table2TotalTextBox.Text = "";
            Table2QuantityTextbox.Value = 1;
        }
        private void Table2TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table2TotalTextBox.Text))
            {
                Table2Savebutton.Enabled = false;
            }
        }
        #endregion

        #region table 3
        private void Table3Linkcombobox()
        {
            Table3Combobox.DataSource = dbclass.getData();
            Table3Combobox.DisplayMember = "Particulars";
            Table3Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table3Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table3TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table3Datagrid.Rows)
            {
                if (row.Cells["Table3Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table3Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table3Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table3TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table3TotalTextBox.Text = string.Empty;
                }
            }
        }
        private void Table3Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table3Combobox.SelectedItem;

            table3itemID = (int)selectedrow["S.No."];
            table3Itemname = (string)selectedrow["Particulars"];
            table3hprice = (int)selectedrow["Half P price"];
            table3fprice = (int)selectedrow["Full P price"];
            if (selectedrow != null)
            {
                Table3FullPlatePriceButton.Text = "Full " + table3fprice;
                Table3HalfPlatePriceButton.Text = "Half " + table3hprice;

                if (table3hprice == 0)
                {
                    Table3HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table3HalfPlatePriceButton.Enabled = true;
                }
            }
        }
        private void Table3Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table3Datagrid.Rows[e.RowIndex + i].Cells["Table3Sno"].Value = snoValue;
            }
            Table3RemoveButton.Enabled = true;
            Table3SaveButton.Enabled = true;
            Table3TextBoxValue();
        }
        private void Table3RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table3Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table3Datagrid.Rows.RemoveAt(index);
                }
                if (Table3Datagrid.Rows.Count == 0)
                {
                    Table3TotalTextBox.Text = string.Empty;
                    Table3RemoveButton.Enabled = false;
                    Table3SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }
        private void Table3HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table3Combobox.SelectedItem;

            table3itemID = (int)selectedrow["S.No."];
            table3Itemname = (string)selectedrow["Particulars"];
            table3hprice = (int)selectedrow["Half P price"];

            table3Itemname = table3Itemname + " (Half Plate)";

            int qty = (int)Table3QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table3Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table3Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table3ItemPrice"].Value.ToString());

                if (ItemIDExist == table3itemID && itempriceexist == table3hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table3Quantity"].Value.ToString());
                    row.Cells["Table3Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table3hprice;
                    row.Cells["Table3Amount"].Value = amount;

                    Table3TextBoxValue();
                    Table3QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table3hprice;
                Table3Datagrid.Rows.Add("", table3itemID, table3Itemname, qty, table3hprice, amount);
                Table3QuantityTextBox.Value = 1;
            }
        }
        private void Table3FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table3Combobox.SelectedItem;

            table3itemID = (int)selectedrow["S.No."];
            table3Itemname = (string)selectedrow["Particulars"];
            table3fprice = (int)selectedrow["Full P price"];

            int qty = (int)Table3QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table3Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table3Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table3ItemPrice"].Value.ToString());
                if (ItemIDExist == table3itemID && itempriceexist == table3fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table3Quantity"].Value.ToString());
                    row.Cells["Table3Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table3fprice;
                    row.Cells["Table3Amount"].Value = amount;

                    Table3TextBoxValue();
                    Table3QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table3fprice;

                Table3Datagrid.Rows.Add("", table3itemID, table3Itemname, qty, table3fprice, amount);
                Table3QuantityTextBox.Value = 1;
            }
        }
        private void Table3ClearRefreshbutton_Click(object sender, EventArgs e)
        {
            Table3Linkcombobox();
            Table3Datagrid.Rows.Clear();
            Table3TotalTextBox.Text = "";
            Table3QuantityTextBox.Value = 1;
        }
        private void Table3TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table3TotalTextBox.Text))
            {
                Table3SaveButton.Enabled = false;
            }
        }
        #endregion

        #region table 4
        private void Table4Linkcombobox()
        {
            Table4Combobox.DataSource = dbclass.getData();
            Table4Combobox.DisplayMember = "Particulars";
            Table4Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table4Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table4TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table4DataGrid.Rows)
            {
                if (row.Cells["Table4Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table4Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table4Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table4TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table4TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table4Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table4Combobox.SelectedItem;

            table4itemID = (int)selectedrow["S.No."];
            table4Itemname = (string)selectedrow["Particulars"];
            table4hprice = (int)selectedrow["Half P price"];
            table4fprice = (int)selectedrow["Full P price"];
            if (selectedrow != null)
            {
                Table4FullPlatePriceButton.Text = "Full " + table4fprice;
                Table4HalfPlatePriceButton.Text = "Half " + table4hprice;

                if (table4hprice == 0)
                {
                    Table4HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table4HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table4DataGrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table4DataGrid.Rows[e.RowIndex + i].Cells["Table4Sno"].Value = snoValue;
            }
            Table4RemoveButton.Enabled = true;
            Table4SaveButton.Enabled = true;
            Table4TextBoxValue();
        }

        private void Table4RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table4DataGrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table4DataGrid.Rows.RemoveAt(index);
                }
                if (Table4DataGrid.Rows.Count == 0)
                {
                    Table4TotalTextBox.Text = string.Empty;
                    Table4RemoveButton.Enabled = false;
                    Table4SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table4HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table4Combobox.SelectedItem;

            table4itemID = (int)selectedrow["S.No."];
            table4Itemname = (string)selectedrow["Particulars"];
            table4hprice = (int)selectedrow["Half P price"];

            table4Itemname = table4Itemname + " (Half Plate)";

            int qty = (int)Table4QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table4DataGrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table4Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table4ItemPrice"].Value.ToString());

                if (ItemIDExist == table4itemID && itempriceexist == table4hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table4Quantity"].Value.ToString());
                    row.Cells["Table4Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table4hprice;
                    row.Cells["Table4Amount"].Value = amount;

                    Table4TextBoxValue();
                    Table4QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table4hprice;
                Table4DataGrid.Rows.Add("", table4itemID, table4Itemname, qty, table4hprice, amount);
                Table4QuantityTextBox.Value = 1;
            }
        }

        private void Table4FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table4Combobox.SelectedItem;

            table4itemID = (int)selectedrow["S.No."];
            table4Itemname = (string)selectedrow["Particulars"];
            table4fprice = (int)selectedrow["Full P price"];

            int qty = (int)Table4QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table4DataGrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table4Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table4ItemPrice"].Value.ToString());
                if (ItemIDExist == table4itemID && itempriceexist == table4fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table4Quantity"].Value.ToString());
                    row.Cells["Table4Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table4fprice;
                    row.Cells["Table4Amount"].Value = amount;

                    Table4TextBoxValue();
                    Table4QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table4fprice;

                Table4DataGrid.Rows.Add("", table4itemID, table4Itemname, qty, table4fprice, amount);
                Table4QuantityTextBox.Value = 1;
            }
        }

        private void Table4ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table4Linkcombobox();
            Table4DataGrid.Rows.Clear();
            Table4TotalTextBox.Text = "";
            Table4QuantityTextBox.Value = 1;
        }

        private void Table4TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table4TotalTextBox.Text))
            {
                Table4SaveButton.Enabled = false;
            }
        }
        #endregion

        #region table 5
        private void Table5Linkcombobox()
        {
            Table5Combobox.DataSource = dbclass.getData();
            Table5Combobox.DisplayMember = "Particulars";
            Table5Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table5Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table5TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table5Datagrid.Rows)
            {
                if (row.Cells["Table5Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table5Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table5Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table5TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table5TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table5Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table5Combobox.SelectedItem;

            table5itemID = (int)selectedrow["S.No."];
            table5Itemname = (string)selectedrow["Particulars"];
            table5hprice = (int)selectedrow["Half P price"];
            table5fprice = (int)selectedrow["Full P price"];
            if (selectedrow != null)
            {
                Table5FullPlatePriceButton.Text = "Full " + table5fprice;
                Table5HalfPlatePriceButton.Text = "Half " + table5hprice;

                if (table5hprice == 0)
                {
                    Table5HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table5HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table5Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table5Datagrid.Rows[e.RowIndex + i].Cells["Table5Sno"].Value = snoValue;
            }
            Table5RemoveButton.Enabled = true;
            Table5SaveButton.Enabled = true;
            Table5TextBoxValue();
        }

        private void Table5RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table5Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table5Datagrid.Rows.RemoveAt(index);
                }
                if (Table5Datagrid.Rows.Count == 0)
                {
                    Table5TotalTextBox.Text = string.Empty;
                    Table5RemoveButton.Enabled = false;
                    Table5SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table5HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table5Combobox.SelectedItem;

            table5itemID = (int)selectedrow["S.No."];
            table5Itemname = (string)selectedrow["Particulars"];
            table5hprice = (int)selectedrow["Half P price"];

            table5Itemname = table5Itemname + " (Half Plate)";

            int qty = (int)Table5QuantityTextbox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table5Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table5Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table5ItemPrice"].Value.ToString());

                if (ItemIDExist == table5itemID && itempriceexist == table5hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table5Quantity"].Value.ToString());
                    row.Cells["Table5Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table5hprice;
                    row.Cells["Table5Amount"].Value = amount;

                    Table5TextBoxValue();
                    Table5QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table5hprice;
                Table5Datagrid.Rows.Add("", table5itemID, table5Itemname, qty, table5hprice, amount);
                Table5QuantityTextbox.Value = 1;
            }
        }

        private void Table5FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table5Combobox.SelectedItem;

            table5itemID = (int)selectedrow["S.No."];
            table5Itemname = (string)selectedrow["Particulars"];
            table5fprice = (int)selectedrow["Full P price"];

            int qty = (int)Table5QuantityTextbox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table5Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table5Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table5ItemPrice"].Value.ToString());
                if (ItemIDExist == table5itemID && itempriceexist == table5fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table5Quantity"].Value.ToString());
                    row.Cells["Table5Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table5fprice;
                    row.Cells["Table5Amount"].Value = amount;

                    Table5TextBoxValue();
                    Table5QuantityTextbox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table5fprice;

                Table5Datagrid.Rows.Add("", table5itemID, table5Itemname, qty, table5fprice, amount);
                Table5QuantityTextbox.Value = 1;
            }
        }

        private void Table5ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table5Linkcombobox();
            Table5Datagrid.Rows.Clear();
            Table5TotalTextBox.Text = "";
            Table5QuantityTextbox.Value = 1;
        }

        private void Table5TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table5TotalTextBox.Text))
            {
                Table5SaveButton.Enabled = false;
            }
        }
        #endregion

        #region table 6
        private void Table6Linkcombobox()
        {
            Table6Combobox.DataSource = dbclass.getData();
            Table6Combobox.DisplayMember = "Particulars";
            Table6Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table6Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table6TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table6Datagrid.Rows)
            {
                if (row.Cells["Table6Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table6Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table6Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table6TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table6TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table6Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table6Combobox.SelectedItem;

            table6itemID = (int)selectedrow["S.No."];
            table6Itemname = (string)selectedrow["Particulars"];
            table6hprice = (int)selectedrow["Half P price"];
            table6fprice = (int)selectedrow["Full P price"];
            if (selectedrow != null)
            {
                Table6FullPlatePriceButton.Text = "Full " + table6fprice;
                Table6HalfPlatePriceButton.Text = "Half " + table6hprice;

                if (table6hprice == 0)
                {
                    Table6HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table6HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table6Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table6Datagrid.Rows[e.RowIndex + i].Cells["Table6Sno"].Value = snoValue;
            }
            Table6RemoveButton.Enabled = true;
            Table6SaveButton.Enabled = true;
            Table6TextBoxValue();
        }

        private void Table6RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table6Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table6Datagrid.Rows.RemoveAt(index);
                }
                if (Table6Datagrid.Rows.Count == 0)
                {
                    Table6TotalTextBox.Text = string.Empty;
                    Table6RemoveButton.Enabled = false;
                    Table6SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table6HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table6Combobox.SelectedItem;

            table6itemID = (int)selectedrow["S.No."];
            table6Itemname = (string)selectedrow["Particulars"];
            table6hprice = (int)selectedrow["Half P price"];

            table6Itemname = table6Itemname + " (Half Plate)";

            int qty = (int)Table6QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table6Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table6Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table6ItemPrice"].Value.ToString());

                if (ItemIDExist == table6itemID && itempriceexist == table6hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table6Quantity"].Value.ToString());
                    row.Cells["Table6Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table6hprice;
                    row.Cells["Table6Amount"].Value = amount;

                    Table6TextBoxValue();
                    Table6QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table6hprice;
                Table6Datagrid.Rows.Add("", table6itemID, table6Itemname, qty, table6hprice, amount);
                Table6QuantityTextBox.Value = 1;
            }
        }

        private void Table6FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table6Combobox.SelectedItem;

            table6itemID = (int)selectedrow["S.No."];
            table6Itemname = (string)selectedrow["Particulars"];
            table6fprice = (int)selectedrow["Full P price"];

            int qty = (int)Table6QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table6Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table6Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table6ItemPrice"].Value.ToString());
                if (ItemIDExist == table6itemID && itempriceexist == table6fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table6Quantity"].Value.ToString());
                    row.Cells["Table6Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table6fprice;
                    row.Cells["Table6Amount"].Value = amount;

                    Table6TextBoxValue();
                    Table6QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table6fprice;

                Table6Datagrid.Rows.Add("", table6itemID, table6Itemname, qty, table6fprice, amount);
                Table6QuantityTextBox.Value = 1;
            }
        }

        private void Table6ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table6Linkcombobox();
            Table6Datagrid.Rows.Clear();
            Table6TotalTextBox.Text = "";
            Table6QuantityTextBox.Value = 1;
        }

        private void Table6TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table6TotalTextBox.Text))
            {
                Table6SaveButton.Enabled = false;
            }
        }
        #endregion

        #region table 7
        private void Table7Linkcombobox()
        {
            Table7Combobox.DataSource = dbclass.getData();
            Table7Combobox.DisplayMember = "Particulars";
            Table7Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table7Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table7TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table7Datagrid.Rows)
            {
                if (row.Cells["Table7Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table7Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table7Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table7TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table7TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table7Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table7Combobox.SelectedItem;

            table7itemID = (int)selectedrow["S.No."];
            table7Itemname = (string)selectedrow["Particulars"];
            table7hprice = (int)selectedrow["Half P price"];
            table7fprice = (int)selectedrow["Full P price"];
            if (selectedrow != null)
            {
                Table7FullPlatePriceButton.Text = "Full " + table7fprice;
                Table7HalfPlatePriceButton.Text = "Half " + table7hprice;

                if (table7hprice == 0)
                {
                    Table7HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table7HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table7Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table7Datagrid.Rows[e.RowIndex + i].Cells["Table7Sno"].Value = snoValue;
            }
            Table7RemoveButton.Enabled = true;
            Table7SaveButton.Enabled = true;
            Table7TextBoxValue();
        }

        private void Table7RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table7Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table7Datagrid.Rows.RemoveAt(index);
                }
                if (Table7Datagrid.Rows.Count == 0)
                {
                    Table7TotalTextBox.Text = string.Empty;
                    Table7RemoveButton.Enabled = false;
                    Table7SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table7HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table7Combobox.SelectedItem;

            table7itemID = (int)selectedrow["S.No."];
            table7Itemname = (string)selectedrow["Particulars"];
            table7hprice = (int)selectedrow["Half P price"];

            table7Itemname = table7Itemname + " (Half Plate)";

            int qty = (int)Table7QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table7Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table7Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table7ItemPrice"].Value.ToString());

                if (ItemIDExist == table7itemID && itempriceexist == table7hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table7Quantity"].Value.ToString());
                    row.Cells["Table7Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table7hprice;
                    row.Cells["Table7Amount"].Value = amount;

                    Table7TextBoxValue();
                    Table7QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table7hprice;
                Table7Datagrid.Rows.Add("", table7itemID, table7Itemname, qty, table7hprice, amount);
                Table7QuantityTextBox.Value = 1;
            }
        }

        private void Table7FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table7Combobox.SelectedItem;

            table7itemID = (int)selectedrow["S.No."];
            table7Itemname = (string)selectedrow["Particulars"];
            table7fprice = (int)selectedrow["Full P price"];

            int qty = (int)Table7QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table7Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table7Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table7ItemPrice"].Value.ToString());
                if (ItemIDExist == table7itemID && itempriceexist == table7fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table7Quantity"].Value.ToString());
                    row.Cells["Table7Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table7fprice;
                    row.Cells["Table7Amount"].Value = amount;

                    Table7TextBoxValue();
                    Table7QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table7fprice;

                Table7Datagrid.Rows.Add("", table7itemID, table7Itemname, qty, table7fprice, amount);
                Table7QuantityTextBox.Value = 1;
            }
        }

        private void Table7ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table7Linkcombobox();
            Table7Datagrid.Rows.Clear();
            Table7TotalTextBox.Text = "";
            Table7QuantityTextBox.Value = 1;
        }

        private void Table7TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table7TotalTextBox.Text))
            {
                Table7SaveButton.Enabled = false;
            }
        }
        #endregion

        #region table 8
        private void Table8Linkcombobox()
        {
            Table8Combobox.DataSource = dbclass.getData();
            Table8Combobox.DisplayMember = "Particulars";
            Table8Combobox.AutoCompleteMode = AutoCompleteMode.Suggest;
            Table8Combobox.AutoCompleteSource = AutoCompleteSource.ListItems;
        }
        private void Table8TextBoxValue()
        {
            int sum = 0;
            foreach (DataGridViewRow row in Table8Datagrid.Rows)
            {
                if (row.Cells["Table8Amount"].Value != null && !string.IsNullOrEmpty(row.Cells["Table8Amount"].Value.ToString()))
                {
                    if (int.TryParse(row.Cells["Table8Amount"].Value.ToString(), out int cellValue))
                    {
                        sum += cellValue;
                        Table8TotalTextBox.Text = sum.ToString();
                    }
                }
                else
                {
                    Table8TotalTextBox.Text = string.Empty;
                }
            }
        }

        private void Table8Combobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table8Combobox.SelectedItem;

            table8itemID = (int)selectedrow["S.No."];
            table8Itemname = (string)selectedrow["Particulars"];
            table8hprice = (int)selectedrow["Half P price"];
            table8fprice = (int)selectedrow["Full P price"];
            if (selectedrow != null)
            {
                Table8FullPlatePriceButton.Text = "Full " + table8fprice;
                Table8HalfPlatePriceButton.Text = "Half " + table8hprice;

                if (table8hprice == 0)
                {
                    Table8HalfPlatePriceButton.Enabled = false;
                }
                else
                {
                    Table8HalfPlatePriceButton.Enabled = true;
                }
            }
        }

        private void Table8Datagrid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int i = 0; i < e.RowCount; i++)
            {
                int snoValue = e.RowIndex + i + 1;
                Table8Datagrid.Rows[e.RowIndex + i].Cells["Table8Sno"].Value = snoValue;
            }
            Table8RemoveButton.Enabled = true;
            Table8SaveButton.Enabled = true;
            Table8TextBoxValue();
        }

        private void Table8RemoveButton_Click(object sender, EventArgs e)
        {
            try
            {
                int index = Convert.ToInt32(Table8Datagrid.SelectedRows[0].Index);
                if (index >= 0)
                {
                    Table8Datagrid.Rows.RemoveAt(index);
                }
                if (Table8Datagrid.Rows.Count == 0)
                {
                    Table8TotalTextBox.Text = string.Empty;
                    Table8RemoveButton.Enabled = false;
                    Table8SaveButton.Enabled = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show($"error: No Item to Remove");
            }
        }

        private void Table8HalfPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table8Combobox.SelectedItem;

            table8itemID = (int)selectedrow["S.No."];
            table8Itemname = (string)selectedrow["Particulars"];
            table8hprice = (int)selectedrow["Half P price"];

            table8Itemname = table8Itemname + " (Half Plate)";

            int qty = (int)Table8QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table8Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table8Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table8ItemPrice"].Value.ToString());

                if (ItemIDExist == table8itemID && itempriceexist == table8hprice)
                {
                    int currentqty = int.Parse(row.Cells["Table8Quantity"].Value.ToString());
                    row.Cells["Table8Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table8hprice;
                    row.Cells["Table8Amount"].Value = amount;

                    Table8TextBoxValue();
                    Table8QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table8hprice;
                Table8Datagrid.Rows.Add("", table8itemID, table8Itemname, qty, table8hprice, amount);
                Table8QuantityTextBox.Value = 1;
            }
        }

        private void Table8FullPlatePriceButton_Click(object sender, EventArgs e)
        {
            DataRowView selectedrow = (DataRowView)Table8Combobox.SelectedItem;

            table8itemID = (int)selectedrow["S.No."];
            table8Itemname = (string)selectedrow["Particulars"];
            table8fprice = (int)selectedrow["Full P price"];

            int qty = (int)Table8QuantityTextBox.Value;

            if (qty <= 0)
            {
                MessageBox.Show("Please enter Quantity of the item");
            }
            foreach (DataGridViewRow row in Table8Datagrid.Rows)
            {
                int ItemIDExist = int.Parse(row.Cells["Table8Id"].Value.ToString());
                int itempriceexist = int.Parse(row.Cells["Table8ItemPrice"].Value.ToString());
                if (ItemIDExist == table8itemID && itempriceexist == table8fprice)
                {
                    int currentqty = int.Parse(row.Cells["Table8Quantity"].Value.ToString());
                    row.Cells["Table8Quantity"].Value = qty + currentqty;

                    int amount = (qty + currentqty) * table8fprice;
                    row.Cells["Table8Amount"].Value = amount;

                    Table8TextBoxValue();
                    Table8QuantityTextBox.Value = 1;
                    return;
                }
            }
            if (qty > 0)
            {
                int amount = qty * table8fprice;

                Table8Datagrid.Rows.Add("", table8itemID, table8Itemname, qty, table8fprice, amount);
                Table8QuantityTextBox.Value = 1;
            }
        }

        private void Table8ClearRefreshButton_Click(object sender, EventArgs e)
        {
            Table8Linkcombobox();
            Table8Datagrid.Rows.Clear();
            Table8TotalTextBox.Text = "";
            Table8QuantityTextBox.Value = 1;
        }

        private void Table8TotalTextBox_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Table8TotalTextBox.Text))
            {
                Table8SaveButton.Enabled = false;
            }
        }
        #endregion

        private void AddUpdateOpenForm_Click(object sender, EventArgs e)
        {
            AddUpdateForm form = new AddUpdateForm();
            form.ShowDialog();
        }

        private void SavePrintButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            string tablenumber = "1";
            int amount = Convert.ToInt32(TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in TableOneDatagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Id"].Value.ToString());
                            string rowname = row.Cells["name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Amount"].Value.ToString());
                            
                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);
                           
                        }
                    }
                    Createpdf(Ordernumber, currentdate, tablenumber, TableOneDatagrid, amount);
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber , "Saved", MessageBoxButtons.OK);
                }
            }
            ClearButton_Click(sender, e);
        }

        private void Table2Savebutton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            string tablenumber = "2";
            int amount = Convert.ToInt32(Table2TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table2DataGrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table2Id"].Value.ToString());
                            string rowname = row.Cells["Table2name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table2Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table2ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table2Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    Createpdf(Ordernumber, currentdate, tablenumber, Table2DataGrid, amount);
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table2ClearRefreshbutton_Click(sender, e);
        }

        private void Table3SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            string tablenumber = "3";
            int amount = Convert.ToInt32(Table3TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table3Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table3Id"].Value.ToString());
                            string rowname = row.Cells["Table3name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table3Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table3ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table3Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    Createpdf(Ordernumber, currentdate, tablenumber, Table3Datagrid, amount);
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table3ClearRefreshbutton_Click(sender, e);
        }

        private void Table4SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            string tablenumber = "4";
            int amount = Convert.ToInt32(Table4TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table4DataGrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table4Id"].Value.ToString());
                            string rowname = row.Cells["Table4name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table4Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table4ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table4Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    Createpdf(Ordernumber, currentdate, tablenumber, Table4DataGrid, amount);
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table4ClearRefreshButton_Click(sender, e);
        }

        private void Table5SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            string tablenumber = "5";
            int amount = Convert.ToInt32(Table5TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table5Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table5Id"].Value.ToString());
                            string rowname = row.Cells["Table5name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table5Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table5ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table5Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    Createpdf(Ordernumber, currentdate, tablenumber, Table5Datagrid, amount);
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table5ClearRefreshButton_Click(sender, e);
        }

        private void Table6SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            string tablenumber = "6";
            int amount = Convert.ToInt32(Table6TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table6Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table6Id"].Value.ToString());
                            string rowname = row.Cells["Table6name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table6Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table6ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table6Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    Createpdf(Ordernumber, currentdate, tablenumber, Table6Datagrid, amount);
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table6ClearRefreshButton_Click(sender, e);
        }

        private void Table7SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            string tablenumber = "7";
            int amount = Convert.ToInt32(Table7TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0)
                {
                    foreach (DataGridViewRow row in Table7Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table7Id"].Value.ToString());
                            string rowname = row.Cells["Table7name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table7Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table7ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table7Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);

                        }
                    }
                    Createpdf(Ordernumber, currentdate, tablenumber, Table7Datagrid, amount);
                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table7ClearRefreshButton_Click(sender, e);
        }

        private void Table8SaveButton_Click(object sender, EventArgs e)
        {
            DateTime currentdate = DateTime.Now;
            string tablenumber = "8";
            int amount = Convert.ToInt32(Table8TotalTextBox.Text.ToString());

            bool isOrdercreated = dbclass.CreateOrderNumber(tablenumber, amount, currentdate);

            if (isOrdercreated)
            {
                int Ordernumber = dbclass.getordernumber();

                if (Ordernumber > 0) // ordernumber, amount, datetime, tablenumber, datagridview
                {
                    foreach (DataGridViewRow row in Table8Datagrid.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            int rowid = Convert.ToInt32(row.Cells["Table8Id"].Value.ToString());
                            string rowname = row.Cells["Table8name"].Value.ToString();
                            int rowquantity = Convert.ToInt32(row.Cells["Table8Quantity"].Value.ToString());
                            int rowprice = Convert.ToInt32(row.Cells["Table8ItemPrice"].Value.ToString());
                            int rowamount = Convert.ToInt32(row.Cells["Table8Amount"].Value.ToString());

                            dbclass.SavetoDatabase(tablenumber, rowid, rowname, rowquantity, rowprice, rowamount, currentdate, Ordernumber);
                        }
                    }

                    Createpdf(Ordernumber, currentdate, tablenumber, Table8Datagrid, amount);

                    MessageBox.Show("Order Saved Successfully with Order number: " + Ordernumber, "Saved", MessageBoxButtons.OK);
                }
            }
            Table8ClearRefreshButton_Click(sender, e);
        }

        private void Createpdf(int OrderNumber, DateTime Currentdate, string TableName, DataGridView TableDataGrid, int TableAmount)
        {
            try
            {
                string folderpath = CreateFolder();
                string pdfname = OrderNumber + ".pdf";

                string pdfpath = System.IO.Path.Combine(folderpath, pdfname);

                using (PdfWriter writer = new PdfWriter(pdfpath))
                {
                    using (iText.Kernel.Pdf.PdfDocument pdf = new iText.Kernel.Pdf.PdfDocument(writer))
                    {
                        Document document = new Document(pdf);

                        Paragraph header = new Paragraph("Tirupati Vaishno Dhaba")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(20);
                        header.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(header);

                        Paragraph address = new Paragraph("JawalaJi road, P.W.D Rest House,")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(15);
                        address.SetWidth(UnitValue.CreatePercentValue(100));
                        Paragraph address2 = new Paragraph("Nadaun Distt. Hamirpur, H.P.")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(15);
                        address2.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(address);
                        document.Add(address2);

                        Paragraph contact = new Paragraph("Contact: 01972-313228")
                            .SetTextAlignment(TextAlignment.CENTER)
                            .SetFontSize(15);
                        contact.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(contact);

                        LineSeparator ls = new LineSeparator(new DottedLine());
                        ls.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(ls);

                        Paragraph tableno = new Paragraph("Table No.: " + TableName)
                            .SetTextAlignment(TextAlignment.LEFT)
                            .SetFontSize(15);
                        tableno.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(tableno);

                        Paragraph date = new Paragraph("Date: " + Currentdate)
                           .SetTextAlignment(TextAlignment.LEFT)
                           .SetFontSize(15);
                        date.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(date);

                        LineSeparator ls2 = new LineSeparator(new SolidLine());
                        ls2.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(ls2);

                        Paragraph blank = new Paragraph("")
                           .SetTextAlignment(TextAlignment.LEFT)
                           .SetFontSize(15);
                        blank.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(blank);

                        Table table = new Table(4, false);
                        table.SetWidth(UnitValue.CreatePercentValue(100));
                        Cell particulars = new Cell(1, 1)
                          .SetTextAlignment(TextAlignment.CENTER)
                          .Add(new Paragraph("Particulars"));

                        Cell qty = new Cell(1, 1)
                          .SetTextAlignment(TextAlignment.CENTER)
                          .Add(new Paragraph("Qty"));

                        Cell price = new Cell(1, 1)
                          .SetTextAlignment(TextAlignment.CENTER)
                          .Add(new Paragraph("Price"));

                        Cell Particularsamount = new Cell(1, 1)
                          .SetTextAlignment(TextAlignment.CENTER)
                          .Add(new Paragraph("Amount"));

                        table.AddCell(particulars);
                        table.AddCell(qty);
                        table.AddCell(price);
                        table.AddCell(Particularsamount);


                        foreach (DataGridViewRow row in TableDataGrid.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                int rowid = Convert.ToInt32(row.Cells[1].Value.ToString());
                                string rowname = row.Cells[2].Value.ToString();
                                int rowquantity = Convert.ToInt32(row.Cells[3].Value.ToString());
                                int rowprice = Convert.ToInt32(row.Cells[4].Value.ToString());
                                int rowamount = Convert.ToInt32(row.Cells[5].Value.ToString());

                                Cell tableitemname = new Cell(1, 1)
                                  .SetTextAlignment(TextAlignment.CENTER)
                                  .Add(new Paragraph(rowname));

                                Cell tableitemqty = new Cell(1, 1)
                                  .SetTextAlignment(TextAlignment.CENTER)
                                  .Add(new Paragraph(rowquantity.ToString()));

                                Cell tableitemprice = new Cell(1, 1)
                                  .SetTextAlignment(TextAlignment.CENTER)
                                  .Add(new Paragraph(rowprice.ToString()));

                                Cell tableitemamount = new Cell(1, 1)
                                  .SetTextAlignment(TextAlignment.CENTER)
                                  .Add(new Paragraph(rowamount.ToString()));

                                table.AddCell(tableitemname);
                                table.AddCell(tableitemqty);
                                table.AddCell(tableitemprice);
                                table.AddCell(tableitemamount);
                            }
                        }
                        document.Add(table);
                        document.Add(blank);

                        Paragraph totalamount = new Paragraph("Total: Rs." + TableAmount +"/-")
                           .SetTextAlignment(TextAlignment.RIGHT)
                           .SetFontSize(15);
                        totalamount.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(totalamount);
                        document.Add(blank);

                        document.Add(ls2);

                        Paragraph thankyou = new Paragraph("Thank You")
                          .SetTextAlignment(TextAlignment.CENTER)
                          .SetFontSize(15);
                        thankyou.SetWidth(UnitValue.CreatePercentValue(100));
                        document.Add(thankyou);
                        document.Close();
                    }
                }
                string printername = GetDefaultPrinterName();
                if (!string.IsNullOrEmpty(printername))
                {
                    printPreviewDialog1.Document = printDocument1;
                    printDocument1.DefaultPageSettings.PaperSize = new PaperSize("custom", 285, 700);
                    printPreviewDialog1.ShowDialog(); ;
                    //printDocument1.Print();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error on printing: {ex.Message}");
                throw;
            }
        }

        public void PrintPdf(string pdfFilePath, string printerName)
        {
          
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
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

            Pen dotted = new Pen(System.Drawing.Color.Black);
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
            e.Graphics.DrawLine(dotted5, new Point(20, y + 5), new Point(265, y + 5));
            dotted5.Dispose();

            e.Graphics.DrawString("Total : ₹" + Orderamount + "/-", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 170, y + 15);

            Pen dotted6 = new Pen(Color.Black);
            dotted6.DashStyle = DashStyle.Solid;
            e.Graphics.DrawLine(dotted6, new Point(20, y + 35), new Point(265, y + 35));
            dotted6.Dispose();

            e.Graphics.DrawString("THANK YOU!", new Font("Arial", 10, FontStyle.Bold), Brushes.Black, 100, y + 40);
        }
    }
}
