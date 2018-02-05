using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour {

    public void LoadScene(string name)
    {
        Application.LoadLevel(name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
