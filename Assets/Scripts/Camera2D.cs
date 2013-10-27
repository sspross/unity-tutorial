using UnityEngine;
using System.Collections;

public class Camera2D : MonoBehaviour {
	
	public Transform target;
	public int zOffset;
	public int minimumHeight = 0;
	
	private Vector3 position;
	private float currentY;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		position = target.position;
		position.z -= zOffset;
		
		currentY = target.position.y;
		
		if (currentY > minimumHeight) {
			position.y = currentY;	
		} else {
			position.y = minimumHeight;
		}
		
		transform.position = position;
	}
}
