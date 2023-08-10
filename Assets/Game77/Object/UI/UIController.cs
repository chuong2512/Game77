using System.Collections;
using System.Collections.Generic;
using Assets.Game77.Dinosaur;
using Assets.Game77.Object;
using Game58;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : Singleton<UIController>
{
    [SerializeField] private Button back;
    [SerializeField] private Button pause;
    [SerializeField] private Button healthBut;
    [SerializeField] private Button continueBut;
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private GameObject lose;
    [SerializeField] private GameObject pauseObj;

    private Dino dino;

    private void Start()
    {
        dino = GameObject.FindWithTag("Dino").GetComponent<Dino>();
        back?.onClick.AddListener(BackHome);
        pause?.onClick.AddListener(Stop);
        healthBut?.onClick.AddListener(AddHealth);
        continueBut?.onClick.AddListener(Continue);
        GameDataManager.Instance.playerData.onChangeDiamond = i => SetHealthText(i);
    }

    public void Stop()
    {
        if (GameManager.Instance.IsPause)
        {
            GameManager.Instance.IsPause = false;
            Time.timeScale = 1f;
            return;
        }
        GameManager.Instance.IsPause = true;
        Time.timeScale = 0f;
    }
    
    public void Pause()
    {
        pause.gameObject.SetActive(false);
        back.gameObject.SetActive(false);
        GameManager.Instance.IsPause = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        if (!GameManager.Instance.DinoAlive)
        {
            lose.SetActive(true);
            return;
        }
        pause.gameObject.SetActive(true);
        back.gameObject.SetActive(true);
        GameManager.Instance.IsPause = false;
        Time.timeScale = 1f;
    }
    
    public void BackHome()
    {
        SceneManager.LoadScene("DinoMenu");
    }

    public void ShowLose()
    {
        Pause();
        lose.SetActive(true);
    }
    
    public void Restart()
    {
        Resume();
        SceneManager.LoadScene("Dino");
    }

    private void Continue()
    {
        if (!GameManager.Instance.Revival()) return;
        lose.SetActive(false);
        Resume();
    }

    private void AddHealth()
    {
        Pause();
        lose.SetActive(false);
    }
    
    private void SetHealthText(int health)
    {
        healthText.text = $"{health}";
    }
    
    
}
