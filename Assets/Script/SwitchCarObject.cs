using UnityEngine;
using System.Collections;

public class SwitchCarObject : MonoBehaviour
{

	public GameObject carInterior;
	public GameObject carExterior;

	public Camera side_camera;
	private Camera main_camera;
	private Camera top_camera;

	public Vector3 pos;

	private bool bodyTransparent = true;

	private StatusManager statusManager;


	// Use this for initialization
	void Start ()
	{
		statusManager = GameObject.Find("Canvas").GetComponent<StatusManager>();

		carInterior = GameObject.Find("Interior");
		carExterior = GameObject.Find ("Exterior_Main_01");


		main_camera = GameObject.Find ("Main Camera").GetComponent<Camera>();
		top_camera = GameObject.Find ("CamParent/Top Camera").GetComponent<Camera>();
	
		statusManager.interior_visible = false;
	}


	
	void Update ()
	{
		pos = this.transform.position;
		Debug.Log (statusManager.interior_visible);
		//Is camera located inside?
		if ((pos.z > -3 && this.enabled == true) && top_camera.enabled == false && side_camera.enabled == false) 
		{
			if (statusManager.interior_visible == false)
			{
				foreach (Transform car_child in carInterior.transform) 
				{
					car_child.GetComponent<Renderer> ().enabled = true;
					iTween.FadeTo(car_child.gameObject, iTween.Hash("alpha", 0.6f, "time", 2.0f));
				}
				

				foreach (Transform car_child in carExterior.transform) 
				{
					//car_child.GetComponent<Renderer> ().enabled = false;
					if (car_child.name != "Window") 
					{
						iTween.FadeTo(car_child.gameObject, iTween.Hash("alpha", 0, "time", 0.5f));
					}
				}

				statusManager.interior_visible = true;
			}
		}
		else
		{
			if (statusManager.interior_visible == true)
			{	
				foreach (Transform car_child in carInterior.transform)
				{
					car_child.GetComponent<Renderer> ().enabled = false;
					iTween.FadeTo(car_child.gameObject, iTween.Hash("alpha", 0, "time", 0));
				}
				
				foreach (Transform car_child in carExterior.transform)
				{
					car_child.GetComponent<Renderer> ().enabled = true;
					if (car_child.name != "Window") 
					{
						iTween.FadeTo(car_child.gameObject, iTween.Hash("alpha", 1, "time", 0));
					}

				}
				statusManager.interior_visible = false;
			}
		}

	}
}