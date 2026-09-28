using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string sceneName = "";
    private void Awake()
    {
        sceneName = sceneName.Trim();
        if(sceneName== "")
        {
            Debug.LogError("Scene bname cannot be emùpty");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
