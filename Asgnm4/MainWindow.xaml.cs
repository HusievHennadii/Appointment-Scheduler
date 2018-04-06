using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Asgnm4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Customer MyCustomer { get; set; }
        public MainWindow() 
        {
            InitializeComponent();
        }
        Appointments WorkDay = new Appointments();
        int clientNumber = 0;
        bool display = false;
        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            lblEmpty.Content = "";
            //ValidationClear();
            if (txtAge.Text == ""||txtName.Text==""||txtSize.Text==""||txtPaddockSize.Text=="")
                lblEmpty.Content = "All fields must be filled";
            else if ((!Validation.GetHasError(txtAge)) && (!Validation.GetHasError(txtName)) && (!Validation.GetHasError(txtSize)))
            {
                WorkDay.AddClientWPF(clientNumber, cboHouseType.SelectedIndex, txtName.Text, TimeRecognition(),
                    UInt32.Parse(txtAge.Text), Double.Parse(txtSize.Text), Double.Parse(txtPaddockSize.Text));
                Clear();
                /*WorkDay.WriteIntoXML(clientNumber);
                rbTime.IsChecked = true;
                WorkDay.ReadXMLFile();*/
                gridSchedule.ItemsSource = null;
                gridSchedule.AutoGenerateColumns = false;
                gridSchedule.ItemsSource = WorkDay.clientsList;
                clientNumber++;
                cboHouseType.SelectedIndex = 0;
                cboTime.SelectedIndex = 0;

            }
        }
        private int TimeRecognition()
        {
            string cboTimeOutput = cboTime.SelectedValue.ToString();
            char[] timeArr = cboTimeOutput.ToCharArray();
            string strTime="";
            bool alreadyWasDigit = false;
            foreach (char h in timeArr)
            {
                if (char.IsDigit(h) == true)
                {
                    strTime += h;
                    alreadyWasDigit = true;
                }
                else if(alreadyWasDigit)
                {
                    break;
                }

            }
            int time = Int32.Parse(strTime);
            cboTime.Items.RemoveAt(cboTime.Items.IndexOf(cboTime.SelectedItem));
            cboTime.SelectedIndex = -1;
            return time;
        }
        /*private bool FormValidation()
        {
            bool everythingCorrect = true;
            if (cboHouseType.SelectedIndex < 0)
            {
                lblErrorType.Content = "You must select house type";
                everythingCorrect = false;
            }
            if(txtName.Text=="")
            {
                lblErrorName.Content = "You must insert client name";
                everythingCorrect = false;
            }
            if(cboTime.SelectedIndex<0)
            {
                lblErrorTime.Content = "You must select appointment time";
                everythingCorrect = false;
            }
            if (txtAge.Text == "")
            {
                lblErrorAge.Content = "You must insert house age";
                everythingCorrect = false;
            }
            else if(!UInt32.TryParse(txtAge.Text, out uint temp))
            {
                //lblErrorAge.Content = "Only integers starting from 0 are aloud";
                txtAge.Foreground = new SolidColorBrush(Colors.Red);
                everythingCorrect = false;
            }
            if(txtSize.Text=="")
            {
                lblErrorSize.Content = "You must insert house size";
                everythingCorrect = false;
            }
            else if(!(double.TryParse(txtSize.Text, out double temp)&&temp>0))
            {
                lblErrorSize.Content = "Only digits higher then 0 are aloud";
                txtSize.Foreground = new SolidColorBrush(Colors.Red);
                everythingCorrect = false;
            }
            if(txtPaddockSize.Text=="")
            {
                txtPaddockSize.Text = "0";
            }
            else if(!(double.TryParse(txtPaddockSize.Text, out double temp) && temp >= 0))
            {
                lblErrorPaddockSize.Content = "Only digits starting from 0 are aloud";
                txtPaddockSize.Foreground = new SolidColorBrush(Colors.Red);
                everythingCorrect = false;
            }
            return everythingCorrect;
        }*/
        private void Clear()
        {
            cboHouseType.SelectedIndex = -1;
            txtName.Text = "";
            txtAge.Text = "";
            txtSize.Text = "";
            txtPaddockSize.Text = "";
        }
        private void ValidationClear()
        {
            lblErrorAge.Content = "";
            lblErrorType.Content = "";
            lblErrorTime.Content = "";
            lblErrorName.Content = "";
            lblErrorSize.Content = "";
            lblErrorPaddockSize.Content = "";
            
            txtSize.Foreground = new SolidColorBrush(Colors.Black);
            txtPaddockSize.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void txtAge_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtAge.Foreground = new SolidColorBrush(Colors.Black);
            lblErrorAge.Content="";
        }

        private void txtPaddockSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtPaddockSize.Foreground = new SolidColorBrush(Colors.Black);
        }

        private void txtSize_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtSize.Foreground = new SolidColorBrush(Colors.Black);
        }
        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            display = true;
            //WorkDay.clientsList.Items
            /*WorkDay.WriteIntoBinaryFile(clientNumber);
            tboOutput.Text=WorkDay.ReadBinaryFile(clientNumber);*/
            rbTime.IsChecked = true;
            clientNumber = WorkDay.ReadXMLFile();
            gridSchedule.ItemsSource = null;
            gridSchedule.AutoGenerateColumns = false;
            gridSchedule.ItemsSource = WorkDay.clientsList;
        }

        private void rbName_Checked(object sender, RoutedEventArgs e)
        {
            var query = from customer in WorkDay.clientsList
                        orderby customer.Name
                        select customer;
            gridSchedule.ItemsSource = null;
            gridSchedule.ItemsSource = query;
        }

        private void rbTime_Checked(object sender, RoutedEventArgs e)
        {
            var query = from customer in WorkDay.clientsList
                        orderby customer.Time
                        select customer;
            gridSchedule.ItemsSource = null;
            gridSchedule.ItemsSource = query;
        }

        private void rbType_Checked(object sender, RoutedEventArgs e)
        {
            var query = from customer in WorkDay.clientsList
                        orderby customer.GetType().ToString()
                        select customer;
            gridSchedule.ItemsSource = null;
            gridSchedule.ItemsSource = query;
        }

        private void rbAge_Checked(object sender, RoutedEventArgs e)
        {
            var query = from customer in WorkDay.clientsList
                        orderby customer.Age
                        select customer;
            gridSchedule.ItemsSource = null;
            gridSchedule.ItemsSource = query;
        }

        private void rbSize_Checked(object sender, RoutedEventArgs e)
        {
            var query = from customer in WorkDay.clientsList
                        orderby customer.Size
                        select customer;
            gridSchedule.ItemsSource = null;
            gridSchedule.AutoGenerateColumns = false;
            gridSchedule.ItemsSource = query;
        }

        private void rbPaddockSize_Checked(object sender, RoutedEventArgs e)
        {
            var query = from customer in WorkDay.clientsList
                        orderby customer.PaddockSize
                        select customer;
            gridSchedule.ItemsSource = null;
            gridSchedule.AutoGenerateColumns = false;
            gridSchedule.ItemsSource = query;
        }

        private void btnWriteIntoXML_Click(object sender, RoutedEventArgs e)
        {
            WorkDay.WriteIntoXML(clientNumber);
            
        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            gridSchedule.ItemsSource = null;
            gridSchedule.AutoGenerateColumns = false;
            gridSchedule.ItemsSource = WorkDay.clientsList;
            if (cboHouseType_Filter.SelectedIndex == 0)
            {
                var query = from customer in WorkDay.clientsList
                            select customer;
                gridSchedule.ItemsSource = null;
                gridSchedule.AutoGenerateColumns = false;
                gridSchedule.ItemsSource = query;
            }
            else if(cboHouseType_Filter.SelectedIndex == 1)
            {
                var query = from customer in WorkDay.clientsList
                            where customer.GetType() == typeof(House)
                            select customer;
                gridSchedule.ItemsSource = null;
                gridSchedule.AutoGenerateColumns = false;
                gridSchedule.ItemsSource = query;
            }
            else if (cboHouseType_Filter.SelectedIndex == 2)
            {
                var query = from customer in WorkDay.clientsList
                            where customer.GetType() == typeof(Farmer)
                            select customer;
                gridSchedule.ItemsSource = null;
                gridSchedule.AutoGenerateColumns = false;
                gridSchedule.ItemsSource = query;
            }
            else if (cboHouseType_Filter.SelectedIndex == 3)
            {
                var query = from customer in WorkDay.clientsList
                            where customer.GetType() == typeof(Business)
                            select customer;
                gridSchedule.ItemsSource = null;
                gridSchedule.AutoGenerateColumns = false;
                gridSchedule.ItemsSource = query;
            }
        }

        private void cboHouseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MyCustomer = new Farmer();
            formGrid.DataContext = MyCustomer;
        }

        private void gridSchedule_SelectionChanged()
        {

        }
    }
}
