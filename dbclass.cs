using System;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class dbclass
    {
        private string constring;
        private static readonly string dbPath = Application.StartupPath + "Tulip.db";

        public dbclass()
        {
            constring = ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString;

        }
        public void CreateDatabaseAndFolder()
        {
            //if (!File.Exists("Tulip.db"))
            //{
            //    SQLiteConnection.CreateFile("Tulip.db");
            //}

            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            SQLiteConnection connection = new SQLiteConnection(constring);

            connection.Open();

            // Create a table if it doesn't exist
            string ItemTable = @"
                CREATE TABLE IF NOT EXISTS ItemTable (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    ItemName TEXT,
                    Hprice INTEGER,
                    Fprice INTEGER
                );";
            SQLiteCommand createTableCommand = new SQLiteCommand(ItemTable, connection);
            createTableCommand.ExecuteNonQuery();

            string on = @"
                CREATE TABLE IF NOT EXISTS OrderNumber (
                    OrderNumber INTEGER PRIMARY KEY AUTOINCREMENT,
                    TableNumber TEXT,
                    Amount INTEGER,
                    OrderDate DATETIME,
                    Day INTEGER,
                    Month INTEGER,
                    Year INTEGER
                );";
            createTableCommand = new SQLiteCommand(on, connection);
            createTableCommand.ExecuteNonQuery();

            string saletable = @"
                CREATE TABLE IF NOT EXISTS sale (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    TableNumber TEXT,
                    ItemID INTEGER,
                    ItemName TEXT,
                    ItemQuantity INTEGER,
                    ItemPrice INTEGER,
                    ItemAmount INTEGER,
                    OrderDate DATE,
                    OrderNumber INTEGER
                );";
            createTableCommand = new SQLiteCommand(saletable, connection);
            createTableCommand.ExecuteNonQuery();
            // Close the connection
            connection.Close();
        }

        public bool AddItem(string name, int fprice, int hprice)
        {
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                string sqlcmd = "Insert into ItemTable (ItemName,Hprice,Fprice) VALUES (@Name, @hpprice, @fpprice)";

                using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
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
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                string sqlcmd = "Delete from ItemTable where Id = @id";

                using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
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
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                string sqlcmd = "SELECT Id AS 'S.No.',ItemName AS 'Particulars', Hprice AS 'Half P price', Fprice AS 'Full P Price' from ItemTable";
                try
                {
                    con.Open();
                    SQLiteDataAdapter sda = new SQLiteDataAdapter(sqlcmd, con);
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
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                string sqlcmd = "Select TableNumber as 'Table No.', ItemName as 'Particulars', ItemQuantity as 'Qty', ItemPrice as 'Item Price', ItemAmount as 'Item Amount', OrderDate as 'Date' from sale where OrderNumber = @ordernumber Order By OrderNumber DESC";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
                {
                    cmd.Parameters.AddWithValue("@ordernumber", OrderNumber);
                    try
                    {
                        con.Open();
                        SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
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
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                if (checkbox == 1)
                {
                    string sqlcmd = "Select OrderNumber as 'Order No.', TableNumber as 'Table no.', Amount as 'Amount', OrderDate as 'Date' from OrderNumber where Day = @day AND Month = @Month AND Year = @year Order By OrderNumber DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
                    {
                        cmd.Parameters.AddWithValue("@day", day);
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@year", year);
                        try
                        {
                            con.Open();
                            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
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
                    string sqlcmd = "Select OrderNumber as 'Order No.', TableNumber as 'Table no.', Amount as 'Amount', OrderDate as 'Date' from OrderNumber where Month = @Month AND Year = @year Order By OrderNumber DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
                    {
                        cmd.Parameters.AddWithValue("@Month", month);
                        cmd.Parameters.AddWithValue("@year", year);
                        try
                        {
                            con.Open();
                            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
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
                    string sqlcmd = "Select OrderNumber as 'Order No.', TableNumber as 'Table no.', Amount as 'Amount', OrderDate as 'Date' from OrderNumber where Year = @year Order By OrderNumber DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
                    {
                        cmd.Parameters.AddWithValue("@year", year);
                        try
                        {
                            con.Open();
                            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
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

        public DataTable GetOrderNumberDetail(int order = 0, int checkbox = 0)
        {
            DataTable dt = new DataTable();

            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                if (checkbox == 0)
                {
                    string sqlcmd = "SELECT * FROM OrderNumber WHERE OrderNumber = @order Order By OrderNumber DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
                    {
                        cmd.Parameters.AddWithValue("@order", order);
                        try
                        {
                            con.Open();
                            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                            sda.Fill(dt);
                            con.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
                else if (checkbox == 4)
                {
                    string sqlcmd = "Select OrderNumber as 'Order_No', TableNumber as 'Table no.', Amount as 'Amount', OrderDate as 'Date' from OrderNumber Order By OrderNumber DESC";
                    using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
                    {
                        cmd.Parameters.AddWithValue("@order", order);
                        try
                        {
                            con.Open();
                            SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
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
        public bool UpdateItem(int id, string itemname, int itemhprice, int itemfprice)
        {
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                string sqlcmd = "Update ItemTable set ItemName = @name, Hprice = @hprice, Fprice = @fprice where Id = @itemid";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
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
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                string sqlcmd = "insert into sale(TableNumber, ItemID, ItemName, ItemQuantity, ItemPrice, ItemAmount, OrderDate, OrderNumber) VALUES (@tablenumber,@itemid,@itemname,@itemquantity,@itemprice,@itemamount,@orderdate,@ordernumber)";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
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
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                string sqlcmd = "insert into OrderNumber (TableNumber, Amount, OrderDate, Day, Month, Year) Values (@tablenumber, @amount, @orderdate, @day, @month, @year)";
                using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
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
            using (SQLiteConnection con = new SQLiteConnection(constring))
            {
                string sqlcmd = "SELECT seq FROM sqlite_sequence WHERE name = 'OrderNumber';";

                using (SQLiteCommand cmd = new SQLiteCommand(sqlcmd, con))
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
//TV7X81CH8AY4VSUDGTYZATHM
