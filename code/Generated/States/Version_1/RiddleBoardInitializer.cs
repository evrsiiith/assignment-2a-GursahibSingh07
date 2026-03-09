// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class RiddleBoardInitializer : MonoBehaviour
    {
        public RiddleBoardStateEnum initialState = RiddleBoardStateEnum.Showing;

        void Awake()
        {
            RiddleBoardStateStorage.Register(gameObject, initialState);
        }
    }
}
