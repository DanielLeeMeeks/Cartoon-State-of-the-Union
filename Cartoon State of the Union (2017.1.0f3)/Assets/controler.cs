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

	// Use this for initialization
	void Start () {
		activePerson = people[0];
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown(KeyCode.Alpha1)){people[0] = activePerson;}
		else if (Input.GetKeyDown(KeyCode.Alpha2)){people[1] = activePerson;}

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
}
