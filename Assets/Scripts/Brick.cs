using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public AudioClip crack;
    public Sprite[] hitSprites;
    public static int breakebleCount = 0;
    public GameObject smoke;
    
    private int timeHit;
    private bool isBreakeble; //сравниваем ярлыки
    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        isBreakeble = (this.tag == "Breakeble"); 
        //будем отслеживать разрушаемые кирпичи
        if (isBreakeble)
        {
            breakebleCount++;
        }
        timeHit = 0;
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (isBreakeble) //если блок разрушаемый
        {
            AudioSource.PlayClipAtPoint(crack, transform.position, 3.9f);
            HandleHits(); //запускаем метод 
        }
    }

    //обработка ударов
    void HandleHits()
    {
        timeHit++;
        int maxHits = hitSprites.Length + 1; //максимальное количество ударов равно длина массива + 1
        if (timeHit >= maxHits)
        {
            breakebleCount--;
            levelManager.BrickDestroyed();
            PuffSmoke();
            Destroy(gameObject);
        }
        else
        {
            LoadSprites();
        }
    }
    // создание дыма и окраска его в цвет кирпича
    void PuffSmoke()
    {
        GameObject smokePuff = Instantiate(smoke, new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z-5), Quaternion.identity) as GameObject;
        smokePuff.GetComponent<ParticleSystem>().startColor = this.GetComponent<SpriteRenderer>().color;
    }
    void LoadSprites()
    {
        int spriteIndex = timeHit - 1;
        if (hitSprites[spriteIndex])
        {
            this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
    }
}
