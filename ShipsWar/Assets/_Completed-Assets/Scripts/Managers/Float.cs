using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {
	public float m_WaterLevel = 0f;
	public float m_FloatHeight = 2f;
	public float m_BounceDamp = 0.05f;
	public Vector3 m_BuoyancyCentreOffset;
	public Rigidbody m_Rb;

	private float m_ForceFactor;
	private Vector3 m_ActionPoint;
	private Vector3 m_UpLift;

	void Start() {
		m_Rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		m_ActionPoint = transform.position + transform.TransformDirection (m_BuoyancyCentreOffset);
		m_ForceFactor = 1f - ((m_ActionPoint.y - m_WaterLevel) / m_FloatHeight);

		if (m_ForceFactor > 0f) 
		{
			m_UpLift = -Physics.gravity * (m_ForceFactor - m_Rb.velocity.y * m_BounceDamp);
			m_Rb.AddForceAtPosition(m_UpLift,m_ActionPoint);
		}
	}
}
