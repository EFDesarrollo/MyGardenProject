using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootController : MonoBehaviour
{
    public Vector2 pos1, pos2, pos3;
    public bool pos1Active, pos2Active, pos3Active;
    public int pos1Type, pos2Type, pos3Type;
    public List<GameObject> enemy;
    public int type;
    public int wavesSinBicho;
    public int wavesActual = 0;
    public bool recibePocion, recibeBicho;

    void OnTriggerEnter2D(Collider2D other)
    {
        print(other.tag);
        if (other.CompareTag("Enemy"))
        {
            print("EnemyEnter");
            recibeBicho = true;
            type = other.GetComponent<EnemyMovement>().type; 
            Destroy(other.gameObject);
            BichoCome();
        }
    }

    public void BichoCome()
    {
        if (!pos1Active)
        {
            pos1Active = true;
            pos1Type = type;
            Instantiate(enemy[type], pos1, Quaternion.identity).transform.SetParent(transform, false);
        } 
        else if (!pos2Active)
        {
            pos2Active = true;
            pos2Type = type;
            Instantiate(enemy[type], pos2, Quaternion.identity).transform.SetParent(transform, false);
        } 
        else if (!pos3Active)
        {
            pos3Type = type;
            pos3Active = true;
            Instantiate(enemy[type], pos3, Quaternion.identity).transform.SetParent(transform, false);
        } 
        else
        {
            PlantaMuere();
        }
    }

    public void PlantaMuere()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (wavesActual != GameManager.instance.wave)
        {
            if (!recibeBicho)
                wavesSinBicho++;
            else
                wavesSinBicho = 0;
            recibeBicho = false;
            wavesActual = GameManager.instance.wave;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere((Vector2)transform.position + pos1, 0.1f);
        Gizmos.DrawWireSphere((Vector2)transform.position + pos2, 0.1f);
        Gizmos.DrawWireSphere((Vector2)transform.position + pos3, 0.1f);
    }
}
