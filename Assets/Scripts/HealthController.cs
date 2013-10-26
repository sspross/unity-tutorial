using UnityEngine;
using System.Collections;

public class HealthController : MonoBehaviour {
	
	public float currentHealth = 5;
	
	private int numOfBlinks = 3;
	private float damageEffectPause = 0.1F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void ApplyDamage (float damage) {
		if (currentHealth > 0) {
			currentHealth -= damage;
			if (currentHealth < 0) {
				currentHealth = 0;
			}
			if (currentHealth == 0) {
				ResetartScene();
			} else {
				StartCoroutine(DamageEffect());
			}
		}
	}
	
	void ResetartScene () {
		Application.LoadLevel(Application.loadedLevel);
	}
	
	IEnumerator DamageEffect() {
		renderer.enabled = false;
		for (int i = 0; i < numOfBlinks; i++) {
			yield return new WaitForSeconds(damageEffectPause);
			renderer.enabled = true;
			yield return new WaitForSeconds(damageEffectPause);
			renderer.enabled = false;
		}
		yield return new WaitForSeconds(damageEffectPause);
		renderer.enabled = true;
	}	
}
