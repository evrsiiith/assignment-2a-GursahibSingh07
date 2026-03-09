// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class GreenButtonInitializer : MonoBehaviour
    {
        public GreenButtonStateEnum initialState = GreenButtonStateEnum.Idle;

        void Awake()
        {
            GreenButtonStateStorage.Register(gameObject, initialState);
        }
    }
}
