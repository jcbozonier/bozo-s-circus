using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BozosCircus.MessageBoxDeluxe
{
    public class MessageBoxChoice
    {
        private KeyValuePair<string, Action<int>> _ChoicePair;

        public string Key { get { return _ChoicePair.Key; } }
        public Action<int> Value { get { return _ChoicePair.Value; } }

        public MessageBoxChoice(string choiceText, Action<int> choiceCommand)
        {
            _ChoicePair = new KeyValuePair<string, Action<int>>(choiceText, choiceCommand);
        }
    }
}