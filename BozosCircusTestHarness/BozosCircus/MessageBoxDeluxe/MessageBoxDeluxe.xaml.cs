using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace BozosCircus.MessageBoxDeluxe
{
    /// <summary>
    /// Interaction logic for ButterMessageBox.xaml
    /// </summary>
    public partial class MessageBoxDeluxe : Window
    {
        public MessageBoxDeluxe()
        {
            InitializeComponent();
        }

        public void ShowCustomMessageBox(
            IEnumerable<MessageBoxChoice> buttonDefinitions, 
            string message, 
            string caption)
        {
            List<ButtonCommand> buttonCommands = _CreateButtonCommands(buttonDefinitions);
            var window = this;
            var model = new ButterMessageViewModel
                            {
                                MessageText = message,
                                MessageCaption = caption,
                                ButtonCommands = buttonCommands
                            };
            window.DataContext = model;
            window.ShowDialog();
        }

        /// <summary>
        /// Converts the button choice definitions provided into ButtonCommand objects that
        /// the dialog can bind directly to.
        /// </summary>
        /// <param name="buttonDefinitions"></param>
        /// <returns></returns>
        private List<ButtonCommand> _CreateButtonCommands(IEnumerable<MessageBoxChoice> buttonDefinitions)
        {
            var buttonCommands = new List<ButtonCommand>();
            var counter = 0;

            foreach (var definition in buttonDefinitions)
            {
                buttonCommands.Add(new ButtonCommand()
                                       {
                                           ButtonCommandObject = new LambdaCommand<int>(definition.Value, x => true),
                                           ButtonText = definition.Key,
                                           ButtonID = counter
                                       });
                counter++;
            }
            return buttonCommands;
        }

        internal class ButterMessageViewModel
        {
            public string MessageCaption
            { get; set; }
            public string MessageText
            { get; set; }
            public List<ButtonCommand> ButtonCommands
            { get; set; }
        }

        internal class ButtonCommand
        {
            public ICommand ButtonCommandObject
            { get; set; }
            public string ButtonText
            { get; set; }
            public int ButtonID
            { get; set; }
        }
    }
}