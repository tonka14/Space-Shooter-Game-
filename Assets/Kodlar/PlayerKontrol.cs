using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]

public class PlayerKontrol : MonoBehaviour
{

    Rigidbody Fizik;
    [SerializeField] [Range(1, 100)] private int Hiz = 5;
    float MinX = -6, MaxX = 6, MinZ = -9, MaxZ = 9;
    float atestime = 0;
    public GameObject lazer;
    public Transform lazercik;
    public GameObject patlama;
    GameObject OyunKontrol;
    OyunKontrol Kontrol;

   

    void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");
        Kontrol = OyunKontrol.GetComponent<OyunKontrol>();
        Fizik = GetComponent<Rigidbody>();
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("sinir") && !other.gameObject.CompareTag("lazer") )
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(patlama, transform.position, Quaternion.identity);
            Kontrol.OyunBitti();
            
        }
    }
    
    private void Update()
    {
        if (Input.GetButton("Fire1") && Time.time>atestime)
        {
            atestime = Time.time + 0.25f;
            Instantiate(lazer, lazercik.position, Quaternion.identity);

        }
    }
    
    void FixedUpdate()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector3 vec = new Vector3(Horizontal, 0, Vertical);

        updateplayermovement(vec);

    }

    private void updateplayermovement(Vector3 vec)
    {
        Fizik.velocity = vec * Hiz;

        Fizik.position = new Vector3
         (
            Mathf.Clamp(Fizik.position.x, MinX, MaxX),
            0.0f,
            Mathf.Clamp(Fizik.position.z, MinZ, MaxZ)
         );

        Fizik.rotation = Quaternion.Euler(0, 0, Fizik.velocity.x * -3);
    }
}
