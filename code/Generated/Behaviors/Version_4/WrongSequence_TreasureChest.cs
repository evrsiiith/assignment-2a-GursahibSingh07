// GENERATED FILE — DO NOT EDIT
using UnityEngine;

namespace Version_4
{
    public class WrongSequence_TreasureChest : MonoBehaviour
    {
        void Update()
        {
            if ((TreasureChestStateStorage.Get(GameObject.Find("TreasureChest")) == TreasureChestStateEnum.Locked && RiddleBoardStateStorage.Get(GameObject.Find("RiddleBoard")) == RiddleBoardStateEnum.Hidden && UserAlgorithms.IsSequenceWrong()))
            {
                UserAlgorithms.HandleWrongSequence();
            }
        }
    }
}
