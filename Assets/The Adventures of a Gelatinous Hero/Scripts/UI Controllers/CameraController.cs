using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float speed = 3;

    public Transform target;

    void Start () {
	}
	
	void FixedUpdate () {
		if (target.gameObject.activeSelf) {
			Vector3 pos = Vector3.Lerp(
				transform.position, 
				target.transform.position, 
				Time.deltaTime * speed
			);
			pos.z = transform.position.z;
			transform.position = pos;
		}
	}
}
