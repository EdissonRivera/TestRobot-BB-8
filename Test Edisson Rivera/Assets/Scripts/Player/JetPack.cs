using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JetPack : MonoBehaviour
{
    [SerializeField] float maxFuel = 4f;
    [SerializeField] float thrustForce = 0.5f;
    [SerializeField] float currentFuel;
    [SerializeField] GameObject Player;
    Rigidbody rb;
    Transform groundedTransform;
    public Transform[] effect;
    float time = 0.5f;
    public PlayerUI UI;

    void Start()
    {
        rb = Player.GetComponent<Rigidbody>();
        groundedTransform = rb.transform;
        currentFuel = maxFuel;
    }

    void Update()
    {
        if (Input.GetAxis("Jump") > 0f && currentFuel > 0f )
        {
            if (time < 1)
            {
                time += Time.deltaTime;
                Effect(true);
            }
            if (time > 1)
            {
                currentFuel -= Time.deltaTime;
                rb.AddForce(rb.transform.up * thrustForce, ForceMode.Impulse);
                Effect(true);
                UI.imgFuel.fillAmount -= 1.0f / maxFuel * Time.deltaTime;
            }
        }
        else if(Physics.Raycast(groundedTransform.position,Vector3.down, 1, LayerMask.GetMask("Ground"))&& currentFuel < maxFuel)
        {
            currentFuel += Time.deltaTime;
            Effect(false);
            time = 0;
            UI.imgFuel.fillAmount += 1.0f / maxFuel * Time.deltaTime;
        }
        else
        {
            Effect(false);
        }

    }


    void Effect(bool particle)
    {
        if(particle)
            for (int i = 0; i < effect.Length; i++)
            {
                foreach (Transform item in effect[i])
                {
                    item.GetComponent<ParticleSystem>().Play();
                }
            }
        else
            for (int i = 0; i < effect.Length; i++)
            {
                foreach (Transform item in effect[i])
                {
                    item.GetComponent<ParticleSystem>().Stop();
                }
            }
    }
}
