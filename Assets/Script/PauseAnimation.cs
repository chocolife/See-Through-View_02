using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseAnimation : MonoBehaviour
{

	//private Animation anim;
	private Animator animator;
	private bool isStop;
	private Text pauseText;


	// Use this for initialization
	void Start ()
	{
		//anim = GameObject.Find("Main Camera").GetComponent<Animation>();

		isStop = false;

		foreach (Transform elem in this.transform)
		{
			if (elem.name == "Text")
			{
				pauseText = elem.GetComponent<Text> ();
				pauseText.text = "Pause";
			}
		}

		animator = GameObject.Find("Main Camera").GetComponent<Animator>();

		if (animator == null)
		{
			Debug.Log ("Animation not Found!!!!");
		}
		else
		{
			Debug.Log ("Animation Found!!!!");
			Debug.Log ("Animation Name : " + animator.name);
		}
	}



	// Update is called once per frame
	void Update ()
	{
	
	}



	public void OnClick()
	{
		if (isStop == false)
		{ 
			pauseText.text = "Resume";
			animator.speed = 0;
			isStop = true;
		}
		else
		{
			pauseText.text = "Pause";
			animator.speed = 1.0f;
			isStop = false;
		}
	}
}
