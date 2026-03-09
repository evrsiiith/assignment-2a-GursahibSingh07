// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class TreasureChestStateStorage
    {
        private static Dictionary<GameObject, TreasureChestStateEnum> stateTable = new();

        public static event Action<GameObject, TreasureChestStateEnum> OnStateChanged;

        public static void Register(GameObject obj, TreasureChestStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static TreasureChestStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsLocked(GameObject obj) => stateTable[obj] == TreasureChestStateEnum.Locked;
        public static bool IsOpen(GameObject obj) => stateTable[obj] == TreasureChestStateEnum.Open;

        public static void SetLocked(GameObject obj) => SetState(obj, TreasureChestStateEnum.Locked);
        public static void SetOpen(GameObject obj) => SetState(obj, TreasureChestStateEnum.Open);

        private static void SetState(GameObject obj, TreasureChestStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
