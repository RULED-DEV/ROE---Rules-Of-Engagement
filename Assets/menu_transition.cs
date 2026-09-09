using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_transition : MonoBehaviour{ // this switches betwen various main menus

    public button start;
    public button start_test;
    public button return_test;
    public button start_test_campain;
    public button return_start_campain;

    int menu;

    public GameObject test_state;

    GameObject main_menu; // main menu
    GameObject campain_menu; // select campain
    GameObject campain_brief; // select map size, factions, captain, players etc

    void Start(){
        main_menu = gameObject.transform.GetChild(0).gameObject;
        campain_menu = gameObject.transform.GetChild(1).gameObject;
        campain_brief = gameObject.transform.GetChild(2).gameObject;
    }

    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
        if (menu == 0){
            // main menu
            if (start.click == 1){
                menu = 2; // campain select menu
                main_menu.SetActive(false);
                campain_menu.SetActive(true);
                start.click = 0;
            }
        }
        if (menu == 2){
            // campain select
            if (start_test.click == 1){
                menu = 3; // campain select menu
                campain_menu.SetActive(false);
                campain_brief.SetActive(true);
                start_test.click = 0;
            }
            if (return_test.click == 1){
                menu = 0; // return to main menu
                main_menu.SetActive(true);
                campain_menu.SetActive(false);
                return_test.click = 0;
            }
        }
        if (menu == 3){
            // modify campain
            if (start_test_campain.click == 1){
                menu = 300; // start new campain
                gameObject.SetActive(false);
                test_state.SetActive(true);
                start_test_campain.click = 0;
            }
            if (return_start_campain.click == 1){
                menu = 0; // return to main menu
                campain_brief.SetActive(false);
                main_menu.SetActive(true);
                return_start_campain.click = 0;
            }
        }
    }
}
