using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunSetcanRun.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        bool IsClick = false;
        [SerializeField] GameObject H2PPanel;
        public void PlayButtonClick()
        {
            if (!IsClick)
            {
                GameManager.Instance.LoadScene(1);
                IsClick = true;
            }
        }
        public void ExitButtonClick()
        {
            GameManager.Instance.ExitGame();
        }
        public void H2PButtonClick()
        {
            if (H2PPanel.activeInHierarchy)
            {
                H2PPanel.SetActive(false);
            }
            else
            {
                H2PPanel.SetActive(true);

            }
        }
    }
}
