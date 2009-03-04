using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BozosCircus.MessageBoxDeluxe;

namespace BozosCircusTestHarness
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            new MessageBoxDeluxe().ShowCustomMessageBox(
                new[]
                    {
                        new MessageBoxChoice("Save and Continue", x => MessageBox.Show("You chose to save!")),
                        new MessageBoxChoice("Don't Save and Continue", x => MessageBox.Show("You chose to not save!")),
                        new MessageBoxChoice("Cancel", x => MessageBox.Show("You chose cancel!"))
                    },
                "What do you want to do now?",
                "Your caption here...");
        }
    }
}
