using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatform;

    public float platform_Spawn_Timer=1.3f;
    private float current_Platform_Spawn_timer;

    private int platform_Spawn_count;

    public float min_X =-2f, max_X=2f;
    // Start is called before the first frame update
    void Start()
    {
        current_Platform_Spawn_timer = platform_Spawn_Timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        SpawnPlatforms();
    }

    void SpawnPlatforms()
    {
        current_Platform_Spawn_timer += Time.deltaTime;
        if(current_Platform_Spawn_timer>=platform_Spawn_Timer)
        {
            platform_Spawn_count++;


            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatforms = null;

            if(platform_Spawn_count<2)
            {
                newPlatforms = Instantiate(platformPrefab, temp, Quaternion.identity);
            }
            else if(platform_Spawn_count==2)
            {
                if(Random.Range(0,2)>0)
                {
                    newPlatforms = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatforms = Instantiate(movingPlatforms[Random.Range(0, movingPlatforms.Length)], temp, Quaternion.identity);
                }
            }
            else if (platform_Spawn_count == 4)
            {
                if (Random.Range(0, 2) > 0)
                {
                    newPlatforms = Instantiate(platformPrefab, temp, Quaternion.identity);
                }
                else
                {
                    newPlatforms = Instantiate(breakablePlatform, temp, Quaternion.identity);
                }

                platform_Spawn_count = 0;
            }

            if (newPlatforms)
                newPlatforms.transform.parent = transform;

            current_Platform_Spawn_timer = 0f;
        }
    }
}
