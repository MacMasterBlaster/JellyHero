using UnityEngine;
using System.Collections;
using Paraphernalia.Components;
using Paraphernalia.Utils;

//[RequireComponent(typeof())]
public class TeleportationController : MonoBehaviour {

	public Vector2 destination = Vector2.zero;

	void OnTriggerEnter2D(Collider2D collider){
		collider.gameObject.transform.position = destination;
        AudioManager.PlayEffect("DrainTeleport");
	}
}
