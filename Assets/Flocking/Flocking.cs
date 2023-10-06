using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocking : MonoBehaviour
{
	public Flock_Manager Flock_Manager;
	float speed;
	float timeMin = 0.3f;
	float timeMax = 0.8f;
	float waitTime = 0.5f;

	private Vector3 direction;

	void Start()
	{
		speed = Random.Range(Flock_Manager.minSpeed,
								Flock_Manager.maxSpeed);

	}
	// Update is called once per frame
	void Update()
	{
		transform.Translate(0, 0, Time.deltaTime * speed);

		waitTime -= Time.deltaTime;
		if (waitTime <= 0.0f)
		{
			ApplyRules();
			waitTime = Random.Range(timeMin, timeMax);
		}
		
		transform.rotation = Quaternion.Slerp(transform.rotation,
													  Quaternion.LookRotation(direction),
													  Flock_Manager.rotationSpeed * Time.deltaTime);
		transform.Translate(0.0f, 0.0f, Time.deltaTime * speed);
	}
	void ApplyRules()
	{
		Vector3 cohesion = Vector3.zero;
		int num = 0;
		foreach (GameObject go in Flock_Manager.allFish)
		{
			if (go != this.gameObject)
			{
				float distance = Vector3.Distance(go.transform.position,
												  transform.position);
				if (distance <= Flock_Manager.neighbourDistance)
				{
					cohesion += go.transform.position;
					num++;
				}
			}
		}
		if (num > 0)
			cohesion = (cohesion / num - transform.position).normalized * speed;

		Vector3 align = Vector3.zero;
		num = 0;
		foreach (GameObject go in Flock_Manager.allFish)
		{
			if (go != this.gameObject)
			{
				float distance = Vector3.Distance(go.transform.position,
												  transform.position);
				if (distance <= Flock_Manager.neighbourDistance)
				{
					align += go.GetComponent<Flocking>().direction;
					num++;
				}
			}
		}
		if (num > 0)
		{
			align /= num;
			speed = Mathf.Clamp(align.magnitude, Flock_Manager.minSpeed, Flock_Manager.maxSpeed);
		}
		Vector3 separation = Vector3.zero;
		foreach (GameObject go in Flock_Manager.allFish)
		{
			if (go != this.gameObject)
			{
				float distance = Vector3.Distance(go.transform.position,
												  transform.position);
				if (distance <= Flock_Manager.neighbourDistance)
					separation -= (transform.position - go.transform.position) /
								  (distance * distance);
			}
		}
		direction = (cohesion + align + separation).normalized * speed;
	}
}
