using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraCode : MonoBehaviour {

	public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt (target);
	}
}
