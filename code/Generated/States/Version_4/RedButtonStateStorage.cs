// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_4
{
    public static class RedButtonStateStorage
    {
        private static Dictionary<GameObject, RedButtonStateEnum> stateTable = new();

        public static event Action<GameObject, RedButtonStateEnum> OnStateChanged;

        public static void Register(GameObject obj, RedButtonStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static RedButtonStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsIdle(GameObject obj) => stateTable[obj] == RedButtonStateEnum.Idle;
        public static bool IsPressed(GameObject obj) => stateTable[obj] == RedButtonStateEnum.Pressed;

        public static void SetIdle(GameObject obj) => SetState(obj, RedButtonStateEnum.Idle);
        public static void SetPressed(GameObject obj) => SetState(obj, RedButtonStateEnum.Pressed);

        private static void SetState(GameObject obj, RedButtonStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
