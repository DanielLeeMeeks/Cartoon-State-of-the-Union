using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class watermark : MonoBehaviour {

	int step = 0;
	public string [] watermarks;

	// Use this for initialization
	void Start () {
		StartCoroutine(go());
	}
	
	IEnumerator go (){

		this.GetComponent<Text>().text = watermarks[step];

		yield return new WaitForSeconds(15);

		step++;

		if (step >= watermarks.Length){
			step = 0;
		}

		StartCoroutine(go());

	}
}
