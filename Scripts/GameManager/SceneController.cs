using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {

    [SerializeField]
    private string sceneName;
    public static SceneController SC;

    public void ChangeScene()
    {
        Save();
        SceneManager.LoadScene(sceneName);
    }
    
    public void ChangeSceneWait()
    {
        StartCoroutine("WaitThenChange");
    }

    IEnumerator WaitThenChange()
    {
        yield return new WaitForSeconds(.5f);
        Save();
        SceneManager.LoadScene(sceneName);
    }

    public void Save()
    {
        GameController.GC.Save();
    }
    public void Load()
    {
        GameController.GC.Load();
    }

    public void BackToMain()
    {
        Save();
        SceneManager.LoadScene("MainMenu");
    }

}
