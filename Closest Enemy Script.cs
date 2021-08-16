using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ClosestEnemyScript : MonoBehaviour
{
    
    // Configs
    [SerializeField] float minDistanceToMoveToward;
    [SerializeField] float speed;
    
    // Cache
    Enemy[] _enemies;
    Transform _nearestEnemy;


    private void Awake()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    private void Update()
    {
        FindClosestEnemy();
        MoveToward();
    }
    
    
    /// <summary>
    /// Find closest enemy WITHOUT using LINQ
    /// </summary>
    private void FindClosestEnemy()
    {
        float minDistanceToClosestEnemy = minDistanceToMoveToward;
        _nearestEnemy = null;

        foreach (var enemy in _enemies)
        {
            // if there is an enemy in scene
            if (enemy != null)
            {
                // gets the distance between player and enemy
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                
                // if the distance between them is smaller than ... (minDistanceToClosestEnemy)
                if (distance < minDistanceToClosestEnemy)
                {
                    // then set the nearest enemy to the closest one
                    _nearestEnemy = enemy.transform;
                    // and set the new distance to the closest one
                    minDistanceToClosestEnemy = distance;
                }
            }
        }
        Debug.DrawLine(transform.position, _nearestEnemy.transform.position, Color.red);
    }
    
    
    /// <summary>
    /// Find closest enemy using LINQ
    /// </summary>
    private void FindClosestEnemyLINQ()
    {
        var nearestEnemyLinq = _enemies.OrderBy(enemy => Vector3.Distance(transform.position, enemy.transform.position))
            .FirstOrDefault();
    }
    

    /// <summary>
    /// Move toward closest enemy
    /// </summary>
    private void MoveToward()
    {
        if (_nearestEnemy != null)
        {
            var moveTowardSpeed = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, _nearestEnemy.transform.position, moveTowardSpeed);
        }
    }
}
