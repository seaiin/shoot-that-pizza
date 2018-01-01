using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PizzaDemo : MonoBehaviour {
    public TypingPizza typingPizza;

    private SpriteRenderer spriteRenderer;
    private Sprite[] pizzaSprite;
    private Sprite truck;
    private Queue<string> pizzaTypeQueue = new Queue<string>();
    private int index = 0;
    private string pizzaCode;

    void Start () {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		pizzaSprite = Resources.LoadAll<Sprite>("pizza/complete");
        truck = Resources.Load<Sprite>("truck");
        spriteRenderer.sprite = pizzaSprite[index++];

        setPizzaQueue();
    }
	
	void Update () {
        typingPizza.TypeUpdateDemo();


        if (typingPizza.isTypingFinish())
        {
            if (index < 5)
            {
                spriteRenderer.sprite = pizzaSprite[index];
                typingPizza.SetNotFinish();
            }
            else if (index == 5)
            {
                transform.position = new Vector3(-1.01f, -1.87f, 1);

                spriteRenderer.sprite = truck;
                typingPizza.SetNotFinish();
            }
            else
            {
                SetFinishDemo();
            }
            index++;
        }
        if (typingPizza.isTypingEmp())
        {
            if (pizzaTypeQueue.Count > 0)
            {
                pizzaCode = pizzaTypeQueue.Dequeue();
                typingPizza.SetPizzaDemo(pizzaCode);
                Debug.Log(pizzaCode);
            }
        }
    }

    private void setPizzaQueue ()
    {
        pizzaTypeQueue.Enqueue("HWI");
        pizzaTypeQueue.Enqueue("MBL");
        pizzaTypeQueue.Enqueue("PEP");
        pizzaTypeQueue.Enqueue("SEA");
        pizzaTypeQueue.Enqueue("SPN");
        pizzaTypeQueue.Enqueue("STR");
    }

    private void SetFinishDemo()
    {
        SceneManager.LoadScene("Game");
    }
}
