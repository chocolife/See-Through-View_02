using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WarnSwitcher01 : MonoBehaviour
{
	private GameObject warnBtn01;
	private GameObject warnBtn02;

	private GameObject warnObj01;

	public Text warnBtnText01;

	public StatusManager statusManager;


	// Use this for initialization
	void Start ()
	{
		statusManager = GameObject.Find("Canvas").GetComponent<StatusManager>();
		warnObj01 = GameObject.Find ("Warn Object 01");
		 
		foreach (Transform elem in this.transform)
		{
			if (elem.name == "Text")
			{
				warnBtnText01 = elem.GetComponent<Text> ();
			}
		}

		statusManager.warn1_state = false;
		warnBtnText01.text = "OFF";
		ToggleObjectView (warnObj01, false);
		//warnBtnText01.text = statusManager.warnStr;
	}

	

	public void OnClick() 
	{
		if (statusManager.warn1_state)
		{
			statusManager.warn1_state = false;
			warnBtnText01.text = "OFF";
			ToggleObjectView (warnObj01, false);
		}
		else
		{
			statusManager.warn1_state = true;
			warnBtnText01.text = "ON";
			ToggleObjectView (warnObj01, true);
		}
	}


	void ToggleObjectView(GameObject obj, bool statusToChange)
	{
		foreach (Transform objChild in obj.transform)
		{
			objChild.GetComponent<Renderer> ().enabled = statusToChange;
		}
	}

	
	// Update is called once per frame
	void Update ()
	{
		
	}



}
	