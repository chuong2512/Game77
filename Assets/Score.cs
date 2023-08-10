using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI high, score;

    void OnEnable()
    {
        GameDataManager.Instance.playerData.CheckPoint(GameDataManager.Instance.playerData.point);
        high.SetText($"{GameDataManager.Instance.playerData.highPoint}");
        score.SetText($"{GameDataManager.Instance.playerData.point}");
    }
}
