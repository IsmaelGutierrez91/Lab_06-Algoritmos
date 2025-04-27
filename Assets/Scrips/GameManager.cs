using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Enemy enemy;
    [Button]
    public void RefreshEnemyTasks()
    {
        enemy.SetTasks();
    }
}
