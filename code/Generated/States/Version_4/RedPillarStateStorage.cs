// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class RedPillarStateStorage
    {
        private static Dictionary<GameObject, RedPillarStateEnum> stateTable = new();

        public static event Action<GameObject, RedPillarStateEnum> OnStateChanged;

        public static void Register(GameObject obj, RedPillarStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static RedPillarStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == RedPillarStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, RedPillarStateEnum.Ready);

        private static void SetState(GameObject obj, RedPillarStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
