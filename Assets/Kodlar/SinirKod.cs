using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinirKod : MonoBehaviour
{
   

    //ekrandan çıkan objelerin yok olması
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
