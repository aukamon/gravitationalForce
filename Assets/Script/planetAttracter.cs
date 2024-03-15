using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetAttracter : MonoBehaviour
{

    public Rigidbody rb;
    
    private const float G = 6.67f;
    
    public static List <planetAttracter>  pAttracter;

    void AttracterFormula(planetAttracter Other)
    {
        //F = G (m1*m2)/d^2
        Rigidbody rbOther = Other.rb;
        Vector3 direction = rb.position - rbOther.position;
        float distance = direction.magnitude;

        float forceMagnitude = G * (rb.mass * rbOther.mass) / Mathf.Pow(distance, 2);

        Vector3 forceDir = direction.normalized * forceMagnitude;
        rbOther.AddForce(forceDir);

    }
    void FixedUpdate()
    {
        foreach (var attracter in pAttracter)
        {
            if(attracter != this)
            {
                AttracterFormula(attracter);
            }
        }
    }
    private void OnEnable()
    {
        if (pAttracter == null)
        {
            pAttracter = new List<planetAttracter>();
        }
        pAttracter.Add(this);
    }
}
