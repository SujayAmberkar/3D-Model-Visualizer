using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorChangeScript : MonoBehaviour
{
    private GameObject target; 
    List<GameObject> targetGroup = new List<GameObject>();
    bool isOn;


    public void ChangeColor(Material m){
        foreach (var item in targetGroup)
        {
            var objectRenderer = item.GetComponent<MeshRenderer>();
            objectRenderer.material = m;
        }

    }

    public void AddOrRemove(GameObject targetObject){
            if(isOn){
                targetGroup.Add(targetObject);
            }else{
                targetGroup.Remove(targetObject);
            }
            
    }

    public void isOnValue(bool val){
        isOn = val;
    }

}
