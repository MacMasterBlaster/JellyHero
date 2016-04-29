using UnityEngine;
using System.Collections;

public class GasPipeController : MonoBehaviour {

    public SwitchController lever;
    private ParticleSystem gas;
    private BoxCollider2D bc;
    void Awake()
    {
        gas = GetComponent<ParticleSystem>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Start()
    {

    }

    //IEnumerator CheckSwitchStatus()
    //{
    //    if (lever.CheckSwitchState())
    //    {
    //        gas.enableEmmision = false;
    //        bc.enabled = false;
    //    }
    //    else
    //    {
    //        gas.enable = true;
    //        bc.enabled = true;
    //    }
    //    yield return WaitForEndOfFrame();
    //}

}
