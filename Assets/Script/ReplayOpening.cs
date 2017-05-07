using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReplayOpening : MonoBehaviour
{
	
	public GameObject fade_panel;

	// Use this for initialization
	void Start ()
	{
		
	}


	// Update is called once per frame
	void Update ()
	{
		
	}


	public void OnClick()
	{
		//fade_panel.GetComponent<Image> ().color = new Color(0, 0, 0, 1.0f);
		//fade_panel.GetComponent<FadeController> ().FadeOut();
		Application.LoadLevel ("seethroughview_200");
	}
}