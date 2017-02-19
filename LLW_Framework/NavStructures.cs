using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LLW_Framework
{
    public struct Journals
    {
        public string journalName;
        public List<JournalMenu> menu;
    }

    public struct JournalMenu
    {
        public string menuHeader;
        public string menuItem;
    }
}
