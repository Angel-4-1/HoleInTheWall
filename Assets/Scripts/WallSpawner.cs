using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    public bool canSpawn = true;

    //types of wall
    public GameObject wall0;
    public GameObject wall1; 
    public GameObject wall2; 
    public GameObject wall3; 
    public GameObject wall4; 
    public GameObject wall5; 
    public GameObject wall6;
    public GameObject wall7;
    public GameObject wall8;
    public GameObject wall9;
    
    public List<Transform> wallSpawnPositions = new List<Transform>(); 
    public float timeBetweenSpawns; 

    //list with the walls in the scene
    private List<GameObject> wallList = new List<GameObject>(); 
    //list containing all the possible walls
    private List<GameObject> wallGameObjects = new List<GameObject>(); 

    private void addWallCandidates()
    {
        wallGameObjects.Add(wall0);
        wallGameObjects.Add(wall1);
        wallGameObjects.Add(wall2);
        wallGameObjects.Add(wall3);
        wallGameObjects.Add(wall4);
        wallGameObjects.Add(wall5);
        wallGameObjects.Add(wall6);
        wallGameObjects.Add(wall7);
        wallGameObjects.Add(wall8);
        wallGameObjects.Add(wall9);
    }

    // Start is called before the first frame update
    void Start()
    {
        addWallCandidates();
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //obtain a random wall from the list
    private GameObject randomWall()
    {
        int x = Random.Range(0, 9);
        GameObject randomWallObj = wallGameObjects[x];
        return randomWallObj;
    }

    private void SpawnWall()
    {
        Vector3 randomPosition = wallSpawnPositions[Random.Range(0, wallSpawnPositions.Count)].position;

        //pick a random wall
        GameObject randomWallSelected = randomWall();
        //instantiate the wall to its position
        GameObject wallToList = Instantiate(randomWallSelected, randomPosition, randomWallSelected.transform.rotation);
        //add it to the list
        wallList.Add(wallToList);
        wallToList.GetComponent<Wall>().SetSpawner(this);
    }

    private IEnumerator SpawnRoutine()
    {
        while (canSpawn)
        {
            SpawnWall();
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }

    //remove a wall from the list
    public void RemoveWallFromList(GameObject wall)
    {
        wallList.Remove(wall);
    }

    //clear the list
    public void DestroyAllWalls()
    {
        foreach (GameObject wall in wallList)
        {
            Destroy(wall);
        }

        wallList.Clear();
    }
}
