// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class ColorButtonPress_GreenButton : MonoBehaviour
    {
        void Update()
        {
            if ((GreenButtonStateStorage.Get(GameObject.Find("GreenButton")) == GreenButtonStateEnum.Idle && RiddleBoardStateStorage.Get(GameObject.Find("RiddleBoard")) == RiddleBoardStateEnum.Hidden && TreasureChestStateStorage.Get(GameObject.Find("TreasureChest")) == TreasureChestStateEnum.Locked && UserAlgorithms.IsButtonClicked(GameObject.Find("GreenButton"))))
            {
                UserAlgorithms.PressButton(GameObject.Find("GreenButton"));
            }
        }
    }
}
