using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class FxKontrol : MonoBehaviour
{

    Rigidbody Fizik;
    
    //oluşan lazerlerin öne gitmesi
    void Start()
    {
        Fizik = GetComponent<Rigidbody>();
        Fizik.velocity = transform.forward*15;
    }

   
}
