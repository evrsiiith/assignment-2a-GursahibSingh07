// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_1
{
    public static class BlueButtonStateStorage
    {
        private static Dictionary<GameObject, BlueButtonStateEnum> stateTable = new();

        public static event Action<GameObject, BlueButtonStateEnum> OnStateChanged;

        public static void Register(GameObject obj, BlueButtonStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static BlueButtonStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsIdle(GameObject obj) => stateTable[obj] == BlueButtonStateEnum.Idle;
        public static bool IsPressed(GameObject obj) => stateTable[obj] == BlueButtonStateEnum.Pressed;

        public static void SetIdle(GameObject obj) => SetState(obj, BlueButtonStateEnum.Idle);
        public static void SetPressed(GameObject obj) => SetState(obj, BlueButtonStateEnum.Pressed);

        private static void SetState(GameObject obj, BlueButtonStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
