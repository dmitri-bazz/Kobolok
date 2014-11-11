using UnityEngine;
using System.Collections;

public class SelfKill : MonoBehaviour {

	public float duration = 5f;

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingOrder = 20;
		Invoke ("Kill", duration);
	}

	void Kill(){
		GameObject.Destroy (gameObject);
	}
}
