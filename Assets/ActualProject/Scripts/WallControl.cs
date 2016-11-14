using UnityEngine;
using System.Collections;

public class WallControl : MonoBehaviour
{
    //The wall's current health point total
    public int currentHealth = 3;
    Material mat = new Material(Shader.Find("Standard"));

    void Start()
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        
        mat.color = Color.white;
        //assign the material to renderer
        mr.material = mat;
    }


    public void Damage(int damageAmount)
    {
        //subtract damage amount when Damage function is called
        currentHealth -= damageAmount;

        //Check if health has fallen below zero
        if (currentHealth <= 0)
        {
            //if health has fallen below zero, deactivate it 
            gameObject.SetActive(false);
        }
        
        if (currentHealth >= 0)
        {
            TextureChange(currentHealth);
        }
    }



    void TextureChange(int currentHealth)
    {
        if (currentHealth == 3)
        {
            mat.color = Color.white;
        }
        if (currentHealth == 2)
        {
            mat.color = Color.blue;
        }
        if (currentHealth == 1)
        {
            mat.color = Color.red;
        }
    }
}
