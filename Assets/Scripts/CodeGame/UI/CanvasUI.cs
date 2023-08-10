using System.Collections;
using System.Collections.Generic;
using Game58;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasUI : Singleton<CanvasUI>
{

    public Button start, exit;

    // Start is called before the first frame update
    void Start()
    {
        start?.onClick.AddListener(OpenGame);
        exit?.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public GameObject Sub;
    public void OpenGame()
    {
        if (GameDataManager.Instance.playerData.time > 0)
        {
            SceneManager.LoadScene("Dino");
        }
        else
        {
            //Sub.SetActive(true);
        }
    }
    
    
}