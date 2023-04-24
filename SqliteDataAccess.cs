using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp4
{
    public class SqliteDataAccess
    {
        public static List<Customers> LoadCustomers()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                string c = "Customers";
                var output = cnn.Query<Customers>("SELECT * FROM "+c, new DynamicParameters());
                //cnn.Dispose();
                cnn.Close();
                return output.ToList();
            }
            
        }

        public static List<Product> LoadProducts()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string c = "Products";
                var output = cnn.Query<Product>("SELECT * FROM " + c, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<DeliveryType> LoadTypes()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string c = "DeliveryType";
                var output = cnn.Query<DeliveryType>("SELECT * FROM " + c, new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<Order> LoadOrders()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                string c = "Orders";
                var output = cnn.Query<Order>("SELECT * FROM " + c, new DynamicParameters());
                return output.ToList();
            }
        }


        public static List<Table> LoadTableName()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Open();
                var output = cnn.Query<Table>("SELECT name FROM sqlite_schema WHERE type ='table' AND name NOT LIKE 'sqlite_%';", new DynamicParameters());
                //cnn.Dispose();
                cnn.Close();
                return output.ToList();
            }
        }

        public static void SaveCustomer(Customers c)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Customers (CustomerID, CustomerName, Address, TotalOrders) values (@CustomerID, @CustomerName, @Address, @TotalOrders)", c);
            }

        }

        public static void SaveProduct(Product p)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Products (ProductID, ProductName, Manufacturer, Price) values (@ProductID, @ProductName, @Manufacturer, @Price)", p);
            }
        }

        public static void SaveType(DeliveryType t)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into DeliveryType (TypeID, title, DaysToDeliver, AdditionalCost) values (@TypeID, @title, @DaysToDeliver, @AdditionalCost)", t);
            }
        }

        public static void SaveOrder(Order o)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into Orders (OrderID, TotalCost, ProductID, CustomerID, TypeID) values (@OrderID, @TotalCost, @ProductID, @CustomerID, @TypeID)", o);
            }
        }

        public static void UpdateCustomer(string ID, Customers c)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                
                cnn.Execute("UPDATE Customers SET CustomerName = @CustomerName, Address = @Address, TotalOrders = @TotalOrders WHERE CustomerID = "+ID, c);
                
            }
        }

        public static void UpdateDelivery(string ID, DeliveryType t)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                
                cnn.Execute("UPDATE DeliveryType SET title = @title, DaysToDeliver = @DaysToDeliver, AdditionalCost = @AdditionalCost WHERE TypeID = " + ID, t);

            }
        }

        public static void UpdateProduct(string ID, Product p)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                
                cnn.Execute("UPDATE Products SET ProductName = @ProductName, Manufacturer = @Manufacturer, Price = @Price WHERE ProductID = " + ID, p);

            }
        }

        public static void UpdateOrder(string ID, Order o)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {

                cnn.Execute("UPDATE Orders SET TotalCost = @TotalCost, ProductID = @ProductID, CustomerID = @CustomerID, TypeID = @TypeID WHERE OrderID = " + ID, o);

            }
        }

        public static List<JoinObjectOne> PremadeJoin()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<JoinObjectOne>("SELECT Customers.Address, OrderID FROM Customers INNER JOIN Orders ON Customers.CustomerID = Orders.CustomerID WHERE OrderID = 1 OR OrderID = 2 OR OrderID = 3;", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<SubQueryObject> SubQuery()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<SubQueryObject>("SELECT TotalCost, AdditionalCost, Price From ( SELECT TotalCost, Price, TypeID FROM Orders INNER JOIN Products ON Orders.ProductID = Products.ProductID) AS r1 INNER JOIN DeliveryType ON r1.TypeID = DeliveryType.TypeID WHERE DeliveryType.title = 'Dragon'", new DynamicParameters());
                return output.ToList();
            }
        }

        public static List<JoinObjectTwo> PreMadeJoinDos()
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<JoinObjectTwo>("SELECT Products.ProductName, Products.Price, Orders.OrderID, Orders.TotalCost FROM Products INNER JOIN Orders ON Products.ProductID = Orders.ProductID where price > 2700", new DynamicParameters());
                return output.ToList();
            }
        }

        public static void DeleteItem(string ID, string table)
        {
            string IDField="";
            switch(table)
            {
                case "Customers":
                    IDField = "CustomerID";
                    break;
                case "DeliveryType":
                    IDField = "TypeID";
                    break;
                case "Products":
                    IDField = "ProductID";
                    break;
                case "Orders":
                    IDField = "OrderID";
                    break;

            }
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                MessageBox.Show("DELETE FROM " + table + "WHERE " + IDField + " = " + ID);
                cnn.Execute("DELETE FROM "+table + " WHERE " + IDField + " = " +ID);

            }
        }


        private static string LoadConnectionString(string id="Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
//Demodb