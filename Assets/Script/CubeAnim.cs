using UnityEngine;
using System.Collections;

public class TestAnim : MonoBehaviour {
	
	Animation _anim;
	
	void Start () {
		_anim = GetComponent<Animation>();
		_anim.Play("CubeAnimation");

	}
	
	void OnGUI () {
		/*
		if (GUI.Button(new Rect(10, 10, 80, 40), "Anim1")) {
			_anim.Play("Anim1");
		}
		if (GUI.Button(new Rect(10, 50, 80, 40), "Anim2")) {
			_anim.Play("Anim2");
		}
		*/
	}
}