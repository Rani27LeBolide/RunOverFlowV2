using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMontagnusMulti : MonoBehaviour
{
    GameObject target;
    public void loadmap ()
    {
        target = GameObject.FindGameObjectWithTag("musique");
        Destroy(target);
        SceneManager.LoadScene("level1.1");
        
    }
	
}
