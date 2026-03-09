// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class OKButtonInitializer : MonoBehaviour
    {
        public OKButtonStateEnum initialState = OKButtonStateEnum.Ready;

        void Awake()
        {
            OKButtonStateStorage.Register(gameObject, initialState);
        }
    }
}
