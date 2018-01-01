using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crowd : MonoBehaviour {

	Animator _a;
	public Text debug;

	// Use this for initialization
	void Start () {
		_a = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Crowd Sit")){_a.SetTrigger("sit");debug.text = "Crowd: Sitting";}
		else if (Input.GetButtonDown("Crowd Clap")){_a.SetTrigger("clap"); debug.text = "Crowd: Clapping";}
	}
}
