// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_1
{
    public static class OKButtonStateStorage
    {
        private static Dictionary<GameObject, OKButtonStateEnum> stateTable = new();

        public static event Action<GameObject, OKButtonStateEnum> OnStateChanged;

        public static void Register(GameObject obj, OKButtonStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static OKButtonStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == OKButtonStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, OKButtonStateEnum.Ready);

        private static void SetState(GameObject obj, OKButtonStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
