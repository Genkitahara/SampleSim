using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ChangeRcktPara : MonoBehaviour {
	
	public InputField i;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeEngine_SOF_time(){
		RocketParameter.Engine_SOF_time = double.Parse(i.text);
		//Debug.Log (RocketParameter.Engine_SOF_time);
	}

}
