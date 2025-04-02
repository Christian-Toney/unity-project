using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCheck : MonoBehaviour
{

    bool didInteract = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (didInteract) {

            return;

        }

        if (Input.GetKeyDown(KeyCode.Space)) {

            gameObject.GetComponent<Animator>().SetTrigger("Clicked");
            didInteract = true;

        }

    }
}
