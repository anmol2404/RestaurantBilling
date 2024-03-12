using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class AddUpdateForm : Form
    {
        
        private dbclass dbclass;
        public AddUpdateForm()
        {
            InitializeComponent();
            dbclass = new dbclass();
        }

        public void resettextbox() 
        {
            ItemIDLabel.Text = "";
            ItemNameTextBox.Text = "";
            HalfPlatePriceTextBox.Text = "";
            FullPlatePriceTextBox.Text = "";
            SearchTextBox.Text = "";
        }

        private void AddUpdateForm_Load(object sender, EventArgs e)
        {
            LoadDatagrid();
            UpdateButton.Enabled = false;
        }

        private void LoadDatagrid()
        {
            try
            {
                DataTable dataTable = dbclass.getData();

                if (dataTable != null )
                {
                    AddUpdateDatagrid.DataSource = dbclass.getData();
                    AddUpdateDatagrid.Columns[0].Width = 50;
                    AddUpdateDatagrid.Columns[1].Width = 173;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"error :{ex.Message}");
            }
        }

        private void AddNewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ItemNameTextBox.Text) || string.IsNullOrEmpty(FullPlatePriceTextBox.Text))
                {
                    MessageBox.Show("Please Enter the Name and the price");
                }
                else
                {
                    string ItemName = ItemNameTextBox.Text;

                    if (string.IsNullOrWhiteSpace(HalfPlatePriceTextBox.Text))
                    {
                        HalfPlatePriceTextBox.Text = "0";
                    }
                    int hprice = Convert.ToInt32(HalfPlatePriceTextBox.Text);
                    int fprice = Convert.ToInt32(FullPlatePriceTextBox.Text);

                    bool isInserted = dbclass.AddItem(ItemName, fprice, hprice);

                    if (isInserted)
                    {
                        resettextbox();
                        LoadDatagrid();
                        MessageBox.Show("Item Inserted Succesfully");
                    }
                    else
                    {
                        MessageBox.Show("Not Inserted");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                throw;
            }
            
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(AddUpdateDatagrid.SelectedRows[0].Cells[0].Value.ToString());
            if (index > 0)
            {
                DialogResult resil = MessageBox.Show("Do you want to delete the selected record", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resil == DialogResult.Yes)
                {
                    bool isdeleted = dbclass.DeleteItem(index);
                    if (isdeleted)
                    {
                        LoadDatagrid();
                        resettextbox();
                        enablebuttons();
                        MessageBox.Show("Item deleted sucessfuly");
                        
                    }
                    else
                    {
                        MessageBox.Show("Not Deleted");
                    }
                }
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(AddUpdateDatagrid.SelectedRows[0].Cells[0].Value.ToString());

            string itemname = AddUpdateDatagrid.SelectedRows[0].Cells[1].Value.ToString();

            int itemhprice = Convert.ToInt32(AddUpdateDatagrid.SelectedRows[0].Cells[2].Value.ToString());
            int itemfprice = Convert.ToInt32(AddUpdateDatagrid.SelectedRows[0].Cells[3].Value.ToString());

            if (index > 0)
            {
                resettextbox();
                AddNewButton.Enabled = false;
                UpdateButton.Enabled = true;
                ItemIDLabel.Text = index.ToString();
                ItemNameTextBox.Text = itemname;
                HalfPlatePriceTextBox.Text= itemhprice.ToString();
                FullPlatePriceTextBox.Text= itemfprice.ToString();

            }
        }

        private void Clearbutton_Click(object sender, EventArgs e)
        {
            LoadDatagrid();
            resettextbox();
            SearchTextBox.Text = "";
            enablebuttons();
        }

        private void enablebuttons()
        {
            AddNewButton.Enabled = true;
            DeleteButton.Enabled = true;
            EditButton.Enabled = true;
            UpdateButton.Enabled = false;
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ItemNameTextBox.Text) || string.IsNullOrEmpty(FullPlatePriceTextBox.Text))
                {
                    MessageBox.Show("Item Name and Full price cannot be empty");
                }
                else
                {
                    int id = Convert.ToInt32(ItemIDLabel.Text);
                    string Itemname = ItemNameTextBox.Text;
                    if (string.IsNullOrWhiteSpace(HalfPlatePriceTextBox.Text))
                    {
                        HalfPlatePriceTextBox.Text = "0";
                    }
                    int itemHprice = Convert.ToInt32(HalfPlatePriceTextBox.Text);
                    int itemFprice = Convert.ToInt32(FullPlatePriceTextBox.Text);
                    if (id > 0)
                    {
                        DialogResult result = MessageBox.Show("Do you really want to update", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (result == DialogResult.Yes)
                        {
                            bool isupdated = dbclass.UpdateItem(id, Itemname, itemHprice, itemFprice);

                            if (isupdated)
                            {
                                LoadDatagrid();
                                resettextbox();
                                enablebuttons();
                                MessageBox.Show("Item Updated sucessfully");
                            }
                            else
                            {
                                MessageBox.Show("Item not updated");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                throw;
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            (AddUpdateDatagrid.DataSource as DataTable).DefaultView.RowFilter = string.Format("Particulars LIKE '%{0}%'", SearchTextBox.Text);
            if (string.IsNullOrWhiteSpace(SearchTextBox.Text))
            {
                LoadDatagrid();
            }
        }

        private void BillingButton_Click(object sender, EventArgs e)
        {
            Billing billing = new Billing();

            billing.ShowDialog();

            this.Close();
        }
    }
}
