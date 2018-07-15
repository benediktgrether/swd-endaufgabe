using System;
using System.Collections.Generic;

namespace swd_endaufgabe
{
    class Items
    {
        public string InteractionName;
        public string Description;
        public string Title;
        public bool Used;
        public bool Bomb;

        public Items(string _interactionName, string _title, string _description, bool _used, bool _bomb)
        {
            InteractionName = _interactionName;
            Title = _title;
            Description = _description;
            Used = _used;
            Bomb = _bomb;
        }
    }
}


