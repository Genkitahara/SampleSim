using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TotalWeight_field : MonoBehaviour {

	public InputField i;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void WeightChange() {
		RocketParameter.Rocket_without_engine_mass = double.Parse (i.text);
	}
	public void DiameterChange() {
		RocketParameter.Rocket_diameter = double.Parse (i.text);
	}
}
