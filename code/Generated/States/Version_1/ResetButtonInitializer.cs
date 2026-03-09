// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class ResetButtonInitializer : MonoBehaviour
    {
        public ResetButtonStateEnum initialState = ResetButtonStateEnum.Ready;

        void Awake()
        {
            ResetButtonStateStorage.Register(gameObject, initialState);
        }
    }
}
