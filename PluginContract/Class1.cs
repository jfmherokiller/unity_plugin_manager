using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PluginContract
{
    public interface IPlugin
    {
        string Name { get; }
        void initPlugin();
    }
}