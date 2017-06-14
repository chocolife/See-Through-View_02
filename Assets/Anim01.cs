using UnityEngine;
using System.Collections;

public class Anim01 : MonoBehaviour {

    public Camera anim_cam;
    public Camera top_camera;
    public Camera side_camera;
    public GameObject cam_parent;
    Vector3[] pos_path = new Vector3[4];
    Vector3[] rot_path = new Vector3[3];

	// Use this for initialization
	void Start () {
        anim_cam.enabled = false;

        pos_path[0] = new Vector3(0f, 1.25f, -0.6f);
        pos_path[1] = new Vector3(0f, 1.25f, -2.5f);
        pos_path[2] = new Vector3(0f, 6.0f, -6.8f);
        pos_path[3] = new Vector3(0f, 7.8f, -8.6f);


	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnClick ()
    {
        top_camera.enabled = false;
        side_camera.enabled = false;
        anim_cam.enabled = true;
        anim_cam.transform.position = pos_path[0];
        anim_cam.transform.eulerAngles = new Vector3(0, 0, 0);

        iTween.MoveTo(anim_cam.gameObject, iTween.Hash(
            "path", pos_path,
            "time", 2,
            "easetype", iTween.EaseType.easeInOutSine
            ));

        iTween.RotateTo (anim_cam.gameObject, iTween.Hash (
            "rotation", new Vector3(40, 0, 0),
            "time", 1.4f,
            "EaseType", iTween.EaseType.easeInOutSine));
    }
}
