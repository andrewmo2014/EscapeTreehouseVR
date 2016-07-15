using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class LockController : MonoBehaviour {

    public GameObject gate;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter( Collider col )
    {
        if( col.CompareTag( "key"))
        {
            Destroy(col.gameObject);
            GetComponent<Animator>().SetBool("Insert", true);
        }
    }

    public void ActivateGate()
    {
        if( gate.GetComponent<Animator>() != null)
        {
            Animator anim = gate.GetComponent<Animator>();
            anim.SetBool("Open", true);
        }
    }
}
