using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float pastic;
    public int LevelNumber;
    public List<LevelData> levels;


    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadLevel(int LevelIndex)
    {
        List<GameObject> SpawnPoints = new List<GameObject>();
        SpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
        LevelData Data = levels[LevelIndex];
        foreach (Enemy enemy in Data.Enemies)
        {
            Instantiate(enemy.gameObject, SpawnPoints[Random.Range(0, SpawnPoints.Count)].transform);
        }
    }
}
