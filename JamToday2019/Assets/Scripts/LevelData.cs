using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Level",menuName ="Level")]
public class LevelData : ScriptableObject
{
   public List<Enemy> Enemies;
   public List<GameObject> SpawnPoints;
}
