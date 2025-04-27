using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyState
{
    Spawn,
    PatrolTheArea,
    FindThePlayer,
    ChaseThePlayer,
    ReturnToPatrol,
    Exit
}
public class Enemy : MonoBehaviour
{
    private Transform _transform;
    private Queue<EnemyState> _enemyStates = new Queue<EnemyState>();
    public Queue<EnemyState> _EnemyStates => _enemyStates;
    private void Awake()
    {
        _transform = GetComponent<Transform>();
        SetTasks();
        StartCoroutine(ExecuteTasks());
    }
    public void SetTasks()
    {
        _enemyStates.Enqueue(EnemyState.PatrolTheArea);
        _enemyStates.Enqueue(EnemyState.FindThePlayer);
        _enemyStates.Enqueue(EnemyState.ChaseThePlayer);
        _enemyStates.Enqueue(EnemyState.ReturnToPatrol);
        StartCoroutine(ExecuteTasks());
    }
    private IEnumerator ExecuteTasks()
    {
        while (_enemyStates.Count > 0)
        {
            EnemyState currentTask = _enemyStates.Dequeue();
            Debug.Log($"Iniciando tarea: {currentTask}");

            switch (currentTask)
            {
                case EnemyState.PatrolTheArea:
                    yield return StartCoroutine(PatrolTheArea());
                    break;
                case EnemyState.FindThePlayer:
                    yield return StartCoroutine(FindThePlayer());
                    break;
                case EnemyState.ChaseThePlayer:
                    yield return StartCoroutine(ChaseThePlayer());
                    break;
                case EnemyState.ReturnToPatrol:
                    yield return StartCoroutine(ReturnToPatrol());
                    break;
            }

            Debug.Log("Tarea completada:" + currentTask);
        }

        Debug.Log("El enemigo ha completado todas sus tareas.");
    }
    public IEnumerator PatrolTheArea()
    {
        Debug.Log("Hola, Estoy patrullando");
        for (int i = 0; i < 2; ++i)
        {
            _transform.position = new Vector2(2, 2);
            yield return new WaitForSeconds(0.25f);
            _transform.position = new Vector2(2, -2);
            yield return new WaitForSeconds(0.25f);
            _transform.position = new Vector2(-2, -2);
            yield return new WaitForSeconds(0.25f);
            _transform.position = new Vector2(2, 2);
            yield return new WaitForSeconds(0.25f);
        }
        Debug.Log("Terminé de patrullar");
        _transform.position = Vector2.zero;
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator FindThePlayer()
    {
        Debug.Log("Estoy buscando al jugador");
        for (int i = 0; i < 36; ++i)
        {
            _transform.rotation = Quaternion.Euler(0, 0, _transform.rotation.eulerAngles.z + 10);
            yield return new WaitForSeconds(0.25f);
        }
        Debug.Log("Escaneando...");
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator ChaseThePlayer()
    {
        Debug.Log("Estoy persiguiendo al jugador");
        for (int i = 0; i < 10; ++i)
        {
        _transform.position = new Vector2(0, 2);
        yield return new WaitForSeconds(0.25f);
        _transform.position = new Vector2(0, -2);
        yield return new WaitForSeconds(0.25f);
        }
        Debug.Log("Casi lo atrapo");
        _transform.position = Vector2.zero;
        yield return new WaitForSeconds(1f);
    }
    public IEnumerator ReturnToPatrol()
    {
        Debug.Log("Estoy regresando a patrullar");
        for (int i = 0; i < 2; ++i)
        {
            _transform.position = new Vector2(2, 2);
            yield return new WaitForSeconds(0.25f);
            _transform.position = new Vector2(2, -2);
            yield return new WaitForSeconds(0.25f);
            _transform.position = new Vector2(-2, -2);
            yield return new WaitForSeconds(0.25f);
            _transform.position = new Vector2(2, 2);
            yield return new WaitForSeconds(0.25f);
        }
        Debug.Log("Listo para patrullar otra vez");
        _transform.position = Vector2.zero;
        yield return new WaitForSeconds(1f);
    }
}