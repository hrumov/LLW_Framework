using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    public struct Journals
    {
        public string jName; //journalName;
        public List<JournalMenu> jMenu; // journalMenu;
    }

    public struct JournalMenu // journalMenu
    {
        public string menuHeader;
        public string menuItem;
    }
}