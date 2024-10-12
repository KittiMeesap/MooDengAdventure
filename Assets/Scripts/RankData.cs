using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PlayerData
{
    public string playerName;
    public Sprite profileSprite;
    public int rankNumber;
    public float playerTime;
}

public class RankData : MonoBehaviour
{
    public PlayerData playerData;

    [SerializeField] private Image imgPlayer; 
    [SerializeField] private TMP_Text rankPlayerText;
    [SerializeField] private TMP_Text namePlayerText; 
    [SerializeField] private TMP_Text timeText; 

    public void UpdateData(PlayerData newData)
    {
        playerData = newData;
        imgPlayer.sprite = playerData.profileSprite;
        rankPlayerText.text = playerData.rankNumber.ToString();
        namePlayerText.text = playerData.playerName;
        timeText.text = playerData.playerTime.ToString("00:00");
    }
}
