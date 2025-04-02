using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessCheck : MonoBehaviour
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

        if (Input.GetKeyDown(KeyCode.Space) && !didInteract) {

            didInteract = true;

            if (round.timeRemaining - 1f <= 0) {

                GameObject.FindGameObjectWithTag("WinSoundEffect").GetComponent<AudioSource>().Play();
                round.didCompleteTask = true;

            } else {

                GameObject.FindGameObjectWithTag("LoseSoundEffect").GetComponent<AudioSource>().Play();

            }

        }
        
    }
}
