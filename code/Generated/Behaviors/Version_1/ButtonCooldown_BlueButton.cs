// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class ButtonCooldown_BlueButton : MonoBehaviour
    {
        void Update()
        {
            if ((BlueButtonStateStorage.Get(GameObject.Find("BlueButton")) == BlueButtonStateEnum.Pressed && UserAlgorithms.IsCooldownDone(GameObject.Find("BlueButton"))))
            {
                UserAlgorithms.ResetButtonVisual(GameObject.Find("BlueButton"));
            }
        }
    }
}
