using UnityEngine;
using UnityEngine.UI;	
using System.Collections;

public class ParkPositionSelector : MonoBehaviour {

	public Camera camera;
	public GameObject select_btn_prefab;
	public GameObject[] select_btn;
	public GameObject park_panel;
	public GameObject park_position_area;

	public Canvas canvas;
	//public GameObject[] park_position_mark;

	private Transform[] mark_list;
	private StatusManager status_mgr;

	
	void Start () {

		park_panel.GetComponent<CanvasRenderer> ().SetAlpha (0);

		status_mgr = canvas.GetComponent<StatusManager> ();
		mark_list = park_position_area.GetComponentsInChildren<Transform>();

		int len = mark_list.Length;
		select_btn = new GameObject[len];

		for (int i = 0; i < len; i++) {
			select_btn[i] = Instantiate(select_btn_prefab);
			select_btn[i].transform.SetParent (park_panel.transform);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (status_mgr.current_camera.name == "Arround Camera" && status_mgr.park_status == true) {
			park_panel.SetActive(true);
		} else {
			park_panel.SetActive(false);
			return;
		}

		for (int i = 0; i < select_btn.Length ; i++) {
			Vector3 screenPos = camera.WorldToScreenPoint(mark_list[i].transform.position);
			select_btn[i].transform.position = screenPos;

        }

	
	}


	public void OnClick()
	{
		if (status_mgr.park_status == false) {
			park_panel.SetActive(true);
			status_mgr.park_status = true;
		} else {
			park_panel.SetActive(false);
			status_mgr.park_status = false;
		}
	}
}
