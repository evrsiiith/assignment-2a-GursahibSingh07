// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_5
{
    public class RedPillarInitializer : MonoBehaviour
    {
        public RedPillarStateEnum initialState = RedPillarStateEnum.Ready;

        void Awake()
        {
            RedPillarStateStorage.Register(gameObject, initialState);
        }
    }
}
