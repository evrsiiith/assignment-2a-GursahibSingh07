// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class RedButtonStateAPI
    {
        public static bool Idle(GameObject obj) => RedButtonStateStorage.IsIdle(obj);
        public static bool Pressed(GameObject obj) => RedButtonStateStorage.IsPressed(obj);

        public static void SetIdle(GameObject obj) => RedButtonStateStorage.SetIdle(obj);
        public static void SetPressed(GameObject obj) => RedButtonStateStorage.SetPressed(obj);
    }
}
