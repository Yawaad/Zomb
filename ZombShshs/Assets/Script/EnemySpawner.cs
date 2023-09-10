using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject Enemy;
    private void Update()
    {
        var Position = new Vector2(Random.Range(-20,20), Random.Range(-20,20));
        Instantiate(Enemy, Position, Quaternion.identity);
        
    }
}
