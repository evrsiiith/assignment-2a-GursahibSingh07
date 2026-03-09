// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class BluePillarStateStorage
    {
        private static Dictionary<GameObject, BluePillarStateEnum> stateTable = new();

        public static event Action<GameObject, BluePillarStateEnum> OnStateChanged;

        public static void Register(GameObject obj, BluePillarStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static BluePillarStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == BluePillarStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, BluePillarStateEnum.Ready);

        private static void SetState(GameObject obj, BluePillarStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
