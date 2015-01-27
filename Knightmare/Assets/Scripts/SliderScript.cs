using UnityEngine;
using System.Collections;

public class SliderScript : MonoBehaviour {
	public float maxValue=100;
	public float minValue=0;
	public float currentValue=0;
	float targetValue;
	public GameObject sliderKnob;
	public Vector3 minPos;
	public Vector3 maxPos;
	public float length;
	// Use this for initialization
	void Start () 
	{
		minPos = this.transform.position;
		minPos.x=this.transform.position.x - this.transform.localScale.x * 0.5f;
		maxPos = this.transform.position ;
		maxPos.x = this.transform.position.x + this.transform.localScale.x * 0.5f;
		length = this.transform.localScale.x;
		minPos.z = sliderKnob.transform.position.z;
		maxPos.z = sliderKnob.transform.position.z;
		//sliderKnob.transform.position.Set (minPos.x, minPos.y, minPos.z);
		sliderKnob.transform.position = new Vector3 (minPos.x, minPos.y, minPos.z);
		targetValue = currentValue;
	}

	public void MoveKnob(Vector3 position)
	{
		Vector3 worldPos=Camera.main.ScreenToWorldPoint((Vector3)(position));
		{
			//Camera.main.ScreenToWorldPoint(Input.GetTouch(0)
			Vector3 dir=new Vector3(worldPos.x-sliderKnob.transform.position.x,0,0);
			//newPos.x=touch.position.x;
			//newPos.y/=Screen.height;
			Vector3 newPos=sliderKnob.transform.position+dir;
			if(newPos.x<maxPos.x&&newPos.x>minPos.x)
			{
				//sliderKnob.transform.position=newPos;
				//newPos.z=sliderKnob.transform.position.z;
				float nPosRatio=(newPos.x-minPos.x)/(maxPos.x-minPos.x);
				targetValue=minValue+(maxValue-minValue)*nPosRatio;
				currentValue=minValue+(maxValue-minValue)*nPosRatio;
			}
		}
	}

	// Update is called once per frame
	void Update () 
	{
		/*if(Input.GetKeyDown(KeyCode.K))
		{
			currentValue+=(maxValue-minValue)*0.01f;
		}
		if(Input.GetKeyDown(KeyCode.L))
		{
			currentValue-=(maxValue-minValue)*0.01f;
		}*/
		float difference =  targetValue-currentValue;
		if (Mathf.Abs (difference) > 1) 
		{
				currentValue += difference / Mathf.Abs (difference) * 100 * Time.deltaTime;
				float posRatio = currentValue / (maxValue - minValue);
				sliderKnob.transform.position = new Vector3 (minPos.x + length * posRatio, sliderKnob.transform.position.y, sliderKnob.transform.position.z);
		}
		else 
		{
			currentValue=targetValue;
		}

		//foreach(Touch touch in Input.touches)
		//{
		//}
	}
}
