using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavoir : MonoBehaviour {

    private Animator animator;

    private void Awake() {
        animator.SetTrigger("die");
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
