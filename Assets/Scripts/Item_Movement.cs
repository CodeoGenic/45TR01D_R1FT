using UnityEngine;
using System.Collections;

public class Item_Movement : MonoBehaviour {

    // Use this for initialization
    public Rigidbody rigidbody;
    public float speed = 10;
    public float x = 0;
    public float y = 0;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(x, y, Time.deltaTime * (-speed));
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //Rotate around the center of the of the object
        //transform.Translate(rigidbody.centerOfMass*Time.fixedDeltaTime);
        transform.Rotate(new Vector3(0, 0, 45) * Time.fixedDeltaTime);
        //transform.Translate(-rigidbody.centerOfMass*Time.fixedDeltaTime);		
    }
   
}
