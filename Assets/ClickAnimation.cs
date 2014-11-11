using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using GAF.Core;

public class ClickAnimation : MonoBehaviour, IPointerClickHandler {

	public int timesToLoop = 0;
	public GameObject particleObject;
	public int pauseFrame = 0;

	bool paused = false;
	bool pausedDone = false;
	int timesLooped = 0;
	GAFMovieClip mc;

	bool activated = false;
	// Use this for initialization
	void Start () {
		mc = GetComponent<GAFMovieClip> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (!mc.isPlaying () &&  !activated &&!paused) {
						mc.gotoAndStop (1);
						activated= false;
			}
		if (!mc.isPlaying () && timesLooped==timesToLoop && activated && !paused) {
			//Callback code goes here
			activated = false;
			Debug.Log ("Loop call back is called");
			LoopCallback();
		}
		if (pauseFrame != 0) {
			if(!paused && mc.getCurrentFrameNumber() >= pauseFrame && !pausedDone){
				Debug.Log("Paused code running");
			paused = true;
			LoopCallback();
			mc.pause();
			}
		}
	}

	public void OnPointerClick(PointerEventData eventData){
		Debug.Log ("Clicked " + gameObject.name);
		if (!GameManager.disableInput) {
			Debug.Log("Animation not playing");
			activated = true;
			if(paused) pausedDone = true;
			paused =false;
			GameManager.disableInput = true;
			mc.play();
		}
		else{
			Debug.Log("Animation playing");
			Vector3 vect = eventData.worldPosition;
			vect.z = -9;
			Instantiate(particleObject, vect, Quaternion.identity);
		}
	}

	void LoopCallback(){
		GameManager.disableInput = false;
	}
}
