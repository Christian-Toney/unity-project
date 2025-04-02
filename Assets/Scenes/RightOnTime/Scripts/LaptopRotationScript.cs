using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopRotationScript : MonoBehaviour
{
    RoundManager round;

    bool didInteract = false;

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
        Animator animator = GetComponent<Animator>();
        Debug.Log("Ok");
        animator.SetBool("DidLose", !round.didCompleteTask);

    }
}
