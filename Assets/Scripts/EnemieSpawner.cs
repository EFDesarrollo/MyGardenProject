using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.WSA;

public class EnemieSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject parent;
    public GameObject spawn;
    public GameObject enemieObjetive;
    public List<GameObject> enemiesPrefab;
    private int wave = 0;
    public int activeOnWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Comprobacion();
    }
    void Comprobacion()
    {
        if (wave != GameManager.instance.wave)
        {
            wave = GameManager.instance.wave;
            if (activeOnWave <= wave)
            {
                enemieObjetive.GetComponent<SpriteRenderer>().enabled = true;
                bool x = false;
                int rand = Random.Range(0, 1000);
                for (int i = 0; i < GameManager.instance.adv_Disadv_P.Count; i++)
                {
                    if (GameManager.instance.adv_Disadv_P[i] == 1)
                        x = true;
                }
                if (x)
                {
                    print("comprobacion ventaja positiva");
                    if ((100 <= rand) && (rand <= 300) && x)
                    {
                        print("comprobacion ventaja positiva x2");
                        SpawnEnemy();
                    }
                    else if (enemieObjetive.GetComponent<RootController>().wavesSinBicho >= 3)
                    {
                        SpawnEnemy(2);
                    }
                }
                else
                {
                    print("comprobacion ventaja negativa");
                    SpawnEnemy();
                }
            }
            else
            {
                enemieObjetive.GetComponent<RootController>().wavesSinBicho = 0;
            }
        }
    }
    void SpawnEnemy(int count = 1)
    {
        enemieObjetive.GetComponent<RootController>().wavesSinBicho = 0;
        for (int i = 0; i < count; i++)
        {
            int enemyType = Random.Range(0, enemiesPrefab.Count);
            GameObject obj = Instantiate(enemiesPrefab[enemyType], spawn.transform.position, Quaternion.identity);
            obj.transform.SetParent(parent.transform);
            obj.GetComponent<EnemyMovement>().startPosition = spawn.transform.position;
            obj.GetComponent<EnemyMovement>().endPosition = enemieObjetive.transform.position;
            obj.GetComponent<EnemyMovement>().type = enemyType;
        }
    }
}
