using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
   [SerializeField] List<WaveConfig> waveConfigs;
   [SerializeField] WaveConfig bossWave;
   [SerializeField] int startingWave = 0;
   [SerializeField] bool looping = false;
    Level level;
    private bool bossSpawned = false;
    public int enemiesKilled = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
         }
        while(looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for(int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
             if(!bossSpawned)
            { 
                yield return StartCoroutine(spawnAllEnemiesInWave(currentWave));
            }
            else{
                yield return null;
            }
        }

    
    }

    
    private IEnumerator spawnAllEnemiesInWave(WaveConfig waveConfig)
    {
        for(int enemyCount = 0; enemyCount < waveConfig.getNumberOfEnemies(); enemyCount++)
             {
                 var newEnemey = Instantiate(waveConfig.getEnemyPrefab(), 
                                 waveConfig.getWaypoints()[0].transform.position, 
                                 Quaternion.identity);
                                 newEnemey.GetComponent<EnemyPathing>().setWaveConfig(waveConfig);
                                 yield return new WaitForSeconds(waveConfig.getTimeBetweenSpawns());
             }
    }  

    

    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level 1")
        {
            if(enemiesKilled >= 50 && bossSpawned == false)
            {
                bossSpawned = true;
                StartCoroutine(spawnAllEnemiesInWave(bossWave));
            }        
        }

        if(SceneManager.GetActiveScene().name == "Level 2")
        {
            if(enemiesKilled >= 75 && bossSpawned == false)
            {
                bossSpawned = true;
                StartCoroutine(spawnAllEnemiesInWave(bossWave));
            }        
        }

        if(SceneManager.GetActiveScene().name == "Level 3")
        {
            if(enemiesKilled >= 100 && bossSpawned == false)
            {
                bossSpawned = true;
                StartCoroutine(spawnAllEnemiesInWave(bossWave));
            }        
        }



       
    }





      
   
}
