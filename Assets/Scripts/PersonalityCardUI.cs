using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonalityCardUI : MonoBehaviour
{
    public PersonalityPreset p_Preset;
    public TextMeshProUGUI name, description, advDescription, disadvDescription;
    public Image icon;

    private void Start()
    {
        name.text = p_Preset.Name;
        description.text = p_Preset.Description;
        advDescription.text = p_Preset.AdvDescription;
        disadvDescription.text = p_Preset.DisadvDescription;
        icon.sprite = p_Preset.Sprite;
    }
    public void OnClick()
    {
        Debug.Log("MenuController Find: " + GameObject.FindGameObjectsWithTag("GameController").Length);
        GameObject obj = GameObject.FindGameObjectsWithTag("GameController")[0];
        obj.GetComponent<GameManager>().adv_Disadv_P.Add(p_Preset.Adv_Disadv);
    }
}
