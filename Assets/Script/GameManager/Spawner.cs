using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> MonsterPrefabs;
    [SerializeField] private List<Transform> SpawnPoints;
    private int m_playerDamage = 20;
    private Health m_playerHealth;
    private int m_spawnCounter = 0;
    private UnityAction m_onGameOver;
    IEnumerator SpawnMonsterRoutine;
    void OnEnable()
    {
        m_onGameOver += OnGameOver;
    }
    void OnDisable()
    {
        m_onGameOver -= OnGameOver;
    }
    void Start()
    {
        GameManager.Instance.RegisterOnGameOverEvent(m_onGameOver);
        m_playerHealth = GameObject.FindWithTag("Player").GetComponent<Health>();
        StartCoroutine(SpawnMonster());
    }
    void OnGameOver()
    {
        StopAllCoroutines();
    }
    Transform RandomSpawnPoint()
    {
        return SpawnPoints[Random.Range(0, SpawnPoints.Count)];
    }
    GameObject RandomMonster()
    {
        return MonsterPrefabs[Random.Range(0, MonsterPrefabs.Count)];
    }
    IEnumerator SpawnMonster()
    {
        Debug.Log("Spawn Routines");
        GameObject monster = RandomMonster();
        Transform spawnPoint = RandomSpawnPoint();
        int monsterHealth = monster.GetComponent<Health>().MaxHealth;
        //Callculate spawn delay time
        float delayTime = monsterHealth / m_playerDamage +
        (10f - (m_playerHealth.CurrentHealth / 10f / (m_spawnCounter + 5f)));
        Debug.Log(delayTime);
        //*Idea delay time  = monster health / hero damage + 100/monster spawn counter + 5
        //Spawn new monster
        yield return new WaitForEndOfFrame();
        Instantiate(monster, spawnPoint.position, Quaternion.identity);
        m_spawnCounter++;
        //Wait for delay time
        yield return new WaitForSecondsRealtime(delayTime);
        StartCoroutine(SpawnMonster());
    }
}