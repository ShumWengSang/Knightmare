using UnityEngine;
using System.Collections;

public class RadioButton : MonoBehaviour {
	bool activate;
	// Use this for initialization
	void Start () {
		activate = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetActive(bool nactive)
	{
		activate = nactive;
	}
}
