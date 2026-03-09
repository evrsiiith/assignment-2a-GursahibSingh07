// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class ColorButtonPress_BlueButton : MonoBehaviour
    {
        void Update()
        {
            if ((BlueButtonStateStorage.Get(GameObject.Find("BlueButton")) == BlueButtonStateEnum.Idle && RiddleBoardStateStorage.Get(GameObject.Find("RiddleBoard")) == RiddleBoardStateEnum.Hidden && TreasureChestStateStorage.Get(GameObject.Find("TreasureChest")) == TreasureChestStateEnum.Locked && UserAlgorithms.IsButtonClicked(GameObject.Find("BlueButton"))))
            {
                UserAlgorithms.PressButton(GameObject.Find("BlueButton"));
            }
        }
    }
}
