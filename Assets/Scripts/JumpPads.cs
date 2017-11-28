using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class JumpPads : MonoBehaviour {

	public float jumpPad = 10;
	private Rigidbody rb;
	private Vector3 temp;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("player"))
		{
			other.attachedRigidbody.AddForce(0, jumpPad, 0, ForceMode.Impulse);
			StartCoroutine(jumppad());
		}
	}
	
	IEnumerator jumppad()
    {
		transform.localScale += new Vector3 (0.5f,0.2f,0.2f);
        yield return new WaitForSeconds(0.1f);
		transform.localScale -= new Vector3 (0.5f,0.2f,0.2f);
    }
}
