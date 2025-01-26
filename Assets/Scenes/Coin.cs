using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public BoxCollider2D gridArea;
    public GameObject coinPrefab; 
    public int numberOfCoins = 10; 
    private List<GameObject> allCoins = new List<GameObject>(); 
    public Win win;

    private int totalCoins; 

    public int TotalCoins
    {
        get { return totalCoins; }
    }

    private void Start()
    {

        SpawnCoins();
    }

    private void SpawnCoins()
    {

        for (int i = 0; i < numberOfCoins; i++)
        {
            GameObject coin = Instantiate(coinPrefab);
            coin.transform.position = GetRandomPosition();
            allCoins.Add(coin); 
        }

        totalCoins = allCoins.Count;
    }

    private Vector3 GetRandomPosition()
    {
        Bounds bounds = this.gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    public void RemoveCoin(GameObject coin)
    {
        allCoins.Remove(coin); 
        Destroy(coin);
        totalCoins--;
       
        

    

        
    }
}
