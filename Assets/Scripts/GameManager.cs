using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public string PlayerName;
    public List<FlowerPreset> presets = new List<FlowerPreset>();
    public List<int> adv_Disadv_P = new List<int>();
    public int wave = 0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateWave()
    {
        wave++;
    }
}
