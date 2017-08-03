using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PluginContract;

namespace MainLoader
{
    public static class PluginLoader
    {
        public static IEnumerable<IPlugin> GetPluginList(string path)
        {
            //make sure the files are sorted in alphabetical order so that some kind of load order can be imposed
            var pluginFiles = Directory.GetFiles(path, "plugin_*.dll").OrderBy(f => f);

            var pluginlist = (
                // From each file in the files.
                from file in pluginFiles
                // Load the assembly.
                let asm = Assembly.LoadFile(file)
                // For every type in the assembly that is visible outside of
                // the assembly.
                from type in asm.GetExportedTypes()
                // Where the type implements the interface.
                where typeof(IPlugin).IsAssignableFrom(type)
                // Create the instance.
                select (IPlugin) Activator.CreateInstance(type)
                // Materialize to an array.
            );
            return pluginlist;
        }

        public static void InitializePlugins(string path)
        {
            var pluginlist = GetPluginList(path);
            pluginlist.ToList().ForEach(plugin => plugin.initPlugin());
        }
    }
}