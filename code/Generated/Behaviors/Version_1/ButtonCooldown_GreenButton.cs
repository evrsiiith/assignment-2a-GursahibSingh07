// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class ButtonCooldown_GreenButton : MonoBehaviour
    {
        void Update()
        {
            if ((GreenButtonStateStorage.Get(GameObject.Find("GreenButton")) == GreenButtonStateEnum.Pressed && UserAlgorithms.IsCooldownDone(GameObject.Find("GreenButton"))))
            {
                UserAlgorithms.ResetButtonVisual(GameObject.Find("GreenButton"));
            }
        }
    }
}
