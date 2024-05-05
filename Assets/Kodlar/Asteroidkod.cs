using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroidkod : MonoBehaviour
{

    Rigidbody Fizik;
    public GameObject patlama;

    GameObject OyunKontrol;
    OyunKontrol kontrol;
    
    //score
    //Asteroid Random Dönme & Aşa Yönde Hareket
    void Start()
    {

        float sayi = Random.Range(-2, -5);

        OyunKontrol = GameObject.FindGameObjectWithTag ("oyunkontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();


        Fizik = GetComponent<Rigidbody>();

        Fizik.angularVelocity = Random.insideUnitSphere * 5;

        Fizik.velocity = transform.forward * sayi; 
    }
    //Çarpmada Yok Olma & Diğer Objeyi Yok Etme & Patlama Efekti
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "lazer")
        {
            kontrol.ScoreArttir(10);
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position,transform.rotation);
        }
    }
}
