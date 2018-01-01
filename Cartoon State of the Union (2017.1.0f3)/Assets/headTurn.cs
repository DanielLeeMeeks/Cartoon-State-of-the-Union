using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class headTurn : MonoBehaviour {

	[Header("Head")]
	//public bool headSmoothing = false;
	public Sprite [] headsN3;
	public Sprite [] headsN2, headsN1, heads0, heads1 ,heads2 ,heads3;
	public Sprite[][] heads;

	[Header("Eyes")]
	public Sprite [] headsN3_close;
	public Sprite [] headsN2_close, headsN1_close, heads0_close, heads1_close ,heads2_close ,heads3_close;
	public Sprite[][] heads_close;
	public bool autoBlink = true;
	bool blinking = false;
	public Text eyesDebugText;

	[Header("Mouth")]
	public Vector2 mouthTurn;
	public SpriteRenderer mouth;
	public Sprite[] mouths;
	public int mouthStep = 0;
	public float mouthSpeed = 0.25f;
	public float mouthTimer = 0;
	public Text mouthDebugText;

	[Header("Body")]
	public Sprite [] bodies;
	public SpriteRenderer body;
	public Text bodyDebugText;

	[Header("Debug Stuff")]
	//public float XInput = 0;
	//public float YInput = 0;
	public Text debugText;

	// Use this for initialization
	void Start () {
		heads = new Sprite[][] {headsN3, headsN2, headsN1, heads0, heads1, heads2, heads3};
		heads_close = new Sprite[][] {headsN3_close, headsN2_close, headsN1_close, heads0_close, heads1_close, heads2_close, heads3_close};
		if (autoBlink){StartCoroutine(startBlinking());}
	}
	
	// Update is called once per frame
	void Update () {
		//setHeadTurn(headSmoothing);
		//setMouth();
		//setBody();
	}

	public void setBlink(bool b){
		blinking = b;
	}

	IEnumerator startBlinking(){
		blinking = true;
		yield return new WaitForSeconds(0.25f);
		blinking = false;
		yield return new WaitForSeconds(UnityEngine.Random.Range(10, 31));
		StartCoroutine(startBlinking());
	}

	public void setBody(string id){
		if (id == "BodyUp"){
			body.sprite = bodies[0];
			bodyDebugText.text = "Body/Hands: Both Hands Up";
		} else if (id == "BodyRight"){
			body.sprite = bodies[1];
			bodyDebugText.text = "Body/Hands: Right Hand Up";
		} else if (id == "BodyDown"){
			body.sprite = bodies[2];
			bodyDebugText.text = "Body/Hands: Both Hands Down";
		} else if (id == "BodyLeft"){
			body.sprite = bodies[3];
			bodyDebugText.text = "Body/Hands: Left Hand Up";
		}
	}

	public void setMouth(bool open){
		if (open){

			if (mouthTimer < 0){
				if (mouthStep < 3){
					mouthStep++;
					mouth.sprite = mouths[mouthStep];
					mouthTimer = mouthSpeed;
					mouthDebugText.text = "Mouth (Up) Step: "+mouthStep;
				 }
			}
		}else{
			if (mouthTimer < 0){
				if (mouthStep > 0){
					mouthStep--;
					mouth.sprite = mouths[mouthStep];
					mouthTimer = mouthSpeed;
					mouthDebugText.text = "Mouth (Down) Step: "+mouthStep;
				}
			}
		}
		mouthTimer -= Time.deltaTime;
	}

	public void setHeadTurn(Vector2 headTurnValue){
		/*if (smoothing){
			if(Input.GetAxisRaw("Horizontal") > headTurnValue.x){headTurnValue.x = headTurnValue.x + headTurnSpeed;}
			else if (Input.GetAxisRaw("Horizontal") < headTurnValue.x){headTurnValue.x = headTurnValue.x - headTurnSpeed;}
			if(Input.GetAxisRaw("Vertical") > headTurnValue.y){headTurnValue.y = headTurnValue.y + headTurnSpeed;}
			else if (Input.GetAxisRaw("Vertical") < headTurnValue.y){headTurnValue.y = headTurnValue.y - headTurnSpeed;}
		}else{
			headTurnValue.x = Input.GetAxisRaw("Horizontal");
			headTurnValue.y = Input.GetAxisRaw("Vertical");
		}*/

		int XValue = Mathf.RoundToInt(headTurnValue.x * 3);
		int YValue = Mathf.RoundToInt(headTurnValue.y * 3);

		if (blinking){this.GetComponent<SpriteRenderer>().sprite = heads_close[3+XValue][3+YValue];eyesDebugText.text = "Eyes: Closed";}
		else{this.GetComponent<SpriteRenderer>().sprite = heads[3+XValue][3+YValue];eyesDebugText.text = "Eyes: Open";}

		//SET MOUTH POST

		Vector2 mouthPost = new Vector2 (0, 0);

		mouthPost.x = mouthTurn.x * ((XValue/3f)/2f);
		mouthPost.y = mouthTurn.y * ((YValue/3f)/2f);

		mouth.gameObject.transform.position = new Vector3 (mouthPost.x+this.transform.position.x, mouthPost.y-4.5f+this.transform.position.y, 0 + this.transform.position.z);

		if (debugText != null){
			/*if (smoothing){debugText.text = "REAL: ("+roundFloat(headTurnValue.x)+", "+roundFloat(headTurnValue.y)+") [SMOOTHING ENABLED: "+headTurnSpeed+"] | SPRITE: ("+XValue+", "+YValue+")" ;/*}
			else{*/debugText.text = "REAL: ("+roundFloat(headTurnValue.x)+", "+roundFloat(headTurnValue.y)+") | SPRITE: ("+XValue+", "+YValue+")" ;/*}*/
		}
	}

	private static string roundFloat(float number){
		int newNumber = Mathf.RoundToInt(number*100);
		if (newNumber >= 100){return "  "+number.ToString();}
		else if (newNumber >= 10){return "  0"+newNumber;}
		else if (newNumber > -1) {return "  00"+newNumber;}
		else if (newNumber > -10){return "-00"+Mathf.Abs(newNumber);}
		else if (newNumber > -100){return "-0"+Mathf.Abs(newNumber);}
		else {return newNumber.ToString();}
	}
}
