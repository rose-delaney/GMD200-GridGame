using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene(0);
    }
}
