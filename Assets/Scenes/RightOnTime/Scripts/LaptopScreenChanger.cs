using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaptopScreenChanger : MonoBehaviour
{
    RoundManager round;

    bool didInteract = false;

    public Material successScreenMaterial;
    public Material failScreenMaterial;

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
        if (round.didCompleteTask) {

            gameObject.GetComponent<Renderer>().material = successScreenMaterial;

        } else {
            
            gameObject.GetComponent<AudioSource>().Play();
            gameObject.GetComponent<Renderer>().material = failScreenMaterial;

        }

    }
}
