using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Uis
{
    public class GameFinishPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            GameManager.Instance.LoadMenuAndUi(2f);
            this.gameObject.SetActive(false);
        }

        public void NoButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
