using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    [SerializeField] private int point = 10;
    private PlayerData playerData;
    
    
    private void Enable()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Dino"))
        {
            gameObject.SetActive(false);
            //todo: point++
            if(!playerData) playerData = GameDataManager.Instance.playerData;
            playerData.AddPoint(point);
            
        }
        else if (col.CompareTag("Asteroid"))
        {
            gameObject.SetActive(false);
        }
    }
}
