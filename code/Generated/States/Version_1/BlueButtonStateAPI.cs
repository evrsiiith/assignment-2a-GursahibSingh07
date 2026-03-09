// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public static class BlueButtonStateAPI
    {
        public static bool Idle(GameObject obj) => BlueButtonStateStorage.IsIdle(obj);
        public static bool Pressed(GameObject obj) => BlueButtonStateStorage.IsPressed(obj);

        public static void SetIdle(GameObject obj) => BlueButtonStateStorage.SetIdle(obj);
        public static void SetPressed(GameObject obj) => BlueButtonStateStorage.SetPressed(obj);
    }
}
