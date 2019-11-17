using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float plastic;
    public int LevelNumber;
    public List<LevelData> levels;
    public static GameController instance;
    public GameObject PausePanel;
    private bool paused = false;

    // Start is called before the first frame update
    void Start()
    {
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }
        else
        {
            Destroy(this);
        }
        LoadLevel(0);
    }

    internal void Victory()
    {
        throw new NotImplementedException();
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
            Instantiate(enemy.gameObject, SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)].transform);
        }
    }

    internal void Pause()
    {
        
        if (!paused)
        {
            Time.timeScale = 0;
            PausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            PausePanel.SetActive(false);
        }
            paused = !paused;
    }

    internal void GameOver()
    {
        throw new NotImplementedException();
    }
}
