using HX0KAT_HFT_2021222.Models;
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
using System.Windows.Shapes;

namespace HX0KAT_HFT_2021222.WPFClient.Views
{
    /// <summary>
    /// Interaction logic for RepairerEditorView.xaml
    /// </summary>
    public partial class RepairerEditorView : Window
    {
        public Repairer CurrentRepairer{ get; set; }
        public RepairerEditorView(Repairer repairer)
        {
            InitializeComponent();
            this.DataContext = repairer;
            CurrentRepairer = repairer;
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
            CurrentRepairer = (Repairer)this.DataContext;
            DialogResult = true;
        }
    }
}
