// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class BluePillarInitializer : MonoBehaviour
    {
        public BluePillarStateEnum initialState = BluePillarStateEnum.Ready;

        void Awake()
        {
            BluePillarStateStorage.Register(gameObject, initialState);
        }
    }
}
