using UnityEngine;
using System.Collections;

public class EngineView : MonoBehaviour {

	public Transform Tab;
	public Animator animator;
	bool TabStatus= true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void EngineTabHideAndPull() {
		Debug.Log ("Hide/Pull Action");
		if (TabStatus) {
			animator.SetBool ("Flag", true);
			Tab.transform.SetAsLastSibling();
			TabStatus = false;
		} else {
			animator.SetBool("Flag",false);
			TabStatus = true;

		}
	}
}
