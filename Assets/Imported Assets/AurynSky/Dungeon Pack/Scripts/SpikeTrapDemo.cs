using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrapDemo : MonoBehaviour {

    //This script goes on the SpikeTrap prefab;
    [SerializeField] private float openTime = 2f;
    [SerializeField] private float closeTime = 2f;
    public Animator spikeTrapAnim; //Animator for the SpikeTrap;

    // Use this for initialization
    void Awake()
    {
        if (spikeTrapAnim == null)
        {
            //get the Animator component from the trap;
            spikeTrapAnim = GetComponent<Animator>();
        }
        //start opening and closing the trap for demo purposes;
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        //play open animation;
        spikeTrapAnim.SetTrigger("open");
        //wait 2 seconds;
        yield return new WaitForSeconds(openTime);
        //play close animation;
        spikeTrapAnim.SetTrigger("close");
        //wait 2 seconds;
        yield return new WaitForSeconds(closeTime);
        //Do it again;
        StartCoroutine(OpenCloseTrap());

    }
}