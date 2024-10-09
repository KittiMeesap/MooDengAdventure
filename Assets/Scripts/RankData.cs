using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public Sprite profileSprite;
    public int rankNumber;
    public int playerTime;
}

public class RankData : MonoBehaviour
{
    public PlayerData playerData;

    [SerializeField] private Image imgPlayer;
    [SerializeField] private TMP_Text rankPlayerText;
    [SerializeField] private TMP_Text namePlayerText;
    [SerializeField] private TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateData()
    {
        imgPlayer.sprite = playerData.profileSprite;
        rankPlayerText.text = playerData.rankNumber.ToString();
        namePlayerText.text = playerData.playerName.ToString();
        timeText.text = playerData.playerTime.ToString("0.0");

    }
}
