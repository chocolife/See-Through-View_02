// Credit to damien_oconnell from http://forum.unity3d.com/threads/39513-Click-drag-camera-movement
// for using the mouse displacement for calculating the amount of camera movement and panning code.

using UnityEngine;
using System.Collections;

public class RotateController : MonoBehaviour
{

	private float turnSpeed = 5.0f;		// Speed of camera turning when mouse moves in along an axis
	private float panSpeed = 4.0f;		// Speed of the camera when being panned
	private float zoomSpeed = 4.0f;		// Speed of the camera going back and forth
	
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool isRotating;	// Is the camera being rotated?
	private bool isZooming;		// Is the camera zooming?

	private float initial_inertia = 1.0f;
	private float inertia;
	private float damping = 0.01f;

	private Vector3 rereasedMouseOrigin;
	private Vector3	holdingMouseOrigin;
	private bool isMouseDown_0;
	private Vector3 pos;

	public Camera mainCam; 
	private float currentSpeed;
	private float minSpeed;
	


	void Start ()
	{
		isRotating = false;
		minSpeed = 1.0f;

	}

	
	void Update () 
	{

		// Get the left mouse button
		if(Input.GetMouseButtonDown(0) && mainCam.enabled)
		{
			// Get mouse origin
			holdingMouseOrigin = Input.mousePosition;
			isMouseDown_0 = true;
			isRotating = true;
			inertia = initial_inertia;
		}
		
		// Get the right mouse button
		if(Input.GetMouseButtonDown(1))
		{
			// Get mouse origin
			//mouseOrigin = Input.mousePosition;
			isPanning = true;
		}
		
		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			//mouseOrigin = Input.mousePosition;
			isZooming = true;
			//Application.LoadLevel ("seethroughview");
		}
		


		// Disable movements on button release
		if (!Input.GetMouseButton (0)) 
		{
			isMouseDown_0 = false;
			if (inertia < 0) 
			{
				isRotating = false;
			}
			inertia -= damping;
			rereasedMouseOrigin = holdingMouseOrigin;
		}

		if (!Input.GetMouseButton(1)) isPanning = false;
		if (!Input.GetMouseButton(2)) isZooming = false;


		// Rotate camera along X and Y axis
		if (isRotating)
		{
			mouseOrigin = holdingMouseOrigin;
			if (!isMouseDown_0) 
			{
				mouseOrigin = rereasedMouseOrigin;
				 //pos = Camera.main.ScreenToViewportPoint(holdingMouseOrigin - mouseOrigin);
			}
			else
			{
				pos = mainCam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			}

			//transform.RotateAround(transform.position, transform.right, +pos.y * turnSpeed * inertia);
			transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed * inertia);

		}
		
		// Move the camera on it's XY plane
		if (isPanning)
		{
			Vector3 pos = mainCam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
			transform.Translate(move, Space.Self);
		}
		
		// Move the camera linearly along Z axis
		if (isZooming)
		{
			Vector3 pos = mainCam.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);
			
			Vector3 move = pos.y * zoomSpeed * transform.forward; 
			transform.Translate(move, Space.World);
		}
	}
}