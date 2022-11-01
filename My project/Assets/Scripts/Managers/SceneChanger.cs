using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameEvent changeScene;
    public int sceneIndex;

    public void ChangeScene() {
        changeScene.TriggerEvent();
        SceneManager.LoadScene(sceneIndex);
    }
}
