using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 initialPos;
    private Vector3 newPos;
    private bool drag = false;

    public float zoomChange;
    public float smoothChange;
    public float minSize, maxSize;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.mouseScrollDelta.y > 0){
            cam.orthographicSize -= zoomChange * Time.deltaTime * smoothChange;
        }
        else if(Input.mouseScrollDelta.y < 0){
            cam.orthographicSize += zoomChange * Time.deltaTime * smoothChange;
        }

        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minSize, maxSize);
    }
    public void LateUpdate(){
        if(Input.GetMouseButton(2)){
            newPos = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if(drag == false){
                drag = true;
                initialPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else{
            drag = false;
        }

        if(drag){
            Camera.main.transform.position = initialPos - newPos;
        }
    }
}
