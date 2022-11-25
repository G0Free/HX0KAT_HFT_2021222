using HX0KAT_HFT_2021222.Models;
using System.Windows;
using System.Windows.Controls;

namespace HX0KAT_HFT_2021222.WPFClient.Views
{
    /// <summary>
    /// Interaction logic for PhoneEditorView.xaml
    /// </summary>
    public partial class PhoneEditorView : Window
    {
        public Phone CurrentPhone { get; set; }
        public PhoneEditorView(Phone phone)
        {
            InitializeComponent();
            this.DataContext = phone;
            CurrentPhone = phone;
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
            CurrentPhone = (Phone)this.DataContext;
            DialogResult = true;
        }
    }
}
