// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public static class RiddleBoardStateAPI
    {
        public static bool Showing(GameObject obj) => RiddleBoardStateStorage.IsShowing(obj);
        public static bool Hidden(GameObject obj) => RiddleBoardStateStorage.IsHidden(obj);

        public static void SetShowing(GameObject obj) => RiddleBoardStateStorage.SetShowing(obj);
        public static void SetHidden(GameObject obj) => RiddleBoardStateStorage.SetHidden(obj);
    }
}
