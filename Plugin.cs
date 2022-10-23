using BepInEx;
using System;
using System.ComponentModel;
using UnityEngine;
using Utilla;

namespace MarryPoppins
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    [Description("HauntedModMenu")]
    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        public static bool umbrellaOpened;

        private void resetGravity() => Physics.gravity = new Vector3(0f, -9.81f, 0f);

        void OnEnable() => HarmonyPatches.ApplyHarmonyPatches();

        void OnDisable()
        {
            HarmonyPatches.RemoveHarmonyPatches();
            resetGravity();
        }

        void FixedUpdate()
        {
            if (inRoom)
            {
                if (umbrellaOpened) Physics.gravity = new Vector3(0f, -3.0f, 0f);
                else if (!umbrellaOpened) resetGravity();
            }
            else if (!inRoom) resetGravity();
        }

        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            inRoom = true;
            resetGravity();
        }

        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            inRoom = false;
            resetGravity();
        }
    }
}
