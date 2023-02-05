using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    public List<GameObject> flowerSpawner = new List<GameObject>();
    public List<int> lives = new List<int> ();
    public int position = 0;

    public void ActivateSpawner() 
    {
        List<FlowerPreset> temp = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameManager>().presets;

        flowerSpawner[position].GetComponent<SpriteRenderer>().sprite = temp[Random.Range(0, temp.Count)].Sprite1;
        flowerSpawner[position].GetComponent<SpriteRenderer>().enabled = true;
        position++;
    }
}
