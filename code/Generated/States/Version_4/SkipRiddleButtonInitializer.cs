// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SkipRiddleButtonInitializer : MonoBehaviour
    {
        public SkipRiddleButtonStateEnum initialState = SkipRiddleButtonStateEnum.Ready;

        void Awake()
        {
            SkipRiddleButtonStateStorage.Register(gameObject, initialState);
        }
    }
}
