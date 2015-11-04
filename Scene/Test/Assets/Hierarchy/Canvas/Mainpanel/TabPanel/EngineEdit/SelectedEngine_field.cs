using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SelectedEngine_field : MonoBehaviour {

	public Text txt,txt2;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		//RocketParameter.Engine_SOF_time = double.Parse (txt2.text);
		txt.text = RocketParameter.Selected_Engine + "-" + txt2.text;
	}
}
