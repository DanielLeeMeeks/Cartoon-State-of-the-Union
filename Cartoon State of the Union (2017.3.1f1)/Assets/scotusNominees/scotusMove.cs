using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scotusMove : MonoBehaviour {

    public Vector3 sidePost, podPost;
    public GameObject trump;
    public SpriteRenderer mouth, suit;
    public int id;
    public controler c;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { hide(); }

        if (Input.GetKeyDown(KeyCode.W) && id == 1) {
            show();
        } else if (Input.GetKeyDown(KeyCode.E) && id == 2) {
            show();
            //moveToPod();
        }
        else if (Input.GetKeyDown(KeyCode.R) && id == 3)
        {
            show();
        }
        else if (Input.GetKeyDown(KeyCode.T) && id == 4)
        {
            show();
        }
        /*
        if (Input.GetKeyDown(KeyCode.Alpha1) && id == 1) { moveToPod(); }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && id == 2) { moveToPod(); }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && id == 3) { moveToPod(); }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && id == 4) { moveToPod(); }

        if (Input.GetKeyDown(KeyCode.Alpha0)) { moveToSide(); }*/
    }

    public void moveToPod()
    {
        this.transform.position = podPost;
        trump.transform.position = sidePost;
        //c.switchTalker(id);
    }

    public void moveToSide() {
        trump.transform.position = podPost;
        this.transform.position = sidePost;
       // c.switchTalker(0);
    }

    public void hide() {
        mouth.enabled = false;
        suit.enabled = false;
    }
    public void show() {
        mouth.enabled = true;
        suit.enabled = true;
    }
	
}
