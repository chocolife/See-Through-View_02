using UnityEngine;
using System.Collections;

public class SwitchSideView : MonoBehaviour {

	public GameObject canvas;

	public Camera top_camera;
	public Camera side_camera;

	private Camera last_camera;
	private Camera current_camera;

	private Transform start_trans;
	
	private Vector3 side_cam_pos;

	private Vector3 start_pos;
	private Quaternion start_rot;

	private bool is_left_side;
	

	// Use this for initialization
	void Start () {
		side_camera.enabled = false;
		side_cam_pos.x = -2.1f;
		side_cam_pos.y = 2.5f;
		side_cam_pos.z = -6.5f;

		//localPos = transform.InverseTransformPoint (side_pos);
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	public void OnClick()
	{

		current_camera = canvas.GetComponent<StatusManager> ().current_camera;
		last_camera = canvas.GetComponent<StatusManager> ().last_camera;
		
		if (this.name == "SW01") 
		{
			side_cam_pos.x = -2.1f;
		}
			else if (this.name == "SW02")
		{
			side_cam_pos.x = 2.1f;
		}


		//Transform last_cam_trans = top_camera.GetComponent<Transform> ();
		start_trans = current_camera.GetComponent<Transform> ();

		if (current_camera.name == "Side Camera")
		{
			start_trans = side_camera.GetComponent<Transform>();
		}

		start_pos = start_trans.position;
		start_rot = start_trans.rotation;
		top_camera.enabled = false;
		side_camera.GetComponent<Transform> ().position = start_pos;
		side_camera.GetComponent<Transform> ().rotation = start_rot;
		side_camera.enabled = true;
		
		iTween.MoveTo (side_camera.gameObject, iTween.Hash (
			"position", side_cam_pos,
			"time", 1.4f,
			"EaseType", iTween.EaseType.easeInOutCubic));

		iTween.RotateTo (side_camera.gameObject, iTween.Hash (
			"rotation", new Vector3(20,0,0),
			"time", 1.4f,
			"EaseType", iTween.EaseType.easeInOutCubic));


		canvas.GetComponent<StatusManager> ().current_camera = side_camera;
		canvas.GetComponent<StatusManager> ().last_camera = current_camera;

	}


	
}
