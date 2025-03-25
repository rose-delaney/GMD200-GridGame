using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyThisEndScren : MonoBehaviour
{
    private void Update()
    {
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex != 2)
        {
            Destroy(this.gameObject);
        }
    }
}
