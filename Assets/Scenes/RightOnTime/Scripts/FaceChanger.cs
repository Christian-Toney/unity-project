using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FaceChanger : MonoBehaviour
{

    RoundManager round;
    bool didInteract = false;
    public Material successFace;
    public Material failFace;

    // Start is called before the first frame update
    void Start()
    {
        round = GameObject.FindGameObjectWithTag("RoundManager").GetComponent<RoundManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (didInteract) {

            return;

        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            StartCoroutine(Check());

        }

    }

    IEnumerator Check() {

        yield return new WaitForSeconds(0.05f);
        gameObject.GetComponent<Renderer>().material = round.didCompleteTask ? successFace : failFace;
        
        Animator animator = GetComponent<Animator>();
        animator.SetBool("DidWin", round.didCompleteTask);
        animator.SetBool("DidLose", !round.didCompleteTask);

    }
}
