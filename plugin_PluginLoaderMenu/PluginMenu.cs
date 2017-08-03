using System.Collections.Generic;
using System.IO;
using PluginContract;
using UnityEngine;
using static plugin_PluginLoaderMenu.PluginMenuLoader;

namespace plugin_PluginLoaderMenu
{
    public class PluginMenu : MonoBehaviour
    {
        private bool showmenu;

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.F1)) showmenu = !showmenu;
        }

        void OnGUI()
        {
            if (showmenu)
            {
                GUILayout.BeginArea(new Rect(140, Screen.height - 50, Screen.width - 300, 120));
                GUILayout.BeginVertical();
                GUILayout.Label("Plugin Loader Menu");
                foreach (var plugin in GetPluginList(Path.GetFullPath(Path.Combine(Application.dataPath, "Managed"))))
                {
                    if (GUILayout.Button(plugin.Name))
                    {
                        plugin.initPlugin();
                    }
                }
                GUILayout.EndArea();
            }
        }
    }
}