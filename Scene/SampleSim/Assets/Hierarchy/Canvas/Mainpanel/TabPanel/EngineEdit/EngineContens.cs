using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngineContens : MonoBehaviour {

	public Text txt;
	public Button Btn;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EngineSelect(){
		RocketParameter.Selected_Engine = txt.text;
	}

}
