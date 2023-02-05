using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Flower Preset", menuName = "New Flower Preset")]
public class FlowerPreset : ScriptableObject
{
    public Sprite Sprite1, Sprite2, Sprite3;
    public string Name;
    public string Description;
    public int Type;
}
