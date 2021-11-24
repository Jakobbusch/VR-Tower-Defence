
using System;
using UnityEngine;

public class DartGun : MonoBehaviour
{


    public GameObject dartPrefab;

    public Transform barrelLocation;

    public float shotPower = 1000f;
    private GameObject dart;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger,OVRInput.Controller.RTouch))
        {
            Shoot();
        }
    }
    
    

    void Shoot()
    {
        dart = Instantiate(dartPrefab, barrelLocation.position, barrelLocation.transform.rotation);
        
        dart.GetComponent<Rigidbody>().AddForce(barrelLocation.forward *Time.deltaTime *  shotPower,ForceMode.Impulse);
        
        dart.transform.eulerAngles += new Vector3(0,90,90);
        
        Destroy(dart, 3f);
    }
}
