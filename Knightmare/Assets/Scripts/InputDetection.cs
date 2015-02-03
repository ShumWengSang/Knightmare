using UnityEngine;
using System.Collections;

public class InputDetection : MonoBehaviour {

	// Use this for initialization
	public CameraMovement targetScript;
	public SliderScript targetScript2;


	void Start () 	
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
#if UNITY_ANDROID
		foreach (Touch touch in Input.touches) {
			Vector3 worldPos = Camera.main.ScreenToWorldPoint ((Vector3)(touch.position));
			worldPos.z = 0;
			Collider[] hitCollider = Physics.OverlapSphere (worldPos, 0.5f);
			foreach (Collider col in hitCollider) 
			{
				if (col.gameObject.CompareTag ("slider")) 
				{
					foreach (Collider col2 in hitCollider)
					{
						if(col2.gameObject.CompareTag("sliderKnob"))
						{
							switch (touch.phase) 
							{
								case TouchPhase.Moved:
									col.gameObject.GetComponent<SliderScript> ().MoveKnob (touch.position);
								break;
								case TouchPhase.Began:
									break;
							}
						}
					}
				}
			}
		}
#endif
#if UNITY_EDITOR
		if(Input.GetMouseButtonDown(0))
		{
			Vector3 worldPos=Camera.main.ScreenToWorldPoint(Input.mousePosition);
			worldPos.z=0;
			Collider[] hitCollider=Physics.OverlapSphere(worldPos,0.5f);
			foreach(Collider col in hitCollider)
			{
				if(col.gameObject.CompareTag("slider"))
				{
					col.gameObject.GetComponent<SliderScript>().MoveKnob(Input.mousePosition);
				}
			}
			

		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			targetScript.PanToOption();
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			targetScript.PanToMain();	
		}
		if (Input.GetKeyDown (KeyCode.K)) 
		{
			targetScript2.currentValue--;	
		}
		if (Input.GetKeyDown (KeyCode.L)) 
		{
			targetScript2.currentValue++;	
		}
			#endif
	}
}
