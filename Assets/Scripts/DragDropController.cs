using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropController : MonoBehaviour
{
    public GameObject underground, outside;
    private Camera cam;
    private bool isSliding;

    public Vector3 mouseButtonDownPosition, mouseButtonUpPosition;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(cam.ScreenToWorldPoint(Input.mousePosition));
            mouseButtonDownPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetMouseButtonUp(0))
        {
            print(cam.ScreenToWorldPoint(Input.mousePosition));
            mouseButtonUpPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            DragOrientationVerify();
        }
    }
    void DragOrientationVerify()
    {
        if (mouseButtonDownPosition.y == mouseButtonUpPosition.y)
            return;
        if (mouseButtonDownPosition.y < mouseButtonUpPosition.y)
        {
            if (underground.active)
                return;
            GameManager.instance.UpdateWave();
            ChangeView();
            Invoke("ChangeView", 7f);

        }
        if (mouseButtonDownPosition.y > mouseButtonUpPosition.y)
        {
            if (outside.active)
                return;
            ChangeView();
            CancelInvoke();
        }
        mouseButtonDownPosition = new Vector3(0,0,0);
        mouseButtonUpPosition = new Vector3(0, 0, 0);
    }
    public void ChangeView()
    {
        underground.SetActive(!underground.active);
        outside.SetActive(!outside.active);
    }

}
