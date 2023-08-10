using System;
using Game58;
using UnityEngine;

namespace Assets.Game77.Object
{
    [DefaultExecutionOrder(-999)]
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private float timeIncPoints = 0.75f;
        [SerializeField] private int pointChange = 1;

        private bool isPause;
        private float countTime;
        private bool dinoAlive = true;
        private PlayerData playerData;
        private UIController uiController;

        private void Start()
        {
            isPause = false;
            dinoAlive = true;
            playerData = GameDataManager.Instance.playerData;
            uiController = GameObject.FindWithTag("UI").GetComponent<UIController>();
        }
        
        private void Update()
        {
            if(isPause) return;
            if (countTime > timeIncPoints)
            {
                countTime = 0;
                playerData.AddPoint(pointChange);
                return;
            }

            countTime += timeIncPoints;
        }

        public void GameOver()
        {
            dinoAlive = false;
            isPause = true;
            uiController.ShowLose();
        }

        public bool Revival()
        {
            if (playerData.SubDiamond(1))
            {
                dinoAlive = true;
                return true;
            }

            return false;
        }

        public bool DinoAlive => dinoAlive;

        public bool IsPause
        {
            get => isPause;
            set => isPause = value;
        }
    }
    
}