// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
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
