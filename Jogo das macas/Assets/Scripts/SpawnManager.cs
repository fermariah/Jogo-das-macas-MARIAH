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

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public int maxApples = 10;
    public List<Vector2> applePositions = new List<Vector2>();
    public float spawnRange = 5f;

    void SpawnApple()
    {
        Vector2 newPosition;
        bool positionValid;

        do
        {
            newPosition = new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
            positionValid = true;

            // Verifica se a posição já está ocupada
            foreach (var pos in applePositions)
            {
                if (Vector2.Distance(pos, newPosition) < 1f)
                {
                    positionValid = false;
                    break;
                }
            }
        }
        while (!positionValid);

        Instantiate(applePrefab, newPosition, Quaternion.identity);
        applePositions.Add(newPosition);
    }
}