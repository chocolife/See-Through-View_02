using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class SwipeController : MonoBehaviour//, IBeginDragHandler, IDragHandler, IEndDragHandler, ICanvasRaycastFilter
{

	private Vector3 mousePos;
	private Vector3 panelOrigin;
	private int draggablePoint = 280;
	
	public GameObject textObj;
	public GameObject blurPanel;
	private RectTransform panelRect;
	
	public bool isDragging = false;

	public Camera mainCam;

	private RectTransform canvasRect;
	//private MenuExtractor menuExtractor;
	
	
	// Use this for initialization
	void Start () {
		canvasRect = this.GetComponent<RectTransform>();
		panelRect = blurPanel.GetComponent<RectTransform>();
		panelOrigin = panelRect.anchoredPosition;

		//menuExtractor = this.GetComponent<MenuExtractor>();
	}
	
	
	
	void Update ()
	{
		//Debug.Log(isDragging);
		//print (panelOrigin.y);
	}
	
	/*

	public void OnBeginDrag(PointerEventData data)
	{
		//print (menuExtractor.isExtracted);
		if (Input.mousePosition.y > draggablePoint && menuExtractor.isExtracted)
		{
			isDragging = true;
		}
	}
	
	
	public void OnDrag(PointerEventData data)
	{
		//Vector2 ViewportPosition = mainCam.WorldToViewportPoint(data.position);
		//verticalPos = (ViewportPosition.y * canvasRect.sizeDelta.y) - (canvasRect.sizeDelta.y * 0.5f);
		
		if (isDragging)
		{
			mousePos = Input.mousePosition;
			textObj.GetComponent<Text> ().text = mousePos.y.ToString ();
			//panelRect.anchoredPosition = new Vector3 (0, mousePos.y - 480, -1);
			panelRect.anchoredPosition = new Vector3 (0, (panelOrigin.y - (360 - mousePos.y) / 5), -1);
		}
	}

	
	
	public void OnEndDrag(PointerEventData data)
	{
		if (isDragging && menuExtractor.isExtracted)
		{
			isDragging = false;
			if (Input.mousePosition.y > 200)
			{
				iTween.MoveTo(blurPanel, iTween.Hash(
					"position", new Vector3(0, -250, 90),
					"easeType", iTween.EaseType.easeInOutSine,
					"time", 0.3f
				));
			} 
			else
			{
	
				iTween.MoveTo(blurPanel, iTween.Hash(
					"position", new Vector3(0, -1000, 90),
					"easeType", iTween.EaseType.easeInOutSine,
					"time", 0.3f
				));
				menuExtractor.isExtracted = false;
			}
		}
	}

	
	public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
	{
		return !isDragging;
	}
	
	
	public static bool IsRange(float a, float from, float to)
	{
		if (from < to) {
			return (from <= a && a <= to);
		} else {
			return (from >= a && a >= to);
		}
	}
	*/
	
}