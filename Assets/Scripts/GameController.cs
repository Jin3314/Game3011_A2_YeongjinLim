using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject minigame;
    public Slider slider;
    public GameObject door;
    public GameObject roomPrefab;
    public GameObject player;
    public Text objective;
    public Text playerSkill;
    public Text Difficulty;
    float Level;
    float zPos;
    float PPos;
    float difficulty;
    public GameObject GameOver;
    public Text Score;

    public void Win()
    {
        Level++;
        var room = Instantiate(roomPrefab);
        zPos += 5;
        PPos += 10;
        room.transform.position = new Vector3(0, 0, zPos);
        // player.transform.position = new Vector3(1, -1, pz);
        door.transform.position += new Vector3(0, 0, 5);
        minigame.SetActive(false);
        door = GameObject.Find("Door");

    }

    public void Fail()
    {
        Debug.Log("Failed");
    }

    public void Lose()
    {
        Debug.Log("Lose");
        minigame.SetActive(false);
        Time.timeScale = 0;
        GameOver.SetActive(true);
        Score.text = Level.ToString();
    }

    public void Replay()
    {
        SceneManager.LoadScene("GameScene");

    }

    void Start()
    {
        Time.timeScale = 1;
        door = GameObject.Find("Door");
        Level = 1f;
        zPos = 0;
        PPos = 0;
        slider = minigame.transform.GetChild(0).GetComponent<Slider>();
        difficulty = 0.05f;
    }

    void Update()
    {
        playerSkill.text = "Skill:" + Level.ToString();
        Difficulty.text = Level.ToString();
        slider.value += difficulty * Level;
        if(slider.value == 0 || slider.value == 100)
        {
            difficulty *= -1;
        }
    }

   
}
