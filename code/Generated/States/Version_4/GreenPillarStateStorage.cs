// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class GreenPillarStateStorage
    {
        private static Dictionary<GameObject, GreenPillarStateEnum> stateTable = new();

        public static event Action<GameObject, GreenPillarStateEnum> OnStateChanged;

        public static void Register(GameObject obj, GreenPillarStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static GreenPillarStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsReady(GameObject obj) => stateTable[obj] == GreenPillarStateEnum.Ready;

        public static void SetReady(GameObject obj) => SetState(obj, GreenPillarStateEnum.Ready);

        private static void SetState(GameObject obj, GreenPillarStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
