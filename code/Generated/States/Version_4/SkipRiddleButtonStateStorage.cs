// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class SkipRiddleButtonStateStorage
    {
        private static Dictionary<GameObject, SkipRiddleButtonStateEnum> stateTable = new();

        public static event Action<GameObject, SkipRiddleButtonStateEnum> OnStateChanged;

        public static void Register(GameObject obj, SkipRiddleButtonStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static SkipRiddleButtonStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == SkipRiddleButtonStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, SkipRiddleButtonStateEnum.Ready);

        private static void SetState(GameObject obj, SkipRiddleButtonStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
