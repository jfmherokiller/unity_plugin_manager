using System.IO;
using UnityEngine;

namespace MainLoader
{
    public class hookies
    {
        public void allhooks()
        {
            var pluginloaddirectory = Path.GetFullPath(Path.Combine(Application.dataPath, "Managed"));
            PluginLoader.InitializePlugins(pluginloaddirectory);
        }
    }
}