// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class GreenPillarInitializer : MonoBehaviour
    {
        public GreenPillarStateEnum initialState = GreenPillarStateEnum.Ready;

        void Awake()
        {
            GreenPillarStateStorage.Register(gameObject, initialState);
        }
    }
}
