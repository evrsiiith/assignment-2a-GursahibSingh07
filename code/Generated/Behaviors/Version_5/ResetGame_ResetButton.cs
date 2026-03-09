// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_5
{
    public class ResetGame_ResetButton : MonoBehaviour
    {
        void Update()
        {
            if (UserAlgorithms.IsResetClicked())
            {
                UserAlgorithms.ResetAll();
            }
        }
    }
}
