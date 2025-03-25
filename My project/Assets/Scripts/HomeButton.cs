using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeButton : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene(1);
    }
}
