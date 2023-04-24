
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customers> Customers = new List<Customers>();
        List<Table> Tables = new List<Table>();
        List<Product> Products = new List<Product>();
        List<DeliveryType> Types = new List<DeliveryType>();
        List<Order> Orders = new List<Order>();
        List<JoinObjectOne> UnoJoin = new List<JoinObjectOne>();
        List<SubQueryObject> subs = new List<SubQueryObject>();
        List<JoinObjectTwo> DosJoin = new List<JoinObjectTwo>();
       // List<DisplayID> IDs = new List<DisplayID>();
        
        
        public MainWindow()
        {
            InitializeComponent();
            Tables = SqliteDataAccess.LoadTableName();
            SelectTable.ItemsSource = Tables;
            Load();
        }
    
        private void Load()
        {
            Display.Items.Clear();
            if (SelectTable.SelectedValue.ToString() == "Customers")
            {
                Customers = SqliteDataAccess.LoadCustomers();
                

                var gridview = new GridView();
                Display.View = gridview;

                Binding test = new Binding();
                test.ElementName = "Display";
                test.Path = new PropertyPath("SelectedItem.CustomerID");
                firstp.SetBinding(TextBox.TextProperty, test);

                gridview.Columns.Add(new GridViewColumn { Header = "ID", DisplayMemberBinding = new Binding("CustomerID") });
                gridview.Columns.Add(new GridViewColumn { Header = "Name", DisplayMemberBinding = new Binding("CustomerName") });
                gridview.Columns.Add(new GridViewColumn { Header = "Address", DisplayMemberBinding = new Binding("Address") });
                gridview.Columns.Add(new GridViewColumn { Header = "Total Orders", DisplayMemberBinding = new Binding("TotalOrders") });



                foreach (Customers c in Customers)
                {
                    Display.Items.Add(c);
                }
  
            }
            else if (SelectTable.SelectedValue.ToString() == "DeliveryType")
            {
                var gridview = new GridView();
                Display.View = gridview;

                Binding test = new Binding();
                test.ElementName = "Display";
                test.Path = new PropertyPath("SelectedItem.TypeID");
                firstp.SetBinding(TextBox.TextProperty, test);

                gridview.Columns.Add(new GridViewColumn { Header = "ID", DisplayMemberBinding = new Binding("TypeID") });
                gridview.Columns.Add(new GridViewColumn { Header = "title", DisplayMemberBinding = new Binding("title") });
                gridview.Columns.Add(new GridViewColumn { Header = "DaysToDeliver", DisplayMemberBinding = new Binding("DaysToDeliver") });
                gridview.Columns.Add(new GridViewColumn { Header = "AdditionalCost", DisplayMemberBinding = new Binding("AdditionalCost") });


                Types = SqliteDataAccess.LoadTypes();

                foreach (DeliveryType t in Types)
                {
                    Display.Items.Add(t);
                }
            }
            else if (SelectTable.SelectedValue.ToString() == "Orders")
            {
                var gridview = new GridView();
                Display.View = gridview;

                Binding test = new Binding();
                test.ElementName = "Display";
                test.Path = new PropertyPath("SelectedItem.OrderID");
                firstp.SetBinding(TextBox.TextProperty, test);

                gridview.Columns.Add(new GridViewColumn { Header = "Order ID", DisplayMemberBinding = new Binding("OrderID") });
                gridview.Columns.Add(new GridViewColumn { Header = "Total Cost", DisplayMemberBinding = new Binding("TotalCost") });
                gridview.Columns.Add(new GridViewColumn { Header = "Product ID", DisplayMemberBinding = new Binding("ProductID") });
                gridview.Columns.Add(new GridViewColumn { Header = "Customer ID", DisplayMemberBinding = new Binding("CustomerID") });
                gridview.Columns.Add(new GridViewColumn { Header = "Type ID", DisplayMemberBinding = new Binding("TypeID") });

                Orders = SqliteDataAccess.LoadOrders();

                foreach (Order o in Orders)
                {
                    Display.Items.Add(o);
                }
            }

            else if (SelectTable.SelectedValue.ToString() == "Products")
            {
                var gridview = new GridView();
                Display.View = gridview;

                Binding test = new Binding();
                test.ElementName = "Display";
                test.Path = new PropertyPath("SelectedItem.ProductID");
                firstp.SetBinding(TextBox.TextProperty, test);

                gridview.Columns.Add(new GridViewColumn { Header = "ID", DisplayMemberBinding = new Binding("ProductID") });
                gridview.Columns.Add(new GridViewColumn { Header = "ProductName", DisplayMemberBinding = new Binding("ProductName") });
                gridview.Columns.Add(new GridViewColumn { Header = "Manufacturer", DisplayMemberBinding = new Binding("Manufacturer") });
                gridview.Columns.Add(new GridViewColumn { Header = "Price", DisplayMemberBinding = new Binding("Price") });

                Products = SqliteDataAccess.LoadProducts();

                foreach (Product p in Products)
                {
                    Display.Items.Add(p);
                }
            }
        }

        private void Save_New_Object(object sender, RoutedEventArgs e)
        {
            //string test = SelectTable.SelectedValue.ToString();
           
            if(SelectTable.SelectedValue.ToString() == "Customers")
            {
                Customers c = new Customers();
                int x = Convert.ToInt32(firstp.Text);
                int y = Convert.ToInt32(fourthp.Text);
                c.CustomerID = x;
                c.CustomerName = secondp.Text;
                c.Address = thirdp.Text;
                c.TotalOrders = y;

                SqliteDataAccess.SaveCustomer(c);

                firstp.Text = "";
                secondp.Text = "";
                thirdp.Text = "";
                fourthp.Text = "";
                fifthp.Text = "";
            }
            else if(SelectTable.SelectedValue.ToString() == "DeliveryType")
            {
                DeliveryType t = new DeliveryType();
                int x = Convert.ToInt32(firstp.Text);
                int y = Convert.ToInt32(thirdp.Text);
                int z = Convert.ToInt32(fourthp.Text);
                t.TypeID = x;
                t.title = secondp.Text;
                t.DaysToDeliver = y;
                t.AdditionalCost = z;

                SqliteDataAccess.SaveType(t);

                firstp.Text = "";
                secondp.Text = "";
                thirdp.Text = "";
                fourthp.Text = "";
                fifthp.Text = "";
            }
            else if (SelectTable.SelectedValue.ToString() == "Orders")
            {
                Order o = new Order();
                int a = Convert.ToInt32(firstp.Text);
                int b = Convert.ToInt32(secondp.Text);
                int c = Convert.ToInt32(thirdp.Text);
                int d = Convert.ToInt32(fourthp.Text);
                int z = Convert.ToInt32(fifthp.Text);

                o.OrderID = a;
                o.TotalCost = b;
                o.ProductID = c;
                o.CustomerID = d;
                o.TypeID = z;

                SqliteDataAccess.SaveOrder(o);

                firstp.Text = "";
                secondp.Text = "";
                thirdp.Text = "";
                fourthp.Text = "";
                fifthp.Text = "";
            }
            else if (SelectTable.SelectedValue.ToString() == "Products")
            {
                Product p = new Product();
                int x = Convert.ToInt32(firstp.Text);
                int y = Convert.ToInt32(fourthp.Text);

                p.ProductID = x;
                p.ProductName = secondp.Text;
                p.Manufacturer = thirdp.Text;
                p.Price = y;

                SqliteDataAccess.SaveProduct(p);

                firstp.Text = "";
                secondp.Text = "";
                thirdp.Text = "";
                fourthp.Text = "";
                fifthp.Text = "";
            }

           
        }
        private void Update_Object(object sender, RoutedEventArgs e)
        {
            //string test = SelectTable.SelectedValue.ToString();
            

            if (SelectTable.SelectedValue.ToString() == "Customers")
            {
                Customers c = new Customers();
                int y = Convert.ToInt32(fourthp.Text);
                c.CustomerName = secondp.Text;
                c.Address = thirdp.Text;
                c.TotalOrders = y;
                
                SqliteDataAccess.UpdateCustomer(firstp.Text, c);

                firstp.Text = "";
                secondp.Text = "";
                thirdp.Text = "";
                fourthp.Text = "";
                fifthp.Text = "";
            }
            else if (SelectTable.SelectedValue.ToString() == "DeliveryType")
            {
                DeliveryType t = new DeliveryType();
                int y = Convert.ToInt32(thirdp.Text);
                int z = Convert.ToInt32(fourthp.Text);
                t.title = secondp.Text;
                t.DaysToDeliver = y;
                t.AdditionalCost = z;

                SqliteDataAccess.UpdateDelivery(firstp.Text, t);

                firstp.Text = "";
                secondp.Text = "";
                thirdp.Text = "";
                fourthp.Text = "";
                fifthp.Text = "";
            }
            else if (SelectTable.SelectedValue.ToString() == "Orders")
            {
                Order o = new Order();
                int b = Convert.ToInt32(secondp.Text);
                int c = Convert.ToInt32(thirdp.Text);
                int d = Convert.ToInt32(fourthp.Text);
                int z = Convert.ToInt32(fifthp.Text);

                o.TotalCost = b;
                o.ProductID = c;
                o.CustomerID = d;
                o.TypeID = z;

                SqliteDataAccess.UpdateOrder(firstp.Text, o);

                firstp.Text = "";
                secondp.Text = "";
                thirdp.Text = "";
                fourthp.Text = "";
                fifthp.Text = "";
            }
            else if (SelectTable.SelectedValue.ToString() == "Products")
            {
                Product p = new Product();
                int y = Convert.ToInt32(fourthp.Text);

                p.ProductName = secondp.Text;
                p.Manufacturer = thirdp.Text;
                p.Price = y;

                SqliteDataAccess.UpdateProduct(firstp.Text, p);

                firstp.Text = "";
                secondp.Text = "";
                thirdp.Text = "";
                fourthp.Text = "";
                fifthp.Text = "";
            }

           
        }

        private void Load_DataBase(object sender, RoutedEventArgs e)
        {
            Load();
        }

        private void Delete_object(object sender, RoutedEventArgs e)
        {
            SqliteDataAccess.DeleteItem(firstp.Text, SelectTable.SelectedValue.ToString());
        }

        private void PreMadeJoinOne(object sender, RoutedEventArgs e)
        {
            Display.Items.Clear();
            var gridview = new GridView();
            Display.View = gridview;

            

            gridview.Columns.Add(new GridViewColumn { Header = "Address", DisplayMemberBinding = new Binding("Address") });
            gridview.Columns.Add(new GridViewColumn { Header = "OrderID", DisplayMemberBinding = new Binding("OrderID") });

            UnoJoin = SqliteDataAccess.PremadeJoin();

            foreach (JoinObjectOne j in UnoJoin)
            {
                Display.Items.Add(j);
            }
        }

        private void PreMadeSub(object sender, RoutedEventArgs e)
        {
            Display.Items.Clear();
            var gridview = new GridView();
            Display.View = gridview;

            

            gridview.Columns.Add(new GridViewColumn { Header = "TotalCost", DisplayMemberBinding = new Binding("TotalCost") });
            gridview.Columns.Add(new GridViewColumn { Header = "AdditionalCost", DisplayMemberBinding = new Binding("AdditionalCost") });
            gridview.Columns.Add(new GridViewColumn { Header = "Price", DisplayMemberBinding = new Binding("Price") });

            subs = SqliteDataAccess.SubQuery();

            foreach (SubQueryObject s in subs)
            {
                Display.Items.Add(s);
            }
        }

        private void PreMadeJoinTwo(object sender, RoutedEventArgs e)
        {
            Display.Items.Clear();
            var gridview = new GridView();
            Display.View = gridview;



            gridview.Columns.Add(new GridViewColumn { Header = "ProductName", DisplayMemberBinding = new Binding("ProductName") });
            gridview.Columns.Add(new GridViewColumn { Header = "Price", DisplayMemberBinding = new Binding("Price") });
            gridview.Columns.Add(new GridViewColumn { Header = "OrderID", DisplayMemberBinding = new Binding("OrderID") });
            gridview.Columns.Add(new GridViewColumn { Header = "TotalCost", DisplayMemberBinding = new Binding("TotalCost") });

            DosJoin = SqliteDataAccess.PreMadeJoinDos();

            foreach (JoinObjectTwo j in DosJoin)
            {
                Display.Items.Add(j);
            }
        }
    }
}
