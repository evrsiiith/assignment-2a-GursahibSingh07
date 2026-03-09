// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class BlueButtonInitializer : MonoBehaviour
    {
        public BlueButtonStateEnum initialState = BlueButtonStateEnum.Idle;

        void Awake()
        {
            BlueButtonStateStorage.Register(gameObject, initialState);
        }
    }
}
