// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class ButtonCooldown_RedButton : MonoBehaviour
    {
        void Update()
        {
            if ((RedButtonStateStorage.Get(GameObject.Find("RedButton")) == RedButtonStateEnum.Pressed && UserAlgorithms.IsCooldownDone(GameObject.Find("RedButton"))))
            {
                UserAlgorithms.ResetButtonVisual(GameObject.Find("RedButton"));
            }
        }
    }
}
