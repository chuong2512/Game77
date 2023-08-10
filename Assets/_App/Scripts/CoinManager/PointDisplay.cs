using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointDisplay : MonoBehaviour
{
   public TextMeshProUGUI pointTmp;
   private PlayerData playerData;

   void OnValidated()
   {
      pointTmp = GetComponent<TextMeshProUGUI>();
   }

   void Start()
   {
      playerData = GameDataManager.Instance.playerData;
      
      playerData.onChangePoint += i => OnChangePoint(i);

      playerData.point = 0;

      pointTmp.text = $"{playerData.point}";
   }
   
   void OnDestroy()
   {
      playerData.onChangePoint -= i => OnChangePoint(i);
   }

   private void OnChangePoint(int i)
   {
      pointTmp.text = $"{i}";
   }
}
