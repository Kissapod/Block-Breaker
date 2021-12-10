using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public bool autoPlay = false;
    public float minX, maxX;
    private Ball ball;

    private void Start()
    {
        ball = GameObject.FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!autoPlay)
        {
            MoveWithMouse();
        } else
        {
            AutoPlay();
        }
    }

    void MoveWithMouse()
    {
        Vector3 platformPos = new Vector3(0.5f, this.transform.position.y, 0f); // Задаем начальную позицию платформы
        float mosPosInBlocks = Input.mousePosition.x / Screen.width * 16; // Высчитываем положение мышки в мировых единицах
        platformPos.x = Mathf.Clamp(mosPosInBlocks, minX, maxX); // Задаем ограничение положения платформы в рамках экрана
        this.transform.position = platformPos; // Назначаем положение платформы относительно положения курсора мыши
    }
    void AutoPlay()
    {
        Vector3 platformPos = new Vector3(0.5f, this.transform.position.y, 0f); // Задаем начальную позицию платформы
        Vector3 ballPos = ball.transform.position; // привязываем координаты платформы к координатам меча
        platformPos.x = Mathf.Clamp(ballPos.x, minX, maxX); // Задаем ограничение положения платформы в рамках экрана
        this.transform.position = platformPos; // Назначаем положение платформы относительно положения курсора мыши
    }
}
