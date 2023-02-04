using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Presets;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public TMP_InputField input;
    public void SetInput()
    {
        Debug.Log("MenuController Find: " + GameObject.FindGameObjectsWithTag("GameController").Length);
        GameObject obj = GameObject.FindGameObjectsWithTag("GameController")[0];
        obj.GetComponent<GameManager>().PlayerName = input.text;
    }
}
