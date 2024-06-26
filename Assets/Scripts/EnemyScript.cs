using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 6);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Laser")
        {
            Debug.Log("colisão");
            Destroy(this);
            Destroy(col);
        }

        if(col.tag == "Player")
        {
            SceneManager.LoadScene("Game");
        }
    }
}
