using UnityEngine;
using System.Collections;

public class SendDamageCollider : MonoBehaviour {
	
	public float damageValue = 1;
	public string tag = "Player";

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == tag) {
			other.gameObject.SendMessage("ApplyDamage", damageValue, SendMessageOptions.DontRequireReceiver);
		}
	}
}
