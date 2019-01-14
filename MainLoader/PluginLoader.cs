using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using PluginContract;

namespace MainLoader
{
    public static class PluginLoader
    {
        private static IEnumerable<IPlugin> GetPluginList(string path)
        {
            List<IPlugin> coolme;
            coolme = new List<IPlugin>();
            var files = Directory.GetFiles(path, "plugin_*.dll");
            foreach (var file in files)
            {
                foreach (var fx in Assembly.LoadFile(file).GetExportedTypes())
                {
                    if (typeof(IPlugin).IsAssignableFrom(fx))
                    {
                        coolme.Add((IPlugin) Activator.CreateInstance(fx));
                    }
                }
            }

            return coolme;
        }

    public static void InitializePlugins(string path)
    {
    var pluginlist = GetPluginList(path);
        foreach (var plugin in pluginlist)
        {
            plugin.initPlugin();
        }
    }
}

}