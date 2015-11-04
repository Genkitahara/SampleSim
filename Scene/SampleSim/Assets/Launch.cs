using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Launch : MonoBehaviour {
	
	public Transform Rocket;
	public Animator UppTab,DownTabs;
	public Text FiringMass,InitialMass,Diameter,WithoutEngineMass,Dialog,SelectEngine;
	public Text Altitude_txt,FlightTime_txt,Velocity_txt,Accel_txt,Mass_txt;
	public Button btn;
	
	static bool LaunchReadyFlag = false;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	IEnumerator sleep(){
		double Burn_limit = RocketParameter.Engine_burn_time / 0.05;
		int burn_count = 0;

		double Drag = 0;
		double FlightTime = 0;
		double Accel = 0;
		double Velocity = 0;
		double Altitude = 0;
		double mass = RocketParameter.Befor_flight_wegiht * 0.001;
		double burning_mass = (RocketParameter.Rocket_without_engine_mass + RocketParameter.Engine_after_weight + ((RocketParameter.Befor_flight_wegiht - RocketParameter.after_flight_wegiht) / 2)) * 0.001;

		bool Launched_Flag = false;
		bool End_Flag = false;

		while(!End_Flag) {
			//##################################################################### mass;
			mass = RocketParameter.after_flight_wegiht * 0.001;
			if(burn_count <= Burn_limit)mass = burning_mass;
			mass = mass * 1000;
			Mass_txt.text = mass.ToString();
			mass = mass / 1000;
			//##################################################################### Drag;
			Debug.Log("Velocity: "  + Velocity);
			Drag = -0.75 * 0.5 * 1.225 * Mathf.Abs((float)Velocity) * Velocity * (3.141592 * (Mathf.Pow((float)RocketParameter.Rocket_diameter,2)/4));
			Debug.Log ("Drag: " + Drag);
			//##################################################################### accel;
			Accel = ((0 + Drag)/mass) - 9.8;
			if(burn_count <= Burn_limit){
				Accel =(((RocketParameter.Engine_Thrust_data[burn_count]) + Drag )/ mass) -9.8; //Thrust Accel.
				Debug.Log ("Thrust: " + RocketParameter.Engine_Thrust_data[burn_count]);
				burn_count++;
			}
			//Accel = Accel - 9.8; //gravity Accel loss.
			Accel_txt.text = Accel.ToString();
			Debug.Log ("Accel: " + Accel);
			//##################################################################### FlightTime;
			FlightTime = FlightTime + 0.05;
			FlightTime_txt.text = FlightTime.ToString();
			yield return new WaitForSeconds(0.05f);
			//##################################################################### velocity;
			Velocity = Velocity + (Accel * 0.05);
			Velocity_txt.text = Velocity.ToString();
			//##################################################################### Altitude;
			Altitude = Altitude + (Velocity * 0.05) + ((0.5 * Accel) * (0.05 * 0.05));
			if(Altitude < 0) Altitude = 0;
			Rocket.localPosition = new Vector3(-200f, (float)Altitude, 0f);
			//Rocket.Translate(0,(float)Velocity,0);
			Altitude_txt.text = Altitude.ToString();
			//##################################################################### Other
			if(FlightTime > 5 && Altitude > 10)Launched_Flag = true;
			if(Launched_Flag && Altitude == 0) {
				End_Flag = true;}
		}
		btn.interactable = true;
	}
	public void Engine_data_import(){

		Debug.Log (RocketParameter.Selected_Engine);
		TextAsset txt = Resources.Load("text/" + RocketParameter.Selected_Engine) as TextAsset;
		string Enginedata = txt.text;
		string [] EngineLines = Enginedata.Split('\n');
		RocketParameter.Engine_burn_time = double.Parse(EngineLines [0]);
		int Engine_data_index = 0;

		for(double i=0; i < RocketParameter.Engine_burn_time;i = i+0.05){ //import Thrust data.
			string [] Engine_enable_data = EngineLines[Engine_data_index + 2].Split(',');
			RocketParameter.Engine_Thrust_data[Engine_data_index] = double.Parse(Engine_enable_data[1]);
			Engine_data_index++;
		}
		Debug.Log (Engine_data_index);
		RocketParameter.Engine_after_weight = double.Parse (EngineLines [Engine_data_index + 4]);
		FiringMass.text = RocketParameter.Engine_after_weight.ToString ();
		try{
		string [] Engine_enable_data2 = EngineLines[Engine_data_index + 6 + (int)RocketParameter.Engine_SOF_time].Split(',');
		RocketParameter.Engine_before_weight = RocketParameter.Engine_after_weight + double.Parse (Engine_enable_data2[1]);
		InitialMass.text = RocketParameter.Engine_before_weight.ToString (); 
		RocketParameter.Befor_flight_wegiht = RocketParameter.Rocket_without_engine_mass + RocketParameter.Engine_before_weight;
		RocketParameter.after_flight_wegiht = RocketParameter.Rocket_without_engine_mass + RocketParameter.Engine_after_weight;
		WithoutEngineMass.text = RocketParameter.Rocket_without_engine_mass.ToString();
		Diameter.text = RocketParameter.Rocket_diameter.ToString();
		SelectEngine.text = RocketParameter.Selected_Engine + "-" + RocketParameter.Engine_SOF_time.ToString ();
		LaunchReadyFlag = true;
		} catch {
			Debug.Log ("OK");
		}
	}
	public void Launch_program(){
	

		if (LaunchReadyFlag) {
			btn.interactable = false;
			StartCoroutine ("sleep");
		} else {
			Dialog.text =  "Press Prepare for launch";
		}
	}

}

/*TODO











*/


