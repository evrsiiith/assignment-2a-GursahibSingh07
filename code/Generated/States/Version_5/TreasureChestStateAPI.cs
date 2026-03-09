// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_5
{
    public static class TreasureChestStateAPI
    {
        public static bool Locked(GameObject obj) => TreasureChestStateStorage.IsLocked(obj);
        public static bool Open(GameObject obj) => TreasureChestStateStorage.IsOpen(obj);

        public static void SetLocked(GameObject obj) => TreasureChestStateStorage.SetLocked(obj);
        public static void SetOpen(GameObject obj) => TreasureChestStateStorage.SetOpen(obj);
    }
}
