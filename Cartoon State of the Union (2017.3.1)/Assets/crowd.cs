using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class crowd : MonoBehaviour {

	Animator _a;
	public Text debug;
	public bool crowdStanding;
	public headTurn [] people;

	// Use this for initialization
	void Start () {
		_a = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Crowd Sit"))
        {
            crowdStanding = false;
            _a.SetTrigger("sit"); debug.text = "Crowd: Sitting";
            foreach (headTurn p in people)
            {
                p.sit();
            }
        }
        else if (Input.GetButtonDown("Crowd Clap"))
        {
            crowdStanding = true;
            _a.SetTrigger("clap"); debug.text = "Crowd: Clapping";
            foreach (headTurn p in people)
            {
                p.stand();
                p.clap();
            }
        }
        else if (Input.GetButtonDown("Crowd Clap Left")) {
            crowdStanding = true;
            _a.SetTrigger("clap_left"); debug.text = "Crowd: Clapping (Left)";
            people[1].sit();
            people[0].stand();
            people[0].clap();
        }
        else if (Input.GetButtonDown("Crowd Clap Right"))
        {
             crowdStanding = true;
            _a.SetTrigger("clap_right"); debug.text = "Crowd: Clapping (Right)";
            people[0].sit();
            people[1].stand();
            people[1].clap();

        }
    }
}
