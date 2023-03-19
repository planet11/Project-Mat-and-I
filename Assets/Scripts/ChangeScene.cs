using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

namespace Persisting
{
    public class ChangeScene : MonoBehaviour
    {
        public static ChangeScene instance;
        public string sceneName;

        public void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }

        }

        public void LoadScene()
        {

            SceneManager.LoadScene(sceneName);

        }
    }

}



