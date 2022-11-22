using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatform : MonoBehaviour
{
    public float thrustForce;
    public new Vector3 force;
    public bool jump;
    public int prueba;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();



            switch (prueba)
            {
                case 0:
                    //jjump
                    rb.velocity = force;

                    break;
                case 1:
                    rb.AddForce(force,ForceMode.Impulse);

                    break;
                case 2:
                    rb.AddForce(force, ForceMode.Impulse);


                    break;
                case 3:
                    rb.AddForce(force, ForceMode.Acceleration);
                    break;
                case 4:
                    rb.AddForce(force, ForceMode.VelocityChange);
                    break;
                case 5:
                    rb.AddRelativeForce(force, ForceMode.Impulse);

                    break;
                case 6:
                    rb.WakeUp();

                    break;

                default:
                    break;
            }
            /*if (jump)
            {

                //Vector3 bounceDirection = rb.velocity;
                    rb.velocity = force;

                //rb.AddForce(new Vector3(0,10,0) * bounceAmount);
            }
            else
            {
                rb.WakeUp();
                    
                    
                   // (force * thrustForce, ForceMode.Impulse);
                //rb.AddForce(new Vector3(0,10,0) * bounceAmount);
            }*/

        }




    }


    private void OnTriggerStay(Collider other)
    {
        /*if (other.tag == "Player")
        {
            Rigidbody rb = other.gameObject.GetComponent<Rigidbody>();
            rb.AddForce(force, ForceMode.VelocityChange);
        }*/
    }
}
