// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class ClickChest_TreasureChest : MonoBehaviour
    {
        void Update()
        {
            if ((TreasureChestStateStorage.Get(GameObject.Find("TreasureChest")) == TreasureChestStateEnum.Locked && UserAlgorithms.IsChestClicked()))
            {
                UserAlgorithms.UnlockChest();
            }
        }
    }
}
