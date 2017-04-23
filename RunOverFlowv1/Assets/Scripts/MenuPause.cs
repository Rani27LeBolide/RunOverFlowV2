using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;




public class MenuPause : MonoBehaviour
{
    
    

    private bool isPaused = false; // Permet de savoir si le jeu est en pause ou non.
    

    void Start()
    {
        
    }


    void Update()
    {
        // Si le joueur appuis sur Echap alors la valeur de isPaused devient le contraire.
        if (Input.GetKeyDown(KeyCode.Escape))
            isPaused = !isPaused;
        
       

        
        


    }

      void  OnGUI()
    {
        if (isPaused)
        {

            // Si le bouton est présser alors isPaused devient faux donc le jeu reprend.
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 - 20, 80, 40), "Continuer"))
            {
                isPaused = false;
            }

            // Si le bouton est présser alors on ferme completement le jeu ou charge la scene "Menu Principal
            // Dans le cas du bouton quitter il faut augmenter sa postion Y pour qu'il soit plus bas
            if (GUI.Button(new Rect(Screen.width / 2 - 40, Screen.height / 2 + 40, 80, 40), "Quitter"))
            {

                SceneManager.LoadScene("Menu principal");
                PhotonNetwork.Disconnect();

            }
            
        }
        
    }

    
}
