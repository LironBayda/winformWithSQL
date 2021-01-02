using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ordersystemmengment
{
    public partial class orderMengmentSystem : Form
    {
        DataSet ds = new DataSet();
        //save user name for later use
        string userName = "";

        public orderMengmentSystem()
        {
            InitializeComponent();
            allLableAndTextBoxUnvisibleOnlyMenu();

        }

        private void menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            string menuOption =menu.Text;
            switch (menuOption)
            {
                // cases for the main menu
                case "new customer":
                    NewCustomer();
                    break;

                case "exsit customer":
                    createUserNameAndPassWordDisplay("customers");
                    break;

                case "new supplier":
                    NewSupplier();
                    break;
                case "exsit supplier":
                    createUserNameAndPassWordDisplay("suppliers") ;
                    break;
               //case for the supplier menu
                case "Add product":
                      createDisplayForProductName();

                    break;
                case "show my products":
                         showMyProduct();
                    break;
                //case for customer menu
                case "show my orders":
                    showMyOrders();

                    break;
                case "show products":
                    showProduct();
                    break;
                case "buy product":
                    buyProductGetName();
                    break;


            }
        }

        private void buyProductGetName()
        {
            // get customer details, before we change the text box value, for letar use
            getCustomerdetails();
            LableTextBoxvisibility(1);
            buyProductGetNameAddText();
            // get customer details for letar use
            buyProductGetNameAddClick( );
           
        }

        private void getCustomerdetails()
        {
            using (SqlConnection conn = new SqlConnection(@";Initial Catalog=winfromHW;Integrated Security=True"))
            {

                string query = $"select * from customers " +
                $" where user_name='{fristTextBox.Text}'; ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                da.Fill(ds, "Customer");
                
            }
        
        }

        private void buyProductGetNameAddClick()
        {
            Button send = GetButton();
            send.Click += (sender, e) => {
                using (SqlConnection conn = new SqlConnection(@";Initial Catalog=winfromHW;Integrated Security=True"))
                {

                    string query = $"select p.name, p.amount, p.price,p.product_number from products p" +
                    $" where p.name='{fristTextBox.Text}'; ";

                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    conn.Open();
                    da.Fill(ds, "newOrder");
                    if (ds.Tables["newOrder"].Rows.Count == 0)
                        MessageBox.Show("thare is not such a product!");
                    else
                        buyProductGetAmount();

                }
            };

            Controls.Add(send);
        }

        private void buyProductGetNameAddText()
        {
            explanation.Text = "enter tha name of the product you aont to buy";
            fristLabel.Text = "name";
        }

        private void buyProductGetAmount()
        {

            LableTextBoxvisibility(2);
            buyProductGetAmountAddText();
            buyProductGetAmountClick();


        }

        private void buyProductGetAmountClick()
        {
            Button send = GetButton();
            send.Click += (sender, e) => {
                if (Convert.ToInt32(ds.Tables["newOrder"].Rows[0]["amount"]) >= Convert.ToInt32(secondTextBox.Text))
                    addOrder();

                else
                    MessageBox.Show("the amount too big! please choose less from this product"+fristTextBox.Text);


            };

            Controls.Add(send);
        }

        private void addOrder()
        {

            // we have two query one to insert raw into orders and second to  update amount in products

            InsertRawIntoOrder();
            UpdateAmountInPrudacts();
            allLableAndTextBoxUnvisibleOnlyMenu();




        }

        private void InsertRawIntoOrder()
        {
            string queryForInsertRawIntoOrder = $"insert into orders " +
                $"(customer_number,product_number,total_price,order_amount) " +
               $"values ({Convert.ToInt32(ds.Tables["customer"].Rows[0]["customer_number"])}, " +
               $"{Convert.ToInt32(ds.Tables["newOrder"].Rows[0]["product_number"])}, " +
               $" {Convert.ToInt32(ds.Tables["newOrder"].Rows[0]["price"]) * Convert.ToInt32(secondTextBox.Text)}, " +
               $"{Convert.ToInt32(secondTextBox.Text)}) ";

            helpFunction.CreateCommandNonQuery(queryForInsertRawIntoOrder);

        }

        private void UpdateAmountInPrudacts()
        {
            string queryFOrUpdatePrudacts = $" update products set amount-= { Convert.ToInt32(secondTextBox.Text)} ";

            helpFunction.CreateCommandNonQuery(queryFOrUpdatePrudacts);
        }

        private void buyProductGetAmountAddText()
        {
            explanation.Text = "enter the amount you want to buy";
            secondLabel.Text = "amont";
        }

        private void showProduct()
        {
            allLableAndTextBoxUnvisibleOnlyMenu();
            using (SqlConnection conn = new SqlConnection(@";Initial Catalog=winfromHW;Integrated Security=True"))
            {

                string query = $"select p.name,p.amount,p.price" +
                    $" from products p";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                da.Fill(ds, "products");
                dataGridView.DataSource = ds.Tables["products"];
                dataGridView.Visible = true;



            }
        }

        private void showMyOrders()
        {
            allLableAndTextBoxUnvisibleOnlyMenu();

            using (SqlConnection conn = new SqlConnection(@";Initial Catalog=winfromHW;Integrated Security=True"))
            {

                string query = $"select p.name, p.price ,o.total_price, o.order_amount" +
                    $"    from orders o  join products p  " +
                    $" on o.product_number = p.product_number " +
                    $"join customers c on c.customer_number = o.customer_number " +
                    $"where user_name='{userName}'; ";
                string queryTotalPrice = "select sum(total_price) as 'sum orders price' from orders  ";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                da.Fill(ds, "myOrders");
                SqlDataAdapter daTotalPrice = new SqlDataAdapter(queryTotalPrice, conn);
                daTotalPrice.Fill(ds, "TotalPrice");
                dataGridView.DataSource = ds.Tables["myOrders"];
                dataGridView.Visible = true;
                totalPrice.Text = ds.Tables["TotalPrice"].ToString();
                totalPrice.Visible = true;



            }
        }


        private void createDisplayForProductName()
        {
            //get supllier data for later use (before we use the text box to get anthor value
            LableTextBoxvisibility(1);
            createDisplayForProductNameAddTextAndClick();
            

        }

        private void createDisplayForProductNameAddTextAndClick()
        {
            explanation.Text = "enter the name of the product";
            fristLabel.Text = "name";

            Button send = GetButton();
            send.Click += (sender, e) => { AddProduct(fristTextBox.Text); };
            Controls.Add(send);
            
        }

        private void NewSupplier()
        {
            LableTextBoxvisibility(3);
            NewSupplierAddText();
            NewSupplierAddClick();
        }

        private void NewSupplierAddClick()
        {
            Button send = GetButton();
            send.Click+= (sender, e) => {

               string cmd = $"insert into suppliers (user_name,password" +
                    $",company_name) values ('{fristTextBox.Text}','{secondTextBox.Text}'," +
                    $"'{thierdTextBox.Text}')";


               try
               {
                   helpFunction.CreateCommandNonQuery(cmd);
               }
               catch
               {
                   errorLabel.Text = "user nname arleady exsit. please choose anthor one";
                   return;

               }
               allLableAndTextBoxUnvisibleOnlyMenu();

           };

            Controls.Add(send);

        }

        private void NewSupplierAddText()
        {
            explanation.Text = "enter the following details";
            fristLabel.Text = "company name";
            secondLabel.Text = "user name";
            theirdLabel.Text = "password";
        }

        private void createSupplierDisplay()
        {
            explanation.Text = "choose one of the following options";
            menu.Items.Clear();
            menu.Items.Add("Add product");
            menu.Items.Add("show my products");
            allLableAndTextBoxUnvisibleOnlyMenu();

        }

        private void showMyProduct()
        {
  
            using (SqlConnection conn = new SqlConnection(@";Initial Catalog=winfromHW;Integrated Security=True"))
            {

                string query = $"select p.name,p.amount,p.price" +
                    $" from products p join suppliers s " +
                    $"on s.supplier_number=p.supplier_number where user_name='{userName}'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                da.Fill(ds, "products");
                dataGridView.DataSource = ds.Tables["products"];
                dataGridView.Visible = true;
            
            }
        }

        private void AddProduct(string productName)
        {
            using (SqlConnection conn = new SqlConnection(@";Initial Catalog=winfromHW;Integrated Security=True"))
            {

                string query = "select * from products p inner join  suppliers s " +
                $"on s.supplier_number=p.supplier_number where name='{productName}';  ";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                da.Fill(ds, productName);
                if (ds.Tables[productName].Rows.Count == 0)
                {

                    CreteAddProductDisplayNewProduct();
                }
                else if (ds.Tables[productName].Rows[0]["user_name"].ToString().StartsWith(userName))
                {
                   string supplierNumber = ds.Tables[productName].Rows[0]["supplier_number"].ToString();
                    createAddProductOnlyAmount(supplierNumber);

                }
                else
                {
                    MessageBox.Show("there is another supplier for" +
                        $" this product");

                }

            }
        }

        private void createAddProductOnlyAmount(string supplierNumber)
        {
            LableTextBoxvisibility(1);
            AddProdactOnlyAmountAddText();
            AddClickprudactOnlyAmount(supplierNumber);



       }

        private Button GetButton()
        {
            Button send = new Button();
            send.Location = new System.Drawing.Point(Width / 2 - send.Width / 2, Height - 4 * send.Height);
            //  sendButton1.Size = new System.Drawing.Size(75, 29);
            send.Text = "send";

            return send;


        }

        private void AddClickprudactOnlyAmount(string supplierNumber)
        {
            Button send = GetButton();
            send.Click += (sender, e) =>
            {

                string cmd = $"update products set amount=amount+{fristTextBox.Text} " +
                     $"where supplier_number={supplierNumber}";

                helpFunction.CreateCommandNonQuery(cmd);
           
                allLableAndTextBoxUnvisibleOnlyMenu();

            };

            Controls.Add(send);
           // sendButton.Visible = false;
        }

        private void AddProdactNewProductAddText()
        {
            explanation.Text = "please choose one of the following options";
            fristLabel.Text="name";
            secondLabel.Text = "price";
            theirdLabel.Text = "amount";



        }

        private void CreteAddProductDisplayNewProduct()
        {
            LableTextBoxvisibility(3);
            AddProdactNewProductAddText();
            createAddProductNewProduct();
        }

        private void createAddProductNewProduct()
        {
            Button send = GetButton();

            send.Click += (sender, e) =>
            {

                string cmd = $"insert into products (name,supplier_number" +
                   $",price,amount) values ('{fristTextBox.Text}','{getSupplier_number()}'" +
                   $",'{secondTextBox.Text}', '{thierdTextBox.Text}')";

                helpFunction.CreateCommandNonQuery(cmd);
                allLableAndTextBoxUnvisibleOnlyMenu();
            };

            Controls.Add(send);
        }

        private void AddProdactOnlyAmountAddText()
        {
            explanation.Text = "please enter the amount";
            fristLabel.Text = "amont";

        }

        private int getSupplier_number()
        {
            getSupplierData();
            return Convert.ToInt32(ds.Tables["suppliers"].Rows[0]["supplier_number"]);
            
        }

      private void  getSupplierData()
        {
            using (SqlConnection conn = new SqlConnection(@";Initial Catalog=winfromHW;Integrated Security=True"))
            {
                string query = "select * from  suppliers " +
                $"where user_name like '{userName}';  ";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                conn.Open();
                da.Fill(ds, "suppliers");
            }

        }

        private bool checkIfUserNameAndExsit(string customerOrSupplier)
        {

            string cmd = $"select * FROM " + customerOrSupplier + $" where user_name like '{fristTextBox.Text}'" +
                $" and password like '{secondTextBox.Text}' ";

            return helpFunction.IsSqlDataReaderNotEmpty(cmd);
        }
       
        
        private void createUserNameAndPassWordDisplay(string cusromersOrSuppliers)
        {
            LableTextBoxvisibility(2);
            createUserNameAndPassWordDisplayAddText();

            AddClickForUserNameAndPassword( cusromersOrSuppliers);
        }

        private void createUserNameAndPassWordDisplayAddText()
        {
            explanation.Text = "enter the use name and passward";
            fristLabel.Text = "user name";
            secondLabel.Text = "password";
        }

        private void AddClickForUserNameAndPassword(string  cusromersOrSuppliers)
        {
            Button send = GetButton();
            send.Click += (sender, e) =>
            {
                if (checkIfUserNameAndExsit(cusromersOrSuppliers))
                {
                    
                    userName = fristTextBox.Text;
                    if (cusromersOrSuppliers == "suppliers")
                        createSupplierDisplay();
                    else

                        createCustomerDisplay();

                }
                else
                {
                    errorLabel.Text = "user name ar passwotd incorrect";
                    errorLabel.Visible = true;
                }
            };

            Controls.Add(send);
        }

        private void createCustomerDisplay()
        {
            allLableAndTextBoxUnvisibleOnlyMenu();
            menu.Items.Clear();
            menu.Items.Add("show my orders");
            menu.Items.Add("show products");
            menu.Items.Add("buy product");
            menu.Visible = true;
        }

        private void NewCustomer()
        {
           
            LableTextBoxvisibility(4);
            AddTextToLabelNewCustomer();
            AddOnClickToSendButtonNewCustomer();
            

        }

        private void AddOnClickToSendButtonNewCustomer()
        {
            Button send = GetButton();
            send.Click += (sender, e) =>

              {

                  string cmd = $"insert into customers(user_name,password" +
                     $",name, last_name) values ('{fristTextBox.Text}','{secondTextBox.Text}'," +
                     $"'{thierdTextBox.Text}','{fourthtextBox.Text}')";


                  try
                  {
                      helpFunction.CreateCommandNonQuery(cmd);
                  }
                  catch
                  {
                      errorLabel.Text = "error: user name exist. please choose difrrent user name";
                      errorLabel.Visible=true;
                      return;
                  }

                  allLableAndTextBoxUnvisibleOnlyMenu();


              };

            Controls.Add(send);
            }
            
        
    

        private void AddTextToLabelNewCustomer()
        {
            explanation.Text = "Enter the Follwing details";
            fristLabel.Text = " user name";
            secondLabel.Text = "password";
            theirdLabel.Text = "frist name";
            fourthLabel.Text = "last name";

        }

        private void LableTextBoxvisibility(int num)
        {
            allLableAndTextBoxUnvisibleOnlyMenu();
            menu.Visible = false;

            if (num >= 1)
            {
                fristLabel.Visible = true;
                fristTextBox.Visible = true;
            }
            if (num >= 2)
            {
                secondLabel.Visible = true;
                secondTextBox.Visible = true;
            }
            if(num>=3)
                {
                theirdLabel.Visible = true;
                thierdTextBox.Visible = true;
            }
            if (num == 4)
            {
                fourthLabel.Visible = true;
                fourthtextBox.Visible = true;
            }

        //    sendButton.Visible = true;
        }

        private void allLableAndTextBoxUnvisibleOnlyMenu()
        {
            errorLabel.Visible = false;
            fristLabel.Visible = false;
            secondLabel.Visible = false;
            theirdLabel.Visible = false;
            fourthLabel.Visible = false;
            totalPrice.Visible = false;

            fourthtextBox.Visible = false;
            thierdTextBox.Visible = false;
            secondTextBox.Visible = false;
            fristTextBox.Visible = false;

            sendButton.Visible = false;
            dataGridView.Visible = false;
            menu.Visible = true;

            //check if we add button to the controls/ we have 13 item if we add it it sould be at 14
           if(Controls.Count>14)
                Controls.RemoveAt(14);
            menu.Text = "please choose one of the following options";

        }

    
    }
}
