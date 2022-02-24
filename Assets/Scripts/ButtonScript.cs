using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Play()
    {
        SceneManager.LoadScene("GameScene");

    }

    public void BackToMain()
    {
        SceneManager.LoadScene("StartScene");

    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");

    }
}
