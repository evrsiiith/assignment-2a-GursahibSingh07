// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_1
{
    public class DismissRiddle_RiddleBoard : MonoBehaviour
    {
        void Update()
        {
            if ((RiddleBoardStateStorage.Get(GameObject.Find("RiddleBoard")) == RiddleBoardStateEnum.Showing && UserAlgorithms.IsOKClicked()))
            {
                UserAlgorithms.DismissRiddle();
            }
        }
    }
}
