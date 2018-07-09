using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controler : MonoBehaviour {

	public Text eyesDebugText;
	public Text mouthDebugText;
	public Vector2 headTurnValue;
	public bool smoothing = true;
	public float headTurnSpeed; //If headSmothing is enabled
	public headTurn [] people;
	private headTurn activePerson;
    public scotusMove [] sm;

	public bool isTrumpHere = true;
    public bool forceSize = true;


	// Use this for initialization
	void Start () {
		activePerson = people[0];

        if (forceSize) {
            Screen.SetResolution(1920, 1080, false);
        }
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("TrumpToggle")){TrumpToggle();}

        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            foreach (scotusMove s in sm)
            {
                s.hide();
            }
            
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1)){switchTalker(0);}
		else if (Input.GetKeyDown(KeyCode.Alpha2)){switchTalker(1);}
		else if (Input.GetKeyDown(KeyCode.Alpha3)){switchTalker(2);}
        else if (Input.GetKeyDown(KeyCode.Alpha4)) { switchTalker(3); }
        else if (Input.GetKeyDown(KeyCode.Alpha5)) { switchTalker(4); }


        //Body
        if (Input.GetButtonDown("BodyUp")){
			activePerson.setBody("BodyUp");
		} else if (Input.GetButtonDown("BodyRight")){
			activePerson.setBody("BodyRight");
		} else if (Input.GetButtonDown("BodyDown")){
			activePerson.setBody("BodyDown");
		} else if (Input.GetButtonDown("BodyLeft")){
			activePerson.setBody("BodyLeft");
		}

		//mouth
		activePerson.setMouth(Input.GetButton("Mouth"));

		//Head
		if (smoothing){
			if(Input.GetAxisRaw("Horizontal") > headTurnValue.x){headTurnValue.x = headTurnValue.x + headTurnSpeed;}
			else if (Input.GetAxisRaw("Horizontal") < headTurnValue.x){headTurnValue.x = headTurnValue.x - headTurnSpeed;}
			if(Input.GetAxisRaw("Vertical") > headTurnValue.y){headTurnValue.y = headTurnValue.y + headTurnSpeed;}
			else if (Input.GetAxisRaw("Vertical") < headTurnValue.y){headTurnValue.y = headTurnValue.y - headTurnSpeed;}
		}else{
			headTurnValue.x = Input.GetAxisRaw("Horizontal");
			headTurnValue.y = Input.GetAxisRaw("Vertical");
		}
		activePerson.setHeadTurn(headTurnValue);

		//Blink
		activePerson.setBlink(Input.GetButton("Blink"));

	}

	public void TrumpToggle(){
		if (isTrumpHere){
			people[0].body.gameObject.SetActive(false);
			isTrumpHere = false;
		}else{
			people[0].body.gameObject.SetActive(true);
			isTrumpHere = true;
		}
	}

	public void switchTalker(int index){
		activePerson.deselect();
		activePerson = people[index];
		activePerson.select();

        if (index >= 1)
        {
            sm[index].moveToPod();
        }
        else { sm[1].moveToSide(); sm[2].moveToSide(); sm[3].moveToSide(); sm[4].moveToSide(); }

	}
}
