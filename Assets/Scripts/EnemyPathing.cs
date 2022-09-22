using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    WaveConfig waveConfig;
    [SerializeField] List<Transform> waypoints;
    int waypointIndex = 0;
      public bool loop = false;


    // Start is called before the first frame update
    void Start()
    {
        waypoints = waveConfig.getWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;   
    }
    

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    public void setWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPos = waypoints[waypointIndex].transform.position;
            var movementThisFrame = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);

            if (transform.position == targetPos)
            {
                waypointIndex++;
            }
        }
        else
        {
            if(!loop)
            {
            Destroy(gameObject);
            }
            else
            {
                waypointIndex = 0;
            }
            

        }
    
        
    }

  
}
