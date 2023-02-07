using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.InputSystem;

public class PotionController : MonoBehaviour
{
    public GameObject ball;
    public float reactionTime;
    LayerMask layerMask;

    private Camera cam;
    private bool isSliding;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        this.GetComponent<Collider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (ballRb == null)
            //return;
        //TouchDragAndDrop();
        MouseDragAndDrop();
        //Debug.Log(worldTouchPosition);
    }
    private void ThrowBall()
    {
        // la bola reacciona a la fisica
        this.GetComponent<Collider2D>().enabled = true;
    }
    void MouseDragAndDrop()
    {
        if (!Input.GetMouseButton(0))
        {
            if (isSliding)
            {
                ThrowBall();
            }
            isSliding = false;
            return;
        }
        isSliding = true;
        Vector2 worldClickPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        if (worldClickPosition.y < -2.8) return;
        ball.transform.position = worldClickPosition;
    }
    /*
    void TouchDragAndDrop()
    {
        if (!Touchscreen.current.primaryTouch.press.isPressed)
        {
            if (isSliding)
            {
                ThrowBall();
            }
            isSliding = false;
            return;
        }
        // tomar control de la bola
        isSliding = true;
        Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();
        Vector2 worldTouchPosition = new Vector2(cam.ScreenToWorldPoint(touchPosition).x, cam.ScreenToWorldPoint(touchPosition).y);
        if (worldTouchPosition.y <= -2.8)
            return;
        ballRb.position = worldTouchPosition;
    }
    */
}
