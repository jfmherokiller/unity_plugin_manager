using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace GenericHelpersn
{
    public static class GenericHelpers
    {
        private static GameObject Fakelink;

        public static void CreateGameObjectAndAttachClass<T>() where T : MonoBehaviour
        {
            Fakelink = new GameObject();
            Fakelink.AddComponent<T>();
            GameObject.DontDestroyOnLoad(Fakelink);
        }

        public static void CreateGameObjectAndAttachClassAndAllowDestory<T>() where T : MonoBehaviour
        {
            Fakelink = new GameObject();
            Fakelink.AddComponent<T>();
        }
    }
}