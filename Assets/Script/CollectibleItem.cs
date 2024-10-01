using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public void Collect()
    {
        Debug.Log("Item collected!");

        Destroy(gameObject);
    }
}

