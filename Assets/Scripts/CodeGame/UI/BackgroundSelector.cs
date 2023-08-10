using UnityEngine;

public class BackgroundSelector : MonoBehaviour
{
    private PlayerData playerData; //todo delete
    private GameDataManager gameData; 
    public int currentBG;
    public SkinItem[] skinItems;
    
    public void UnlockBG(int index)
    {
        if (!playerData.listBGs[index])
        {
            playerData.SubDiamond(Constant.priceUnlockBG);
        }
        
        skinItems[index].Unlock();
        
        playerData.UnlockBG(index);
    }
    
    void Start()
    {
        gameData = GameDataManager.Instance;
        playerData = gameData.playerData;
        
        currentBG = playerData.currentBG;

        for (int i = 0; i < skinItems.Length; i++)
        {
            if (playerData.listBGs[i])
            {
                skinItems[i].Unlock();
                skinItems[i].UnChoose();
            }
        }
        
        skinItems[currentBG].Choose();
    }
    
    public void ChooseSkin(int index)
    {
        if (currentBG == index)
        {
            return;
        }
        else if (playerData.listBGs[index] == false)
        {
            if (!playerData.CheckCanUnlockBG())
            {
                return;
            }
            UnlockBG(index);
        }
        
        skinItems[currentBG].UnChoose();
        skinItems[index].Choose();
        currentBG = index;
        playerData.ChooseBG(currentBG);
        
        //todo add Playerdata
    }

}
