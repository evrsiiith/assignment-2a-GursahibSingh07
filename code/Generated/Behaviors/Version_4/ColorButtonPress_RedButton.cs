// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class ColorButtonPress_RedButton : MonoBehaviour
    {
        void Update()
        {
            if ((RedButtonStateStorage.Get(GameObject.Find("RedButton")) == RedButtonStateEnum.Idle && RiddleBoardStateStorage.Get(GameObject.Find("RiddleBoard")) == RiddleBoardStateEnum.Hidden && TreasureChestStateStorage.Get(GameObject.Find("TreasureChest")) == TreasureChestStateEnum.Locked && UserAlgorithms.IsButtonClicked(GameObject.Find("RedButton"))))
            {
                UserAlgorithms.PressButton(GameObject.Find("RedButton"));
            }
        }
    }
}
