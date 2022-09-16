using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingCamera : MonoBehaviour
{
    public Camera mainCam, secondaryCam;
    private Vector2 mapBounds;
    private float centerX;
    [SerializeField] private float cameraSpeed = 1, scrollSpeed = 1;
    private float cameraSize = 2;

    private float x, y, scroll = 1;
    private float direction = 1;

    private void Start()
    {
        mapBounds = MapRenderer.Instance.mapBounds;
        centerX = mapBounds.x * 0.5f;
    }


    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        x += Input.GetAxisRaw("Horizontal") * cameraSpeed * Time.deltaTime * cameraSize;
        y += Input.GetAxisRaw("Vertical") * cameraSpeed * Time.deltaTime * cameraSize;
        scroll -= Input.mouseScrollDelta.y * scrollSpeed * Time.deltaTime;

        y = Mathf.Clamp(y, 0 + cameraSize, mapBounds.y - cameraSize);
        scroll = Mathf.Clamp(scroll, 0.1f, mapBounds.y / 2);

        if (x < 0)
        {
            x = mapBounds.x;
        }
        else if (x > mapBounds.x)
        {
            x = 0;
        }

        if (x > centerX)
        {
            direction = -1;
        }
        else
        {
            direction = 1;
        }
        
        Vector3 oldPos = secondaryCam.transform.localPosition;
        secondaryCam.transform.localPosition = new Vector3(mapBounds.x  * direction, oldPos.y, oldPos.z);

        transform.position = new Vector3(x, y, -1);
        cameraSize = scroll;
        mainCam.orthographicSize = cameraSize;
        secondaryCam.orthographicSize = cameraSize;

        

    }

}
