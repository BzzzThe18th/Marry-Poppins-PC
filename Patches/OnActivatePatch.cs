using System;
using System.Collections.Generic;
using GorillaNetworking;
using HarmonyLib;

namespace MarryPoppins.Patches
{
    [HarmonyPatch(typeof(UmbrellaItem))]
    [HarmonyPatch("OnActivate", MethodType.Normal)]
    class UmbrellaActivatePatch
    {
        public static void Postfix(UmbrellaItem __instance)
        {
            if (__instance.myOnlineRig == null && __instance.myRig == GorillaTagger.Instance.offlineVRRig)
                if (__instance.itemState == TransferrableObject.ItemStates.State0) Plugin.umbrellaOpened = true; else Plugin.umbrellaOpened = false;
        }
    }

    [HarmonyPatch(typeof(CosmeticsController))]
    [HarmonyPatch("PressWardrobeItemButton", MethodType.Normal)]
    internal class WardrobeButtonPressPatch
    {
        internal static void Prefix(CosmeticsController __instance, CosmeticsController.CosmeticItem cosmeticItem)
        {
            var items = CosmeticsController.instance.currentWornSet.items;
            for (int i = 0; i < items.Length; i++)
                if (items[i].itemCategory == CosmeticsController.CosmeticCategory.Holdable && items[i].displayName.Contains("UMBRELLA")) Plugin.umbrellaOpened = false;
        }
    }

    [HarmonyPatch(typeof(CosmeticsController))]
    [HarmonyPatch("PressFittingRoomButton", MethodType.Normal)]
    internal class FittingRoomButtonPressPatch
    {
        internal static void Prefix(CosmeticsController __instance, FittingRoomButton pressedFittingRoomButton, bool isLeftHand)
        {
            var items = CosmeticsController.instance.tryOnSet.items;
            for (int i = 0; i < items.Length; i++)
                if (items[i].itemCategory == CosmeticsController.CosmeticCategory.Holdable && items[i].displayName.Contains("UMBRELLA")) Plugin.umbrellaOpened = false;
        }
        internal static void Postfix(CosmeticsController __instance, FittingRoomButton pressedFittingRoomButton, bool isLeftHand)
        {
            var items = CosmeticsController.instance.tryOnSet.items;
            for (int i = 0; i < items.Length; i++)
                if (items[i].itemCategory == CosmeticsController.CosmeticCategory.Holdable && items[i].displayName.Contains("UMBRELLA")) Plugin.umbrellaOpened = false;
        }
    }

    [HarmonyPatch(typeof(CosmeticBoundaryTrigger))]
    [HarmonyPatch("OnTriggerExit", MethodType.Normal)]
    internal class BoundaryExitPatch
    {
        internal static void Prefix(CosmeticBoundaryTrigger __instance, UnityEngine.Collider other)
        {
            var items = CosmeticsController.instance.tryOnSet.items;
            for (int i = 0; i < items.Length; i++)
                if (items[i].itemCategory == CosmeticsController.CosmeticCategory.Holdable && items[i].displayName.Contains("UMBRELLA")) Plugin.umbrellaOpened = false;
        }
    }
}