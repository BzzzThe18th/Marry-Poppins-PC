﻿using System;
using System.Collections.Generic;
using HarmonyLib;

namespace MarryPoppins.Patches
{

    [HarmonyPatch(typeof(UmbrellaItem))]
    [HarmonyPatch("OnActivate", MethodType.Normal)]
    class OnActivatePatch
    {
        public static void Postfix(UmbrellaItem __instance)
        {
            if(__instance.myState == 1) Plugin.umbrellaOpened = true;
            if (__instance.myState == 0) Plugin.umbrellaOpened = false;
        }
    }
}
