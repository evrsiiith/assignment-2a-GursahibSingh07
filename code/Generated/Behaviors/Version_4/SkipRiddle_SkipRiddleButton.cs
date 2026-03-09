// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class SkipRiddle_SkipRiddleButton : MonoBehaviour
    {
        void Update()
        {
            if (UserAlgorithms.IsSkipRiddleClicked())
            {
                UserAlgorithms.SkipRiddle();
            }
        }
    }
}
