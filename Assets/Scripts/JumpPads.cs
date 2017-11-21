using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class JumpPads : MonoBehaviour {

	public float jumpPad = 10;
	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider other)
	{

		if(other.gameObject.CompareTag("player"))
		{
			other.attachedRigidbody.AddForce(0, jumpPad, 0, ForceMode.Impulse);
		}
	}


}
