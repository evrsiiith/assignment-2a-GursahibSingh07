// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_5
{
    public class RedButtonInitializer : MonoBehaviour
    {
        public RedButtonStateEnum initialState = RedButtonStateEnum.Idle;

        void Awake()
        {
            RedButtonStateStorage.Register(gameObject, initialState);
        }
    }
}
