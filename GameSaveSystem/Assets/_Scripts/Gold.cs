using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Gold : MonoBehaviour, ISaveable
{
    [SerializeField] private string id;
    [ContextMenu("Generate guid")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private bool isCollected = false;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player")              //checks if the layer of the colliding object is 10 ("Pickups")
        {
            col.GetComponent<PlayerStats>().playerGold++;
            CollectCoin();
        }
    }

    private void CollectCoin()
    {
        
        isCollected = true;
        Destroy(gameObject);
    }

    public void LoadData(GameData data)
    {
        data.coinsCollected.TryGetValue(id, out isCollected);
        if (isCollected)
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.coinsCollected.ContainsKey(id))
        {
            data.coinsCollected.Remove(id);
        }
        data.coinsCollected.Add(id, isCollected);
    }
}
