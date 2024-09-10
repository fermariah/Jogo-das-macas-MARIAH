using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject[] applePrefabs;

    float timer;
    const float cooldown = 1;

    private void Update()
    {
        Spawn();
    }

    void Spawn()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            float appleIndex = Random.Range(0, 1f);

            GameObject appleSelected = null;

            switch(appleIndex)
            {
                case <= 0.5f:
                    appleSelected = applePrefabs[0];
                    break;
                case <= 0.8f:
                    appleSelected = applePrefabs[1];
                    break;
                case > 0.8f:
                    appleSelected = applePrefabs[2];
                    break;
            }

            Instantiate(appleSelected, new Vector3(Random.Range(-GameManager.instance.ScreenBounds.x, GameManager.instance.ScreenBounds.x), GameManager.instance.ScreenBounds.y), Quaternion.identity);
            timer = cooldown;
        }
    }
}
