using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RadioControl : MonoBehaviour {
	List<GameObject> holder;
	GameObject curActive;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void AddGame(GameObject go)
	{
		holder.Add (go);
	}

	void SetActiveRadio(GameObject go)
	{
		foreach(GameObject temp in holder)
		{
			if(temp==go)
			{
				temp.GetComponent<RadioButton>().SetActive(true);
				curActive=temp;
			}
			else
				temp.GetComponent<RadioButton>().SetActive(false);
		}
	}
}
