using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ques
{
    class PluginDescription : Attribute
    {
        public string Description { get; }
        public PluginDescription(string Description)
        {
        }
    }

    class PluginAttribute : Attribute
    {
        public string Attribute { get; }
        public string Profile { get; }
        public string Module { get; }
        public int BranchNumber { get; }

        public PluginAttribute(string attribute, string profile, string module, int branchNumber)
        {
            Attribute = attribute;
            Profile = profile;
            Module = module;
            BranchNumber = branchNumber;
        }
    }
}
