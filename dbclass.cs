using iText.Layout.Splitting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class dbclass
    {
        private string constring;

        private AddUpdateDatagrid datagridview;

        public dbclass()
        {
            constring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;
        }

        public bool AddItem(string name, int fprice,int hprice)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "Insert into ItemTable (ItemName,Hprice,Fprice) VALUES (@Name, @hpprice, @fpprice)";

                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@hpprice", hprice);
                    cmd.Parameters.AddWithValue("@fpprice", fprice);
                    try
                    {
                        con.Open();
                        int isroweffected = cmd.ExecuteNonQuery();
                        con.Close();
                        return isroweffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error. {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public bool DeleteItem(int id)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "Delete from ItemTable where Id = @id";

                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    try
                    {
                        con.Open();
                        int isroweffected = cmd.ExecuteNonQuery();
                        con.Close();
                        return isroweffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error. {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public DataTable getData()
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "SELECT Id AS 'S.No.',ItemName AS 'Particulars', Hprice AS 'Half P price', Fprice AS 'Full P Price' from ItemTable";
                try
                {
                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(sqlcmd,con);
                    sda.Fill(dt);
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    throw;
                }
            }
            return dt;
        }
        public DataTable getSaleData(int OrderNumber)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "Select TableNumber as 'Table No.', ItemName as 'Particulars', ItemQuantity as 'Qty', ItemPrice as 'Item Price', ItemAmount as 'Item Amount', OrderDate as 'Date' from sale where OrderNumber = @ordernumber";
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    cmd.Parameters.AddWithValue("@ordernumber", OrderNumber);
                    try
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            return dt;
        }

        public DataTable getSalesData(int checkbox, int day = 0, int month = 0, int year = 0)
        {
            DataTable dt = new DataTable();
            using(SqlConnection con = new SqlConnection(constring))
            {
                if (checkbox == 1)
                {
                    string sqlcmd = "Select * from OrderNumber where Day = @day AND Month = @Month AND Year = @year";
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        cmd.Parameters.AddWithValue("@day", day);
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@year", year);
                        try
                        {
                            con.Open();
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            sda.Fill(dt);
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
                else if (checkbox == 2)
                {
                    string sqlcmd = "Select * from OrderNumber where Month = @Month AND Year = @year";
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@year", year);
                        try
                        {
                            con.Open();
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            sda.Fill(dt);
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
                else if (checkbox == 3)
                {
                    string sqlcmd = "Select * from OrderNumber where Year = @year";
                    using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                    {
                        cmd.Parameters.AddWithValue("@year", year);
                        try
                        {
                            con.Open();
                            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                            sda.Fill(dt);
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
                
            }
            return dt;
        }

        public DataTable GetOrderNumberDetail(int order)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "SELECT * FROM dbo.OrderNumber WHERE OrderNumber = @order";
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    cmd.Parameters.AddWithValue("@order", order);
                    try
                    {
                        con.Open();
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);
                        con.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                }
            }
            return dt;
        }    
        public bool UpdateItem(int id, string itemname, int itemhprice, int itemfprice)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "Update ItemTable set ItemName = @name, Hprice = @hprice, Fprice = @fprice where Id = @itemid";
                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    cmd.Parameters.AddWithValue("@itemid", id);
                    cmd.Parameters.AddWithValue("@name", itemname);
                    cmd.Parameters.AddWithValue("@hprice", itemhprice);
                    cmd.Parameters.AddWithValue("@fprice", itemfprice);
                    try
                    {
                        con.Open();
                        int isroweffected = cmd.ExecuteNonQuery();
                        return isroweffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error. {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public int SavetoDatabase(string tablenumber, int itemid, string Itemname, int itemquantity, int itemprice, int itemamount, DateTime orderdate, int OrderNumber)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "insert into sale(TableNumber, ItemID, ItemName, ItemQuantity, ItemPrice, ItemAmount, OrderDate, OrderNumber) VALUES (@tablenumber,@itemid,@itemname,@itemquantity,@itemprice,@itemamount,@orderdate,@ordernumber)";
                using (SqlCommand cmd= new SqlCommand(sqlcmd, con))
                {
                    cmd.Parameters.AddWithValue("@tablenumber", tablenumber);
                    cmd.Parameters.AddWithValue("@itemid", itemid);
                    cmd.Parameters.AddWithValue("@itemname", Itemname);
                    cmd.Parameters.AddWithValue("@itemquantity", itemquantity);
                    cmd.Parameters.AddWithValue("@itemprice", itemprice);
                    cmd.Parameters.AddWithValue("@itemamount", itemamount);
                    cmd.Parameters.AddWithValue("@orderdate", orderdate);
                    cmd.Parameters.AddWithValue("@ordernumber", OrderNumber);
                    try
                    {
                        con.Open();
                        int isroweffected = cmd.ExecuteNonQuery();

                        con.Close();
                        return isroweffected;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error. {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public bool CreateOrderNumber(string TableNumber, int Amount, DateTime Orderdate, int day, int month, int year)
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "insert into OrderNumber (TableNumber, Amount, OrderDate, Day, Month, Year) Values (@tablenumber, @amount, @orderdate, @day, @month, @year)";
                using (SqlCommand cmd =new SqlCommand(sqlcmd, con))
                {
                    cmd.Parameters.AddWithValue("@tablenumber", TableNumber);
                    cmd.Parameters.AddWithValue("@amount", Amount);
                    cmd.Parameters.AddWithValue("@orderdate", Orderdate);
                    cmd.Parameters.AddWithValue("@day", day);
                    cmd.Parameters.AddWithValue("@month", month);
                    cmd.Parameters.AddWithValue("@year", year);
                    try
                    {
                        con.Open();
                        int isroweffected = cmd.ExecuteNonQuery();
                        return isroweffected > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error. {ex.Message}");
                        throw;
                    }

                }
            }
        }

        public int getordernumber()
        {
            using (SqlConnection con = new SqlConnection(constring))
            {
                string sqlcmd = "SELECT IDENT_CURRENT('OrderNumber')";

                using (SqlCommand cmd = new SqlCommand(sqlcmd, con))
                {
                    con.Open();
                    int ordernumber = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                    return ordernumber;
                }
            }
        }
        
    }
}
