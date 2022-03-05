using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RunSetcanRun.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void YesButtonClick()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void NoButtonClick()
        {
            GameManager.Instance.LoadMenuAndUi(2f);
        }
    }
}
