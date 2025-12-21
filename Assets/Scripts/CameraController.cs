using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float movementTime = 5f;
    public float minX;
    public float maxX;
    public float minZ;
    public float maxZ;

    public Vector3 newPosition;

    public float zoomSpeed = 5f;
    public float zoomSmoothTime = 10f;
    public float minZoom = 5f;
    public float maxZoom = 20f;

    public Camera cam;
    private float targetZoom;

    void Start()
    {
        newPosition = transform.position;
        targetZoom = cam.orthographicSize;
    }

    void Update()
    {
        HandleMovementInput();
        HandleZoom();
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            if( newPosition.x>minX && newPosition.z > minZ)
            {
                newPosition += transform.forward * -movementSpeed;
            }
        }

        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
                if(newPosition.x<maxX && newPosition.z<maxZ)
            {
                    newPosition += transform.forward * movementSpeed;

            }

        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if(newPosition.x>minX && newPosition.z<maxZ)
            {
                    newPosition += transform.right * -movementSpeed;

            }
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(newPosition.x<maxX && newPosition.z > minZ)
            {
                    newPosition += transform.right * movementSpeed;

            }
        }

        transform.position = Vector3.Lerp(
            transform.position,
            newPosition,
            Time.deltaTime * movementTime
        );
    }


    void HandleZoom()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        if (scroll != 0f)
        {
            targetZoom -= scroll * zoomSpeed;
            targetZoom = Mathf.Clamp(targetZoom, minZoom, maxZoom);
        }

        cam.orthographicSize = Mathf.Lerp(
            cam.orthographicSize,
            targetZoom,
            Time.deltaTime * zoomSmoothTime
        );
    }
}
