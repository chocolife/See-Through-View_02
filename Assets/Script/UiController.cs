using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class UiController : MonoBehaviour
{
	
	private Text pos_x;
	private Text pos_y;
	private Text pos_z;

	public Button myButton;
	public Canvas canvas;

	public GameObject field_pos_x;
	public GameObject field_pos_y;
	public GameObject field_pos_z;
	public GameObject field_transfar_status;

	private GameObject main_camera;
	private GameObject top_camera;
	private GameObject transfar_camera;

	private Vector3 cameraPos;
	private Vector3 cameraRot;
	
	private Animator transfar_anim;
	private GameObject rotation_status;


	
	void Start () 
	{

		main_camera = GameObject.Find ("Main Camera");
		top_camera = GameObject.Find ("CamParent/Top Camera"); 
		transfar_camera = GameObject.Find ("Transfar Camera");

		transfar_camera.GetComponent<Camera>().enabled = true;
		main_camera.GetComponent<Camera>().enabled = false;
		top_camera.GetComponent<Camera>().enabled = false;

		transfar_anim = transfar_camera.GetComponent<Animator>();

		pos_x = field_pos_x.GetComponent<Text>();
		pos_y = field_pos_y.GetComponent<Text>();
		pos_z = field_pos_z.GetComponent<Text>();


		field_transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (0);

	}



	void Update ()
	{

		//if (transfar_anim.GetCurrentAnimatorStateInfo (0).IsName ("Camera Start"))
		if (transfar_anim.GetCurrentAnimatorStateInfo (0).normalizedTime < 1.0f)
		{
			field_transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
			//Debug.Log ("Animating!!!!!!");
		}
		else
		{
			field_transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (0);
			//Debug.Log ("Stopped!!!!!!");
			main_camera.GetComponent<Camera>().enabled = true;
			transfar_camera.GetComponent<Camera>().enabled = false;
		}

		/*
		if (animation.IsPlaying ("Camera Start")) {
			transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (1.0f);
		} else {
			transfar_status.GetComponent<CanvasRenderer> ().SetAlpha (0);
		}
		*/

		cameraRot  = main_camera.transform.eulerAngles;
		pos_x.text = cameraRot.x.ToString();
		pos_y.text = cameraRot.y.ToString();
		pos_z.text = cameraRot.z.ToString();
	
	}
}
