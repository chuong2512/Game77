using System.Collections;
using Game58;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum State
{
    Drawing,
    Stop,
    Pause
}

public class TheGameUI : Singleton<TheGameUI>
{
    public GameObject lose, win;

    public State currentState = State.Drawing;


    public TextMeshProUGUI levelTMP;

    public Image tut;

    // Start is called before the first frame update
    public void OpenStart()
    {
        SetState(State.Drawing);

        levelTMP.SetText($"LEVEL {GameDataManager.Instance.playerData.level}");
        tut.sprite = Level.Instance.imageTut;
    }


    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var mouseRay = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero,
                float.PositiveInfinity);

            if (mouseRay.collider != null && mouseRay.collider.gameObject.CompareTag("Car"))
            {
                if (checkCar())
                {
                    mouseRay.collider.gameObject.GetComponent<car>().Go();
                }
            }
        }
    }

    private bool checkCar()
    {
        return Level.Instance.Check();
    }

    public void ShowLose()
    {
        StopAllCoroutines();
        SetState(State.Pause);
        lose.SetActive(true);
    }

    public void ShowWin()
    {
        StopAllCoroutines();
        SetState(State.Pause);
        win.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void NextGame()
    {
        if (GameDataManager.Instance.playerData.SubDiamond(1))
        {
            NextGameWin();
        }
    }

    public void NextGameWin()
    {
        GameDataManager.Instance.playerData.UpLevel();
        SceneManager.LoadScene("Game");
    }

    [Button]
    public void Jump()
    {
        SetState(State.Drawing);
    }

    private float duration = 1f;

    public void SetState(State state)
    {
        currentState = state;
    }

    public void Check()
    {
        if (Level.Instance.CheckkAll())
        {
            if (Level.Instance.CheckAnswer())
            {
                ShowWin();
            }
            else
            {
                ShowLose();
            }
        }
    }
}