using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManage : MonoBehaviour {

    public TypingPizza typingPizza;
    public Score score;
    public Truck truck;
    public float houseSpeed = 1.5f;
    public float mul = 1.1f;
    public bool gameRunning = true;

    private bool canUpSpeed = true;
    private Queue<GameObject> houseQueue = new Queue<GameObject>();
    private GameObject house;
    private string pizzaCode;
    private float minTime = 1.5f;
    private float maxTime = 6f;
    private float time;
    private float spawnTime;
    private static Dictionary<int, string> tagHouse = new Dictionary<int, string>();
    private string tagString = "House1";

    void Start()
    {
        initTagHouse();
        setSpawnTime();
        time = minTime;
    }

    void Update () {

        typingPizza.TypeUpdate();
        
        if (typingPizza.isTypingFinish())
        {
            score.SetScore(100);
            house.GetComponent<HouseMovement>().ReceiveOrder();
            SetInactiveOrder();
            SendingPizza();
            typingPizza.SetNotFinish();
        }

        SetSpeed();

        if (typingPizza.isTypingEmp())
        {
            if (houseQueue.Count > 0)
            {
                house = houseQueue.Dequeue();
                pizzaCode = house.GetComponent<HouseMovement>().getPizza();
                typingPizza.SetPizza(pizzaCode);
            }
        }
	}

    void FixedUpdate()
    {
        TimerForSpawn();
    }

    public void enqueueHouse(GameObject houseObject)
    {
        houseQueue.Enqueue(houseObject);
    }

    public void SetSpeed ()
    {
        if (score.GetScore() != 0 && score.GetScore() % 500 == 0 && canUpSpeed) {
            houseSpeed *= mul;
            setMinMaxTime();   
            canUpSpeed = false;
        } else {
            if (score.GetScore() % 500 != 0) {
                canUpSpeed = true;
            }
        }
    }

    private void SetInactiveOrder ()
    {
        for (int i = 0; i < house.transform.childCount; i++)
        {
            house.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    private void setMinMaxTime ()
    {
        if (minTime > 0.1)
        {
            minTime /= mul;
        }

        if (maxTime > 0.3)
        {
            maxTime /= mul;
        }
    }

    public float GetSpeed ()
    {
        return houseSpeed;
    }

    private void initTagHouse ()
    {
        tagHouse.Add(0, "House1");
        tagHouse.Add(1, "House2");
        tagHouse.Add(2, "House3");
        tagHouse.Add(3, "House4");
        tagHouse.Add(4, "House5");
    }

    private void setSpawnTime ()
    {
        spawnTime = Random.Range(minTime, maxTime);
    }

    private void houseSpawn()
    {
        time = 0;
        int tagNum = (int)(Random.Range(0, 5));
        tagString = tagHouse[tagNum];

        GameObject house = ObjectPooling.SharedInstance.GetPooledObject(tagString);

        if (house != null)
        {
            house.SetActive(true);
        }
    }

    private void TimerForSpawn ()
    {
        time += Time.deltaTime;

        if (time >= spawnTime)
        {
            houseSpawn();
            setSpawnTime();
        }
    }

    private void SendingPizza()
    {
        GameObject pizzaSend = ObjectPooling.SharedInstance.GetPooledObject("SendingPizza");
        SpriteRenderer pizzaSprite = pizzaSend.GetComponent<SpriteRenderer>();
        PizzaSending pizzaSending = (PizzaSending)pizzaSend.GetComponent(typeof(PizzaSending));
        pizzaSprite.sprite = typingPizza.getCompletePizza();
        if (pizzaSend != null)
        {
            pizzaSending.SetHouse(house);
            pizzaSend.SetActive(true);
        }
    }
}
