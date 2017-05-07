using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StatusManager : MonoBehaviour
{
	public bool warn1_state = false;
	public bool warn2_state = false;

	public bool interior_visible = false;

	public string warnStr;

	//public int current_view_id;

	public Camera last_camera;
	public Camera current_camera;

	public GameObject field_last_cam;
	public GameObject field_current_cam;
	
	// Use this for initialization
	void Start ()
	{
		warnStr = "Start";

	}
	
	// Update is called once per frame
	void Update ()
	{
		field_last_cam.GetComponent<Text>().text = last_camera.name;
		field_current_cam.GetComponent<Text> ().text = current_camera.name;
	}
}

