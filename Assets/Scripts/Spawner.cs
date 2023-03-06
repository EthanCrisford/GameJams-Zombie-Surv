using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    

    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [SerializeField] private Wave[] waves;

    [SerializeField] private float timeBetweenWaves = 3f;
    [SerializeField] private float waveCountdown = 0;

    private SpawnState state = SpawnState.COUNTING;

    private int currentWave;

    [SerializeField] private Transform[] spawners;
   // [SerializeField] private List<CharacterStats> zombieList;

    private void Start()
    {
        waveCountdown = timeBetweenWaves;

        currentWave = 0;
    }

  /*  public void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!ZombiesAreDead())
            {
                return;
            }
            else
            {
                CompleteWave();
            }
        }
        

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                StartCoroutine(SpawnWave(waves[currentWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }
  */
    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for(int i = 0; i < wave.enemiesAmount; i++)
        {
            SpawnZombie(wave.zombie);
            yield return new WaitForSeconds(wave.delay);
        }

        state = SpawnState.WAITING;

        yield break;
    }

    private void SpawnZombie(GameObject zombie)
    {
        int randomInt = Random.RandomRange(1, spawners.Length);
        Transform randomSpawner = spawners[randomInt];

       GameObject newZombie = Instantiate(zombie, randomSpawner.position, randomSpawner.rotation);
       // CharacterStats newZombieStats = newZombie.GetComponent<CharacterStats>();

       // zombieList.Add(newZombieStats);
    }

    /*& private bool ZombiesAreDead()
    {
        int i = 0;
        foreach (CharacterStats zombie in zombieList)
        {
            if (zombie.IsDead())
            {
                i++;
            }
            else
            {
                return false;
            }
            return true;
        }
    }
    */
    private void CompleteWave()
    {
        Debug.Log("Wave done.");

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (currentWave + 1 > waves.Length - 1)
        {
            currentWave = 0;
            Debug.Log("All waves done.");
        }
        else
        {
            currentWave++;
        }
        
    }
}