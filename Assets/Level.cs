using Game58;
using UnityEngine;

[DefaultExecutionOrder(-99)]
public class Level : Singleton<Level>
{
    public GameObject hide;
    public Sprite imageTut;

    void Start()
    {
        for (int i = 0; i < levelAnswers.Length; i++)
        {
            levelAnswers[i].Reset();
        }
    }

    public car[] cars;

    void OnValidate()
    {
        cars = GetComponentsInChildren<car>();
        levelAnswers = GetComponentsInChildren<Answer>();
    }

    public bool Check()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            if (cars[i].isGoing)
            {
                return false;
            }
        }

        return true;
    }
    
    public bool CheckAnswer()
    {
        for (int i = 0; i < levelAnswers.Length; i++)
        {
            if (!levelAnswers[i].Check())
            {
                return false;
            }
        }

        return true;
    }

    public bool CheckkAll()
    {
        for (int i = 0; i < levelAnswers.Length; i++)
        {
            if (! levelAnswers[i].vacham)
            {
                return false;
            }
        }

        return true;
    }

    public Answer[] levelAnswers;
}