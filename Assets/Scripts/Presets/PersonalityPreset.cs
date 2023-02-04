using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Personality Preset", menuName = "New Personality Preset")]

public class PersonalityPreset : ScriptableObject
{
    public string Name;
    public string Description, AdvDescription, DisadvDescription;
    public Sprite Sprite;
    public int Adv_Disadv;
}
