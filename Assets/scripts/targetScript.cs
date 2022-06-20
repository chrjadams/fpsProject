using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class targetScript : MonoBehaviour
{
    public float health = 50f;
    public Color myColor;
    MeshRenderer myRendererer; 

    public void TakeDamage(float amount)
    {

        health -= amount;
        if (health <= 0)
        {
            myRendererer = GetComponent<MeshRenderer>();
            changeColor();
        }
    }
    void changeColor()
    {
        Debug.Log("changeColor activated");
        myRendererer.material.color = Color.red;
        //Destroy(gameObject);

    }
}
