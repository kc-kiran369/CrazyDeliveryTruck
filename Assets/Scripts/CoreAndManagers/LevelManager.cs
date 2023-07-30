using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LevelManagerInstance { get; private set; }

    private void Awake()
    {
        if (LevelManagerInstance == null)
        {
            LevelManagerInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void LoadLevelByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void LoadLevelByName(string name)
    {
        SceneManager.LoadScene(name);
    }
}