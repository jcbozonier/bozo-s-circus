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
using BozosCircus.SmartStart;

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
            PreviewKeyDown += Window1_PreviewKeyDown;
            PreviewKeyUp += Window1_PreviewKeyUp;

            _Launcher = new SmartStart(
                new ActionMapper(
                    new[]
                        {
                            new Verb(
                                "select",
                                new[]
                                    {
                                        new Noun
                                            {
                                                Name = "table",
                                                Do = () => MessageBox.Show("select table")
                                            },
                                        new Noun
                                            {
                                                Name = "cells",
                                                Do = () => MessageBox.Show("select cells")
                                            }
                                    }
                                ),
                            new Verb(
                                "export",
                                new[]
                                    {
                                        new Noun()
                                            {
                                                Name = "table",
                                                Do = () => MessageBox.Show("export table")
                                            }
                                    }),
                        }
                    )
                );
        }

        void Window1_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            _PreviousKey = _CurrentKey;
            _CurrentKey = Key.None;
        }

        private SmartStart _Launcher;

        private Key _PreviousKey;
        private Key _CurrentKey;
        void Window1_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            _PreviousKey = _CurrentKey;
            _CurrentKey = e.Key;

            if ((_PreviousKey == Key.LeftCtrl && _CurrentKey == Key.Space) ||
                (_PreviousKey == Key.Space && _CurrentKey == Key.LeftCtrl))
            {
                _PreviousKey = Key.None;
                _CurrentKey = Key.None;
                
                _Launcher.Show();
                _Launcher.Focus();
            }
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
