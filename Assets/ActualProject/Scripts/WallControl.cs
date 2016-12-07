using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class WallControl : MonoBehaviour
{
    public Text restartText;
    public Text gameOverText;

    //The wall's current health point total
    public int currentHealth = 3;
    Material mat;

    private GameObject[] enemies;

    void Start()
    {
        //restart = false;
        restartText.text = "";
        gameOverText.text = "";
        mat = new Material(Shader.Find("Standard"));
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

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
            
            GameOver();
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



    void GameOver()
    {
        gameOverText.text = "Game Over!";

        restartText.text = "Press 'R' to restart";

        //restart = true;

        
        foreach (GameObject e in enemies)
            Destroy(e);
    }
}
