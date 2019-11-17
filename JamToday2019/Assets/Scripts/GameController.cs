using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float plastic;
    public int LevelNumber;
    public List<LevelData> levels;
    public List<GameObject> enemies;
    public static GameController instance;
    public GameObject PausePanel;
    public GameObject ShopPanel;
    private bool paused = false;


    private void Awake()
    {
        if (GameController.instance == null)
        {
            GameController.instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        LoadLevel(0);
        OpenShop();
    }

    internal void Victory()
    {
        throw new NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.Count <= 0)
        {
            NextLevel();
        }
    }


    private void NextLevel()
    {
       // throw new NotImplementedException();
    }

    public void LoadLevel(int LevelIndex)
    {
        
        if (LevelIndex >= levels.Count)
            Victory();
        List<GameObject> SpawnPoints = new List<GameObject>();
        SpawnPoints.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoint"));
        LevelData Data = levels[LevelIndex];
        foreach (Enemy enemy in Data.Enemies)
        {
            GameObject go = Instantiate(enemy.gameObject, SpawnPoints[UnityEngine.Random.Range(0, SpawnPoints.Count)].transform);
            GameController.instance.enemies.Add(go);
        }
    }

    public List<Image> hearts = new List<Image>();
    public void UpdateLifeCanvas()
    {
        foreach (Image sprite in hearts)
        {
            sprite.gameObject.SetActive(false);
        }
        for (int i = 0; i < PlayerController.instance.health; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }

    public List<Image> lighting = new List<Image>();
    public void UpdateSpeedCanvas()
    {
        foreach (Image sprite in lighting)
        {
            sprite.gameObject.SetActive(false);
        }
        for (int i = 0; i < PlayerController.instance.speed/2; i++)
        {
            lighting[i].gameObject.SetActive(true);
        }
    }
    public List<Image> bullets = new List<Image>();
    public void UpdateCDCanvas()
    {
        foreach (Image sprite in bullets)
        {
            sprite.gameObject.SetActive(false);
        }
        for (int i = 0; i < PlayerController.instance.ShootCDBuys; i++)
        {
            bullets[i].gameObject.SetActive(true);
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

    public void OpenShop()
    {
        ShopPanel.SetActive(true);
        Pause();
    }
    public void CloseShop()
    {
        print("click");
        ShopPanel.SetActive(false);
        Pause();
    }
    internal void GameOver()
    {
        throw new NotImplementedException();
    }
}
