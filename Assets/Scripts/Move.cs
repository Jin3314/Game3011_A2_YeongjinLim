using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Move : MonoBehaviour
{
    float speed;
    bool closeBy;
    Vector3 dir;
    public GameController game;
    public GameObject minigame;
    public Slider slider;
    public Text objective;
    public int howmanytries;
    public Text Attempts;
    public int AttemptsNumber;

    private void OnTriggerEnter(Collider other)
    {
        closeBy = true;

    }

    private void OnTriggerExit(Collider other)
    {
        closeBy = false;

        minigame.SetActive(false);
    }

    void Start()
    {
        speed = 3;
        closeBy = false;
        slider = minigame.transform.GetChild(0).GetComponent<Slider>();
    }

    void Update()
    {
        Attempts.text = AttemptsNumber.ToString();

        if (Input.GetKey(KeyCode.W))
        {
            dir = Vector3.forward * speed * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            dir = Vector3.back * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            dir = Vector3.left * speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            dir = Vector3.right * speed * Time.deltaTime;
        }
        else
        {
            dir = Vector3.zero;
        }

        transform.position += dir;

        if(closeBy && Input.GetKeyDown(KeyCode.Space))
        {
            if(!minigame.activeSelf)
            {
                minigame.SetActive(true);
                objective.text = " ";
            }
            else
            {
                minigame.SetActive(false);
            }
        }
        if(minigame.activeSelf && Input.GetMouseButtonDown(0))
        {
            howmanytries += 1;
            AttemptsNumber -= 1;
            

           if(slider.value > 45 && slider.value < 55)
           {
                game.Win();
                howmanytries = 0;
                AttemptsNumber = 10;
           }
           else
           {
                game.Fail();
           }
        }
        if(howmanytries == 10)
        {
            game.Lose();
        }
    }

}
