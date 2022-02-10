using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI codeText;


    void Start()
    {
    }

    void Update()
    {
        
    }

    public void Teleport()
    {
        string codeT = codeText.ToString();

        string[] codeArr = codeT.Split(char.Parse("_"));

        string let = codeArr[3];
        Debug.Log(let);

        for (int i = 0; i < codeArr.Length; i++)
        {
            Debug.Log(codeArr[i]);
        }
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Game");
    }
}
