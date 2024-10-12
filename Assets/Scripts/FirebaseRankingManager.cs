using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using SimpleJSON;
using System.Linq;

public class FirebaseRankingManager : MonoBehaviour
{
    public const string url = "https://moodengleaderboard-default-rtdb.asia-southeast1.firebasedatabase.app/";
    public const string secret = "2S8Q9HGudjIZuK1nmJJo56249y2XB51sFCxRESgx";

    [Header("Test")]
    public int testNum;
    [System.Serializable]
    public struct TestData
    {
        public int num;
        public string name;
    }

    public TestData testData = new TestData();

    public void TestSetData()
    {
        string urlData = $"{url}.json?auth={secret}";

        testData.name = "AAA";
        testData.num = 1;

        RestClient.Put<TestData>(urlData, testData).Then(response =>
        {
            Debug.Log("Upload Data Complete");
        }).Catch(error =>
        {
            Debug.Log("Error on set to server");
            Debug.Log(error.Message);
        });
    }

    // Start is called before the first frame update
    void Start()
    {
        TestSetData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
