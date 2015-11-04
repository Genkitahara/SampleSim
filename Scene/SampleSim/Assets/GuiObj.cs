using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuiObj : MonoBehaviour {
	
	public Animator animator;
	bool TabStatus= true;


	// Use this for initialization
	void Start () {
		///animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void UppTabHideAndPull() {
		Debug.Log ("Hide/Pull Action");
		if (TabStatus) {
			animator.SetBool ("Flag", false);
			TabStatus = false;
		} else {
			animator.SetBool("Flag",true);
			TabStatus = true;

		}
	}
}
