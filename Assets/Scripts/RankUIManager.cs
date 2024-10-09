using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Data;

public class RankUIManager : MonoBehaviour
{
    public GameObject rankDataPrefab;
    public Transform rankPanel;

    public List<PlayerData> playerDatas = new List<PlayerData>();
    public List<GameObject> createdPlayerData = new List<GameObject>();

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
        for (int i = 0; i < playerDatas.Count; i++ )
        {
            GameObject rankobj = Instantiate( rankDataPrefab, rankPanel );
            RankData rankData = rankobj.GetComponent<RankData>();

            rankData.playerData = new PlayerData();
            rankData.playerData.playerName = playerDatas[i].playerName;
            rankData.playerData.playerTime = playerDatas[i].playerTime; 
            rankData.playerData.rankNumber = playerDatas[i].rankNumber;
            rankData.playerData.profileSprite = playerDatas[i].profileSprite;

            rankData.UpdateData();
            createdPlayerData.Add(rankobj);
        }
    }

    public void ClearRankData()
    {
        foreach (GameObject createdData in createdPlayerData)
        {
            Destroy( createdData);
        }
        createdPlayerData.Clear();
    }

    public void SortRankData()
    {
        List<PlayerData> sortRankPlayer = new List<PlayerData>();
        sortRankPlayer = playerDatas.OrderByDescending(data => data.playerTime).ToList();
        sortRankPlayer.ForEach(data => data.rankNumber = sortRankPlayer.IndexOf(data) +1);
        /*for (int i = 0; i < sortRankPlayer.Count; i++)
        {
            sortRankPlayer[i].rankNumber = i + 1;
        }*/
        playerDatas = sortRankPlayer;
    }

    [ContextMenu("Reload")]
    public void ReloadRankData()
    {
        ClearRankData();
        CreateRankData();
    }

}
