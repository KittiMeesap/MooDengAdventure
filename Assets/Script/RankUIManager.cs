using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RankUIManager : MonoBehaviour  
{
    public GameObject rankDataPrefab;
    public Transform rankPanel;

    public List<PlayerData> playerDatas = new List<PlayerData>();

    public List<GameObject> createdPlayerDatas = new List<GameObject>();

    

    // Start is called before the first frame update
    void Start()
    {
        CreateRankData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreateRankData()
    {
        for (int i = 0; i < playerDatas.Count; i++)
        {
            GameObject rankObj = Instantiate(rankDataPrefab, rankPanel);
            RankData rankData = rankObj.GetComponent<RankData>();

            rankData.playerData = new PlayerData();
            rankData.playerData.playerName = playerDatas[i].playerName;
            rankData.playerData.playerScore = playerDatas[i].playerScore;
            rankData.playerData.rankNumber = playerDatas[i].rankNumber;
            rankData.playerData.profileSprite = playerDatas[i].profileSprite;

            rankData.UpdateData();
            createdPlayerDatas.Add(rankObj);
        }
    }

    private void ClearRankData()
    {
        foreach (GameObject createdData in createdPlayerDatas)
        {
            Destroy(createdData);
        }
        createdPlayerDatas.Clear();
    }

    private void SortRankData()
    {
        List<PlayerData> sortRankPlayer = playerDatas.OrderByDescending(data => data.playerScore).ToList();
        sortRankPlayer = playerDatas.OrderByDescending(data => data.playerScore).ToList();
        //sortRankPlayer.ForEach(data => data.rankNumber = sortRankPlayer.IndexOf(data)+1);
        for (int i = 0; i < sortRankPlayer.Count; i++)
        {
            PlayerData changedNum = sortRankPlayer[i];
            changedNum.rankNumber = i + 1;

            sortRankPlayer[i] = changedNum;

        }
        playerDatas = sortRankPlayer;
    }

    [ContextMenu("Reload")]
    public void ReloadRankData()
    {
        ClearRankData();
        SortRankData();
        CreateRankData();
    }

}
