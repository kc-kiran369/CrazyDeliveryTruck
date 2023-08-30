using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager LevelManagerInstance { get; private set; }

    [SerializeField] CheckPointManager checkPointManager;

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

    private void Start()
    {

        OnLevelStart();
    }

    void OnLevelStart()
    {
        MessageBox.Singleton.AddMessage($"Reach {checkPointManager.TotalCheckPoints} checkpoints to complete this level.", 3.0f);
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