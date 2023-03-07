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
            // R�cup�ration de l'index de la sc�ne active.
            int indexScene = SceneManager.GetActiveScene().buildIndex;

            if (indexScene == 3)
            {

            }
            else
            {
                SceneManager.LoadScene(indexScene + 1);
            }
        }
    }
}
