using GenericHelpersn;
using PluginContract;

namespace plgm_katamari_cheats
{
    public class PluginLoaderMenu: IPlugin
    {
        public string Name => "Katamari Cheats";
        public void initPlugin()
        {
           GenericHelpers.CreateGameObjectAndAttachClass<CheatMenu>();
        }
    }
}
