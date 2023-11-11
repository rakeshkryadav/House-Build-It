using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject wallPanel;
    public GameObject furniturePanel;
    public GameObject treePanel;
    
    private bool value = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowInventory(){
        if(value == false){
            inventoryPanel.SetActive(true);
            value = true;
        }
        else{
            inventoryPanel.SetActive(false);
            value = false;
        }
    }

    public void ShowWalls(){
        wallPanel.SetActive(true);
        furniturePanel.SetActive(false);
        treePanel.SetActive(false);
    }

    public void ShowFurnitures(){
        wallPanel.SetActive(false);
        furniturePanel.SetActive(true);
        treePanel.SetActive(false);
    }

    public void ShowTrees(){
        wallPanel.SetActive(false);
        furniturePanel.SetActive(false);
        treePanel.SetActive(true);
    }

    public void ExitApp(){
        Application.Quit();
    }
}
