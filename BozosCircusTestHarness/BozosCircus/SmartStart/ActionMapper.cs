using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BozosCircus.SmartStart
{
    public class ActionMapper
    {
        private List<Verb> _Verbs;
        public ActionMapper(IEnumerable<Verb> verbs)
        {
            _Verbs = new List<Verb>(verbs);
        }

        public IEnumerable<Verb> SearchNounsFor(string name)
        {
            if (_Verbs != null)
                return _Verbs.FindAll(verb => verb.Name.ToLowerInvariant().Contains(name));
            return new List<Verb>();
        }
    }

    public class Verb
    {
        public string Name;

        public Verb(string name, IEnumerable<Noun> nouns)
        {
            Name = name;
            _Nouns = new List<Noun>(nouns);
        }

        private List<Noun> _Nouns;
        public IEnumerable<Noun> SearchVerbsFor(string name)
        {
            if (_Nouns != null)
                return _Nouns.FindAll(noun => noun.Name.ToLowerInvariant().Contains(name));
            return new List<Noun>();
        }
    }

    public class Noun
    {
        public string Name;
        public Action Do;
    }
}
