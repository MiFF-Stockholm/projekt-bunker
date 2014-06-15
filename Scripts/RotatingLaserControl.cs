using UnityEngine;
using System.Collections;
using AssemblyCSharp;

public class RotatingLaserControl : MonoBehaviour {
	
	public bool instantDeath = false;
	[Range(1,5)]
	public int damageMultiplier = 1;
	[Range(1f,100f)]
	public float rotationSpeed = 35f;

	Transform laserRay;

	void Start () {
		laserRay = transform.parent.FindChild("LaserRay").transform;
		laserRay.renderer.enabled = true;
	}
	
	void Update () {
		transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
//		Debug.DrawRay(transform.position, -transform.forward.normalized * 100, Color.green);

		Ray ray = new Ray (transform.position, -transform.forward);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, 100)) {
			//positionera strålen mittemellan origo och träffpunkten
			laserRay.transform.position = Vector3.Lerp(transform.position, hit.point, 0.5f);

			//skala cylindern mellan origo och träffpunkten delat med 2 (eftersom objekt skalas dubbelt eller åt båda hållen)
			Vector3 scale = laserRay.localScale;
			scale.y = Vector3.Distance(transform.position, hit.point)/2.0f;
			laserRay.localScale = scale;

			//rikta cylindern i ray:ens riktning
			laserRay.rotation = Quaternion.LookRotation(laserRay.transform.position - hit.point);
			laserRay.RotateAround(laserRay.transform.position, transform.right, 90f);

			if (hit.collider.tag == "Player" || hit.collider.tag == "Enemy") {
				if (instantDeath) { //om instant death, döda den träffade
					Killable target = hit.collider.GetComponent(typeof(Killable)) as Killable;
					target.kill();
				} else { //om icke instant death, get spelaren "damage" antal skada per sekund (fördröjd 0.2 sek)
					//damage = (int)(100f * Time.deltaTime);
					//Debug.Log("Damage: " + damage + " (deltatime: " + Time.deltaTime + ")");
					hit.collider.GetComponent<HealthControlScript>().meleeHit(0.5f * damageMultiplier);
				}
			}
		}
	}
}
