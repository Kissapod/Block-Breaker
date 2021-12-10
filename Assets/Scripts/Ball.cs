using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Platform platform; //публичная переменная platform класса Platform служащая для связи с объектом платформа
    private Vector3 platformToBallVector; // приватная переменная относящаяся к классу Vector3, 
    //который служит для отоюражения координат вектора в трехмерном пространстве
    private bool hasStarted = false; // переменная для контроля над функцией, которая удерживает мяч относительно начала платформы
    // Start is called before the first frame update
    void Start()
    {
        platform = GameObject.FindObjectOfType<Platform>();
        // Высчитываем переменную между центрами мяча и платформы
        platformToBallVector = this.transform.position - platform.transform.position;
        print(platformToBallVector);
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) {
            // Удерживает мяч относительно платформы
            this.transform.position = platform.transform.position + platformToBallVector;
            
            //Функция ожидающая нажатие кнопки мыши для запуска
            if (Input.GetMouseButtonDown(0)) {
                print("Нажата левая кнопка мыши");
                hasStarted = true;
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 10f);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 tweak = new Vector2(Random.Range(0f,0.2f), Random.Range(0f, 0.2f));
        if (hasStarted)
        {
            GetComponent<AudioSource>().Play();
            this.GetComponent<Rigidbody2D>().velocity += tweak;
        }
    }
}
