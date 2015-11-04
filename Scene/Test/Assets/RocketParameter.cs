using UnityEngine;
using System.Collections;

public class RocketParameter : MonoBehaviour {

	public static double Rocket_without_engine_mass = 20;
	public static double Befor_flight_wegiht = 0;
	public static double after_flight_wegiht = 0;
	public static double Rocket_diameter = 0.025;

	public static double Engine_before_weight = 0;
	public static double Engine_after_weight = 0;
	public static double Engine_SOF_time =  2;
	public static double Engine_burn_time = 0;
	public static string Selected_Engine = "Estes-A8";
	public static double[] Engine_Thrust_data = new double[128];

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
