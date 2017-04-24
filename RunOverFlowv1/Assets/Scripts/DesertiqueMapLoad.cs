using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DesertiqueMapLoad : MonoBehaviour {
    GameObject target;
    
    public void loadmap()
    {
        target = GameObject.FindGameObjectWithTag("musique");
        Destroy(target);
        SceneManager.LoadScene("Mapcanyon");


    }

}
