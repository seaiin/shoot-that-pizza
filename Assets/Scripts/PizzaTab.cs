using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaTab : MonoBehaviour {

    public SpriteRenderer spriteRenderer;

    private int index;
    private string pizzaCode;
    private Sprite plainSprite;
    private Sprite[] preSprite;
    private Sprite[] comSprite;
    private static Dictionary<string, int> pizzaIndex = new Dictionary<string, int>();

    void Start()
    {
        plainSprite = Resources.Load<Sprite>("pizza/pizza-plain");
        preSprite = Resources.LoadAll<Sprite>("pizza/pre");
        comSprite = Resources.LoadAll<Sprite>("pizza/complete");
        InitIndex();
    }

    private void InitIndex()
    {
        if (pizzaIndex.Count == 0)
        {
            pizzaIndex.Add("HWI", 0);
            pizzaIndex.Add("MBL", 1);
            pizzaIndex.Add("PEP", 2);
            pizzaIndex.Add("SEA", 3);
            pizzaIndex.Add("SPN", 4);
        }
    }

    private void SetIndex()
    {
        index = pizzaIndex[pizzaCode];
    }

    public void SetPizza(string pizza)
    {
        pizzaCode = pizza;
        SetIndex();
        ChangedSprite(0);
    }

    public void ChangedSprite(int stage)
    {
        switch (stage)
        {
            case 1:
                spriteRenderer.sprite = preSprite[index];
                break;
            case 2:
                spriteRenderer.sprite = comSprite[index];
                break;
            default:
                spriteRenderer.sprite = plainSprite;
                break;
        }
    }

    public Sprite getCompletePizza ()
    {
        return comSprite[index];
    }
}
