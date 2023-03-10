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

    private void Start()
    {
        waveCountdown = timeBetweenWaves;

        currentWave = 0;

        state = SpawnState.SPAWNING;
        StartCoroutine(SpawnWave(waves[currentWave]));

    }

    public void Update()
    {


        print("state=" + state);

       if (state == SpawnState.WAITING)
       {
            if (ZombiesIsDead()==false)
            {
                // zombies are still alive
                return;
            }
            else
            {
                // zombies are all dead
                CompleteWave();
            }
            return;
        }

        print("*** new wave ***");

        if (ZombiesIsDead() == true)
        {
            if (waveCountdown <= 0)
            {
                if (state != SpawnState.SPAWNING)
                {
                    print("start coroutine");
                    state = SpawnState.SPAWNING;
                    StartCoroutine(SpawnWave(waves[currentWave]));
                }
            }
            else
            {
                waveCountdown -= Time.deltaTime;
            }
        }
       


   }
 
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
        int randomInt = Random.RandomRange(0, spawners.Length);
        Transform randomSpawner = spawners[randomInt];

        GameObject newZombie = Instantiate(zombie, randomSpawner.position, randomSpawner.rotation);
        CharacterStats newZombieStats = newZombie.GetComponent<CharacterStats>();

        
    }


    private bool ZombiesIsDead()
    {
        GameObject[]zombies = GameObject.FindGameObjectsWithTag("Zombie");
        if( zombies.Length > 0)
        {
            return false;
        }
        return true;
    }
    

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