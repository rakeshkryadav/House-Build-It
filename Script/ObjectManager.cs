using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ObjectManager : MonoBehaviour
{
    public GameObject character;
    public GameObject controller;

    public GameObject props;
    
    public GameObject[] objects;
    public GameObject selectedObject;
    public float gridSize = 0.2f;

    private bool avatarSpawn = false;
    private Vector3 pos;
    private Vector3 characterPos;
    private Quaternion characterRot;
    private RaycastHit hit;
    [SerializeField] private LayerMask layerMask;
    
    // Start is called before the first frame update
    void Start(){
        characterPos = character.transform.position;
        characterRot = character.transform.rotation;
    }

    // Update is called once per frame
    void Update(){
        if(selectedObject != null){
            selectedObject.transform.position = new Vector3(GridArea(pos.x), GridArea(pos.y), GridArea(pos.z));
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(!EventSystem.current.IsPointerOverGameObject()){

            if(Physics.Raycast(ray, out hit, 1000, layerMask)){
                pos = hit.point;
            }
        }

        if(Input.GetMouseButtonDown(0)){
            ObjectPlace();
        }
        else if(Input.GetKeyDown(KeyCode.R)){
            ObjectRotation();
        }
        else if(Input.GetMouseButtonDown(1)){
            ObjectDelete();
        }
    }

    public bool IsPointerOverUIObject(){
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> result = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, result);
        return result.Count > 0;
    }

    public void ObjectPlace(){
        selectedObject = null;
    }

    public void ObjectRotation(){
        selectedObject.transform.Rotate(Vector3.up, 90);
    }

    public void ObjectDelete(){
        Destroy(selectedObject);
    }

    public void SelectObject(int index){
        selectedObject = Instantiate(objects[index], pos, transform.rotation);
        props.SetActive(true);

    }

    public float GridArea(float pos){
        float xDiff = pos % gridSize;
        pos -= xDiff;
        if(xDiff >= (gridSize / 2)){
            pos += gridSize;
        }
        return pos;
    }

    public void SpawnAvatar(){
        if(avatarSpawn == false){
            character.SetActive(true);
            controller.SetActive(true);
            avatarSpawn = true;
        }
        else if (avatarSpawn == true){
            controller.SetActive(false);
            character.SetActive(false);
            character.transform.position = characterPos;
            character.transform.rotation = characterRot;
            avatarSpawn = false;
        }
    }
}
