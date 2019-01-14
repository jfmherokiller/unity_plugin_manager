using MyGame;
using MyGame.InputStatus;
using UnityEngine;

namespace plgm_katamari_cheats
{
    public class CheatMenu : MonoBehaviour
    {
        private bool showmenu;

        private GlobalWork gWork;
        //private GlobalManager gMan;
        //private InputController input;

        void Update()
        {
            if (Input.GetKeyUp(KeyCode.F2)) showmenu = !showmenu;
        }

        void OnGUI()
        {
            if (!showmenu) return;
            GUILayout.BeginArea(new Rect(140, Screen.height - 50, Screen.width - 300, 120));
            GUILayout.BeginVertical();
            GUILayout.Label("Cheat Menu");

                if (GUILayout.Button("AddTime30Min"))
                {
                    gWork.s32RemainTime += 54000;
                }
                if (GUILayout.Button("AddTimeLess"))
                {
                    gWork.s32RemainTime += 5400;
                }
                if (GUILayout.Button("KatamariPlus"))
                {
                    SimulationNativeMethods.AddKatamariRadius(0, 1f);
                }
                if (GUILayout.Button("KatamariPlus10"))
                {
                    SimulationNativeMethods.AddKatamariRadius(0, 10f);
                }
                if (GUILayout.Button("MaxStarDust"))
                {
                    gWork.siGame.u16StarDustCount = GlobalManager.MAX_STAR_DUST;
                }

            GUILayout.EndArea();
        }
        private void Awake()
        {
            gWork = SingletonMonoBehaviour<GlobalWork>.Instance;
            //gMan = SingletonMonoBehaviour<GlobalManager>.Instance;
            //input = SingletonMonoBehaviour<InputController>.Instance;
        }
    }
}