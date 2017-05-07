using UnityEngine;
using UnityEngine.UI;

public class FadeController : MonoBehaviour {

	private bool isOpening;
	private float fadeTime;

	void Start ()
	{
		//Invoke("FadeIn", 2f);
		//Invoke("FadeOut", 5f);

		isOpening = false;

		//this.GetComponent<Image> ().color = new Color(0, 0, 1.0f, 1.0f);
		this.GetComponent<FadeController> ().FadeOut();
	}

	public void FadeIn()
	{
		iTween.ValueTo(gameObject, iTween.Hash("from", 0f, "to", 1f, "time", 0.7f, "onupdate", "SetValue"));

	}


	public void FadeOut()
	{
		fadeTime = 0.7f;
		if (isOpening) {
			fadeTime = 2.0f;
		}
		iTween.ValueTo(gameObject, iTween.Hash("from", 1f, "to", 0f, "time", fadeTime, "onupdate", "SetValue"));
		isOpening = false;
	}


	private void SetValue(float alpha)
	{
		// iTweenで呼ばれたら、受け取った値をImageのアルファ値にセット
		gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(0,0,0, alpha);
	}
}