using HX0KAT_HFT_2021222.Models;
using System.Windows;
using System.Windows.Controls;

namespace HX0KAT_HFT_2021222.WPFClient.Views
{
    /// <summary>
    /// Interaction logic for CustomerEditorView.xaml
    /// </summary>
    public partial class CustomerEditorView : Window
    {
        public Customer CurrentCustomer { get; set; }
        public CustomerEditorView(Customer customer)
        {
            InitializeComponent();
            this.DataContext = customer;
            CurrentCustomer = customer;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in stackpanel.Children)
            {
                if (item is TextBox t)
                {
                    t.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }                
            }
            CurrentCustomer = (Customer)this.DataContext;
            DialogResult = true;
        }
    }
}
