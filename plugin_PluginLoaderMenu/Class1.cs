
using GenericHelpersn;
using PluginContract;

namespace plugin_PluginLoaderMenu
{
    public class PluginLoaderMenu: IPlugin
    {
        public string Name => "PluginLoaderMenu";
        public void initPlugin()
        {
           GenericHelpers.CreateGameObjectAndAttachClass<PluginMenu>();
        }
    }
}
