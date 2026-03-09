// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public static class GreenButtonStateAPI
    {
        public static bool Idle(GameObject obj) => GreenButtonStateStorage.IsIdle(obj);
        public static bool Pressed(GameObject obj) => GreenButtonStateStorage.IsPressed(obj);

        public static void SetIdle(GameObject obj) => GreenButtonStateStorage.SetIdle(obj);
        public static void SetPressed(GameObject obj) => GreenButtonStateStorage.SetPressed(obj);
    }
}
