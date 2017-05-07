using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Animation))]
public class CameraController : MonoBehaviour
{

	private Animation animation;

	// Use this for initialization
	void Start ()
	{
		animation = GetComponent<Animation> ();
		animation.playAutomatically = false;
		//animation.wrapMode = WrapMode.Loop;
		//Debug.Log (animation.name);
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
