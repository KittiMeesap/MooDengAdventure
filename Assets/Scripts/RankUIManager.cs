using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankUIManager : MonoBehaviour
{
    public GameObject rankDataPrefab;
    public Transform rankPanel;

    public List<PlayerData> playerDatas = new List<PlayerData>(); 
    public List<GameObject> createdPlayerData = new List<GameObject>();

    public RankData yourRankData;

    void Start()
    {
        CreateRankData();
    }

    public void CreateRankData()
    {
        foreach (var player in playerDatas)
        {
            GameObject rankObj = Instantiate(rankDataPrefab, rankPanel);
            RankData rankData = rankObj.GetComponent<RankData>();

            rankData.UpdateData();
            createdPlayerData.Add(rankObj);
        }
    }

    public void ClearRankData()
    {
        foreach (GameObject createdData in createdPlayerData)
        {
            Destroy(createdData);
        }
        createdPlayerData.Clear();
    }

    

    public void ReloadRankData()
    {
        ClearRankData();
        //SortRankData();
        CreateRankData();
    }
    public void AddPlayerData(string playerName, float playerTime, Sprite profileSprite)
    {
        PlayerData newPlayer = new PlayerData
        {
            playerName = playerName,
            playerTime = playerTime,
            profileSprite = profileSprite
        };

        playerDatas.Add(newPlayer); 
        ReloadRankData();
    }
}