using UnityEngine;
using System.Collections;

public class InventoryScreenController : MonoBehaviour {

    public Animator animator;

	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
            animator.SetBool("isOpen", !animator.GetBool("isOpen"));
        }
	}
}
