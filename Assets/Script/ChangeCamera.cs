using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeCamera : MonoBehaviour
{
	public GameObject canvas;
	private Camera last_camera;

	public Camera main_camera;
	public Camera top_camera;
	public Camera transfar_camera;
	public Camera side_camera;

	public GameObject carInterior;
	public GameObject carExterior;

	private Animator rotate_anim;
	private Animator transfar_anim;
	
	public GameObject fade_panel;
	
	// Use this for initialization
	void Start ()
	{
		//carInterior = GameObject.Find("Camry_Interior");
		//carExterior = GameObject.Find ("Camry_Colored");

		rotate_anim = GameObject.Find("CamParent").GetComponent<Animator>();

	}

	
	public void OnClick() 
	{
		last_camera = canvas.GetComponent<StatusManager> ().current_camera;

		fade_panel.GetComponent<Image> ().color = new Color(0, 0, 0, 1.0f);
		fade_panel.GetComponent<FadeController> ().FadeOut();


		//if (top_camera.enabled == false) 
		if (last_camera.name != "Top Camera")
		{	
			main_camera.enabled = false;
			transfar_camera.enabled = false;
			top_camera.enabled = true;
			side_camera.enabled = false;
			rotate_anim.speed = 1.0f;

			canvas.GetComponent<StatusManager> ().current_camera = top_camera;
		}
		else
		{
			main_camera.enabled = true;
			transfar_camera.enabled = false;
			top_camera.enabled = false;
			side_camera.enabled = false;
			rotate_anim.speed = 0;

			canvas.GetComponent<StatusManager> ().current_camera = main_camera;

		}

		canvas.GetComponent<StatusManager> ().last_camera = last_camera;
	}

	
	void Update () 
	{

	}
	

	public void FadeOut()
	{
		iTween.ValueTo(fade_panel, iTween.Hash(
			"from", 1f,
			"to", 0f,
			"time", 1f, 
			"onupdatetarget", fade_panel, 
			"onupdate", "SetValue"));
	}


	public void SetValue(float alpha)
	{
		fade_panel.GetComponent<Image> ().color = new Color(1.0f, 0, 0, 1.0f);
		// iTweenで呼ばれたら、受け取った値をImageのアルファ値にセット
		fade_panel.GetComponent<Image>().color = new Color(0,0,0, alpha);
	}
	

}
