using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraControl : MonoBehaviour {

	public Vector4 [] cameraPositons;

	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		CameraByButtons(); 
		CameraByAxis();

	}

	public void setCameraPostition(int id){
		this.transform.position = new Vector3 (cameraPositons[id].x, cameraPositons[id].y, cameraPositons[id].z);
		this.GetComponent<Camera>().orthographicSize = cameraPositons[id].w;
	}

	public void CameraByAxis(){
		//Debug.Log(Input.GetAxisRaw("dPadX"));
		if (Input.GetAxisRaw("dPadX") > 0.5f){
			setCameraPostition(3);
		}else if (Input.GetAxisRaw("dPadX") < -0.5f){
			setCameraPostition(1);
		}else if (Input.GetAxisRaw("dPadY") > 0.5f){
			setCameraPostition(0);
		}else if (Input.GetAxisRaw("dPadY")< -0.5f){
			setCameraPostition(2);
		}
	}

	public void CameraByButtons(){
		if (Input.GetButtonDown("Camera CloseUp")){
			setCameraPostition(0);
		} else if (Input.GetButtonDown("Camera Wide")){
			setCameraPostition(1);
		} else if (Input.GetButtonDown("Camera Long")){
			setCameraPostition(2);
		} else if (Input.GetButtonDown("Camera 4")){
			setCameraPostition(3);
		}
	}

}
