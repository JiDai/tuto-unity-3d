using UnityEngine;
using UnityEngine.SceneManagement;

public class ReplayButton : MonoBehaviour
{
    public void OnButtonPress()
    {
        Debug.Log("Un der ?");
        SceneManager.LoadScene("GameScene");
    }
}