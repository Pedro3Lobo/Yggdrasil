using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Man : MonoBehaviour
{
    public void Load_Scene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }
}
