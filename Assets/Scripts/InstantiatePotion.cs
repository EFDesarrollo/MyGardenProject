using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePotion : MonoBehaviour
{
    public GameObject potion;
    public void OnClick()
    {
        Instantiate(potion, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity);
    }
}
