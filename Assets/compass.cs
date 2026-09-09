using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class compass : MonoBehaviour{

    public Camera cam;
    public Vector2 angle;
    public Vector2 mousePosition;
    public Transform trans;

    public GameObject target;

    void Update(){
        if (target == null){
            mousePosition = Input.mousePosition;
            mousePosition = cam.ScreenToWorldPoint(mousePosition);
            angle = new Vector2 (mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
            transform.up = angle;
        }
        else{
            angle = new Vector2(target.transform.position.x - transform.position.x, mousePosition.y - target.transform.position.y);
            transform.up = angle;
        }
        
    }
}
