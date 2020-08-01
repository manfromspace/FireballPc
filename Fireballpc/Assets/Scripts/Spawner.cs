using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    public GameObject[] TilePrefabs;
    public GameObject bHole;

    private Transform playertransform;

   float score;
    //cuz it spawns only on z axis.
    private float SpawnZ = -10.0f;                                                       

    private float tileLength = 300.0f;

    private float SafeZone = 500.0f;
    // it defines amount of tile used.
    private int amntTileOnScreen = 10;

    private int lastPrefabIndex = 0;

    private List<GameObject> activeTiles;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Score>().score;
        activeTiles = new List<GameObject>();
        playertransform = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i =0; i< amntTileOnScreen; i++)
        {
            if (i < 2)
            {
                SpawnTile(0);
            }
          
            else
            {
                SpawnTile();
            }
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playertransform.position.z  > (SpawnZ - amntTileOnScreen * tileLength))
        {

            SpawnTile();
            DeleteTile();
        }
        if (score == 1000)
        {

        }

    }

    private void SpawnTile(int PrefabIndex = -1)
    {
        GameObject go;
        if(PrefabIndex == -1)
        {
            go = Instantiate(TilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
            go = Instantiate(TilePrefabs[PrefabIndex]) as GameObject;

        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * SpawnZ;
        SpawnZ += tileLength;
        activeTiles.Add(go);
    }
   /* private void SpawnBlackHole(int PrefabIndex = -1)
    {
        GameObject bo;
        if (PrefabIndex == -1)
        {
            bo = Instantiate(TilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
            bo = Instantiate(TilePrefabs[PrefabIndex]) as GameObject;

        bo.transform.SetParent(transform);
        bo.transform.position = Vector3.forward * SpawnZ;
        SpawnZ += tileLength;
        activeTiles.Add(bo);
    }
    private void deleteBlackHole()
    {
        Destroy(gameObject);
        
    }*/


    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
    private int RandomPrefabIndex()
    {
        if (TilePrefabs.Length <= 1)
            return 0 ;
        int randomIndex = lastPrefabIndex;

        while(randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, TilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
