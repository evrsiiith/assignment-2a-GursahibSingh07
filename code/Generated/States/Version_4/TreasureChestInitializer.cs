// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class TreasureChestInitializer : MonoBehaviour
    {
        public TreasureChestStateEnum initialState = TreasureChestStateEnum.Locked;

        void Awake()
        {
            TreasureChestStateStorage.Register(gameObject, initialState);
        }
    }
}
