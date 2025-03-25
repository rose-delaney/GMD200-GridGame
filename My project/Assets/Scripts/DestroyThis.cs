using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyThis : MonoBehaviour
{
    private void Update()
    {
        UnityEngine.SceneManagement.Scene scene = SceneManager.GetActiveScene();
        if (scene.buildIndex != 0)
        {
            Destroy(this.gameObject);
        }
    }
}
