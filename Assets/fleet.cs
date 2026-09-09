using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fleet : MonoBehaviour{

    List<GameObject> ships = new List<GameObject>();
    List<GameObject> path = new List<GameObject>();

    public GameObject compass;
    compass comp;
    public GameObject test_ship;
    public GameObject indicator;
    GameObject dest_obj;
    GameObject destination_obj;

    float bearing;
    int CNT_sh = -1;
    int CNT_PT = -1;
    int CNT_PT_SLC = 0;
    int CNT_PT_SAVE = -1;
    int moves = 5;
    int move = 1;
    int pause = -1;
    int move_type = 1;

    Vector2 mouse_pos;
    Vector2 destination;
    Vector2 distance_1;
    public Vector2 distance_2;
    public Vector2 last_pos;

    public Camera cam; 
    
    void Start(){
        last_pos = transform.position;
        comp = compass.GetComponent<compass>();
    }

    void Update(){
        Move();
        if (Input.GetKeyDown(KeyCode.F)){
            GameObject test_ship_append = Instantiate(test_ship,gameObject.transform.position + new Vector3(Random.Range(0.8f,-0.8f),Random.Range(0.8f,-0.8f),1),transform.rotation);
            test_ship_append.transform.parent = gameObject.transform;
            ships.Add(test_ship_append);
            CNT_sh++ ;
            test_ship_append.name = CNT_sh.ToString();
        }
        if (Input.GetKeyDown(KeyCode.E)){
            for (int I = 0; I <= CNT_sh; I++){
                Debug.Log(ships[I]);
                Debug.Log(I);
            }
        }
    }

    void Move(){
        mouse_pos = Input.mousePosition;
        mouse_pos = cam.ScreenToWorldPoint(mouse_pos);
        if (Input.GetMouseButton(0)){ // select destination
            move = 0;
                destination = new Vector2((mouse_pos.x - (mouse_pos.x % 1 - 0.5f)), (mouse_pos.y - (mouse_pos.y % 1 - 0.5f)));
                if (destination != last_pos){
                    distance_1 = mouse_pos - last_pos;
                    distance_2 = destination - last_pos;
                    if (distance_2.x < 0){
                        distance_2.x = -distance_2.x;
                    }
                    if (distance_2.y < 0){
                        distance_2.y = -distance_2.y;
                    }
                    if (distance_1.x < 0){
                        distance_1.x = -distance_1.x;
                    }
                    if (distance_1.y < 0){
                        distance_1.y = -distance_1.y;
                    }
                    if (distance_2.x <= 1 && distance_2.y <= 1){
                        if (distance_1.x >= 0.9f || distance_1.y >= 0.9f){
                            // mouse draw movement
                            if (moves != 0){
                                move_type = 1;
                                last_pos = destination;
                                GameObject ind = Instantiate(indicator,new Vector3(destination.x,destination.y,1),transform.rotation);
                                path.Add(ind);
                                if (CNT_PT == -2){
                                    CNT_PT++ ;
                                }
                                CNT_PT++ ;
                                CNT_PT_SAVE = CNT_PT;
                                CNT_PT_SLC = 0;
                                moves-- ;
                            }
                        }
                    }
                    else{
                        // simple move
                        int deducted_distance = 0;
                        float larger_distance = distance_2.y;
                        if (distance_2.x > distance_2.y){
                            larger_distance = distance_2.x;
                        }
                        for (int I = 0; I <= moves; I++){
                            if (larger_distance == I){
                                deducted_distance = I;
                            }
                        }
                        if (distance_2.x <= moves && distance_2.y <= moves){
                            if (moves != 0){
                                move_type = 1;
                                last_pos = destination;
                                GameObject ind = Instantiate(indicator,new Vector3(destination.x,destination.y,1),transform.rotation);
                                path.Add(ind);
                                if (CNT_PT == -2){
                                    CNT_PT++;
                                }
                                CNT_PT++;
                                CNT_PT_SAVE = CNT_PT;
                                CNT_PT_SLC = 0;
                                moves = moves - deducted_distance;
                            }
                        }
                        else if(32 == 33){
                            if (moves != 0){
                                move_type = 2;
                                last_pos = destination;
                                destination_obj = Instantiate(indicator,new Vector3(destination.x,destination.y,1),transform.rotation);
                                CNT_PT_SAVE = 0;
                            }
                        }
                    }
                }
                //indicator.transform.position = new Vector3(destination.x,destination.y,1); // plac
        }
        if (Input.GetMouseButtonUp(0)){
            move = 1;
        }
        if (move == 1){
            if (CNT_PT >= -1 && CNT_PT_SAVE > -1){
                if (destination.x != gameObject.transform.position.x || destination.y != gameObject.transform.position.y){ // travel
                    if (dest_obj == null){
                        if (pause == 1){
                            if (move_type == 1){
                                if (CNT_PT_SLC <= CNT_PT_SAVE){
                                    dest_obj = path[CNT_PT_SLC];
                                }
                                else{
                                    CNT_PT_SLC = CNT_PT_SAVE;
                                }
                                CNT_PT_SLC++ ;
                                CNT_PT-- ;
                            }
                            else{
                                if (moves != 0){
                                    // simple move
                                    if (destination_obj != null){
                                        float X_dist = 0;
                                        float Y_dist = 0;
                                        int mod_x = -1;
                                        int mod_y = -1;
                                        int move_goal = 0;
                                        distance_1 = destination_obj.transform.position - transform.position;
                                        // distance_1 holds the true distance between the goal and the fleet, distance 2 holds the distance without negatives
                                        if (distance_1.x < 0){
                                            distance_2.x = -distance_1.x;
                                            mod_x = 1;
                                        }
                                        if (distance_1.y < 0){
                                            distance_2.y = -distance_1.y;
                                            mod_y = 1;
                                        }
                                        if (distance_2.x >= moves){
                                            X_dist = moves * mod_x;
                                        }
                                        else{
                                            // within reach
                                            move_goal++ ;
                                            X_dist = distance_1.x * mod_x;
                                        }
                                        if (distance_2.y >= moves){
                                            Y_dist = moves * mod_y;
                                        }
                                        else{
                                            // within reach
                                            move_goal++ ;
                                            Y_dist = distance_1.y * -mod_y;
                                        }

                                        moves = 0;
                                        if (distance_2.x <= moves && distance_2.y <= moves){
                                            move_goal = 2;
                                        }
                                        if (move_goal == 2){
                                            dest_obj = destination_obj;
                                        }
                                        if (move_goal == 0){
                                            dest_obj = Instantiate(indicator,transform.position +- new Vector3(X_dist,Y_dist,0),transform.rotation);
                                        }
                                    }   
                                }
                            }
                        }
                    }
                    if (dest_obj != null){
                        transform.position = Vector2.Lerp(transform.position, dest_obj.transform.position,5 * Time.deltaTime);
                        Vector2 distance = dest_obj.transform.position - transform.position;
                        if (distance.x < 0){
                            distance.x = -distance.x;
                        }
                        if (distance.y < 0){
                            distance.y = -distance.y;
                        }
                        if (distance.x < 0.05f && distance.y < 0.05f){
                            transform.position = dest_obj.transform.position;
                            Destroy(dest_obj);
                        }
                        for (int I = 0; I <= CNT_sh; I++){
                            GameObject grab_ship = ships[I];
                            comp.target = dest_obj;
                            grab_ship.transform.eulerAngles = new Vector3(0,0,Mathf.LerpAngle(grab_ship.transform.eulerAngles.z, compass.transform.eulerAngles.z,2 * Time.deltaTime));  
                        }      
                    }
                }      
            }
        }
        if (Input.GetKeyDown(KeyCode.Tab)){
            moves = 5;
                for (int I = 0; I <= CNT_PT_SAVE; I++){
                Destroy(path[I]);
            }
            path.Clear();
            last_pos = transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Space)){
            pause = -pause;
        }
    }
}
