using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        public void PlayButtonClick()
        {
            GameManager.Instance.LoadScene(1);
        }
        public void ExitButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
    }
}
