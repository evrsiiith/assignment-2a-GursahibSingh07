// GENERATED FILE — DO NOT EDIT
using UnityEngine;
using System;
using System.Collections.Generic;

namespace Version_5
{
    public static class RiddleBoardStateStorage
    {
        private static Dictionary<GameObject, RiddleBoardStateEnum> stateTable = new();

        public static event Action<GameObject, RiddleBoardStateEnum> OnStateChanged;

        public static void Register(GameObject obj, RiddleBoardStateEnum initialState)
        {
            if (!stateTable.ContainsKey(obj))
                stateTable.Add(obj, initialState);
        }

        public static RiddleBoardStateEnum Get(GameObject obj) => stateTable[obj];

        public static bool IsShowing(GameObject obj) => stateTable[obj] == RiddleBoardStateEnum.Showing;
        public static bool IsHidden(GameObject obj) => stateTable[obj] == RiddleBoardStateEnum.Hidden;

        public static void SetShowing(GameObject obj) => SetState(obj, RiddleBoardStateEnum.Showing);
        public static void SetHidden(GameObject obj) => SetState(obj, RiddleBoardStateEnum.Hidden);

        private static void SetState(GameObject obj, RiddleBoardStateEnum newState)
        {
            if (stateTable[obj] != newState)
            {
                stateTable[obj] = newState;
                OnStateChanged?.Invoke(obj, newState);
            }
        }
    }
}
