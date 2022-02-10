#region Using Statements
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#endregion

namespace Robot
{
    public class UIManager : MonoBehaviour
    {
        public GameObject mainPanel;
        public bool activatePanel = false;

        public Image loadingbar;
        public bool loadgame = false;
        public float speed;

        private void Awake()
        {
            mainPanel.SetActive(true);
        }


        void Update()
        {
            EscapeFeature();
            if (loadgame)
                LoadingBar();
        }


        public void NewGame()
        {
            mainPanel.SetActive(false);
            loadgame = true;
            SceneManager.LoadScene("Game");
        }

        public void EscapeFeature()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                activatePanel = !activatePanel;
                mainPanel.SetActive(activatePanel);
            }
        }

        public void LoadingBar()
        {
            loadingbar.fillAmount -= (Time.deltaTime * speed);
        }

        public void ResumeGame()
        {

        }
    }

}