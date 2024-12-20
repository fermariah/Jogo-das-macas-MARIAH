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

public class AppleSpawner : SpawnManager //classe derivada do SpawnManager para definir os spawns das ma��s e suas destrui��es
{
    public GameObject macaPrefab;
    public int maxMacas = 10;
    public List<Vector2> MacasPosicoes = new List<Vector2>();
    public float spawnRange = 5f;

    void SpawnApple() //m�todo para implementar o while do e foreach
    {
        Vector2 posicaonova;
        bool posicaovalida;

        do
        {
            posicaonova = new Vector2(Random.Range(-spawnRange, spawnRange), Random.Range(-spawnRange, spawnRange));
            posicaovalida = true;

            // Verifica se a posi��o j� est� ocupada
            foreach (var pos in MacasPosicoes)
            {
                if (Vector2.Distance(pos, posicaonova) < 1f)
                {
                    posicaovalida = false;
                    break;
                }
            }
        }
        while (!posicaovalida);

        Instantiate(macaPrefab, posicaonova, Quaternion.identity);
        MacasPosicoes.Add(posicaonova);
    }
}