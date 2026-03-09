// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_5
{
    public static class ResetButtonStateStorage
    {
        private static Dictionary<GameObject, ResetButtonStateEnum> stateTable = new();

        public static event Action<GameObject, ResetButtonStateEnum> OnStateChanged;

        public static void Register(GameObject obj, ResetButtonStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static ResetButtonStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == ResetButtonStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, ResetButtonStateEnum.Ready);

        private static void SetState(GameObject obj, ResetButtonStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
