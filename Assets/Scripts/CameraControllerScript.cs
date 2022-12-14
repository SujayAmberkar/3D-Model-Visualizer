using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerScript : MonoBehaviour
{ [SerializeField] private Camera cam;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    [SerializeField] float cameraSpeed = 10f;
    private Vector3 previousPosition;
    
    Vector3 camInitialPos;
    Quaternion camInitialRot;
    float camInitialZoom;

    void Start() {
           camInitialPos = cam.transform.position;
           camInitialRot = cam.transform.rotation;
           camInitialZoom = cam.fieldOfView;
    }

    void Update()
    {
        cameraMovements();
    }

    void cameraMovements(){
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = previousPosition - newPosition;
            
            float rotationAroundYAxis = -direction.x * 180; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 180; // camera moves vertically
            
            cam.transform.position = target.position;
            
            cam.transform.Rotate(new Vector3(1, 0, 0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0, 1, 0), rotationAroundYAxis, Space.World); 
            
            cam.transform.Translate(new Vector3(0, 0, -distanceToTarget));
            
            previousPosition = newPosition;
        }
        cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * cameraSpeed;
    }

    public void ResetCamera(){
        cam.transform.position = camInitialPos;
        cam.transform.rotation = camInitialRot;
        cam.fieldOfView = camInitialZoom;
    }
}
