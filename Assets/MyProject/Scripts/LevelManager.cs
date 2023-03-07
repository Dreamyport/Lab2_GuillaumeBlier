using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            // Récupération de l'index de la scène active.
            int indexScene = SceneManager.GetActiveScene().buildIndex;

            if (indexScene == 1)
            {

            }
            else
            {
                SceneManager.LoadScene(indexScene + 1);
            }
        }
    }
}
