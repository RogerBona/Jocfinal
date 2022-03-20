using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame(){
        SceneManager.LoadScene("Scene1");
    }

    public void PlayGame2(){
        SceneManager.LoadScene("Scene2");
    }

}
