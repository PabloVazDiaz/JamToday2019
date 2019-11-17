using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Header("Health")]
    public int HealthPrice;
    public Text HealthPriceText;
    public Text HealthAmount;

    public void BuyHealth()
    {
        if (PlayerController.instance.health < 6)
        {
            PlayerController.instance.health += 1;
            GameController.instance.plastic += HealthPrice;
            GameController.instance.UpdateLifeCanvas();
        }
    }

    public void SellHealth()
    {
        if (PlayerController.instance.health > 1)
        {
            PlayerController.instance.health -= 1;
            GameController.instance.plastic -= HealthPrice;
            GameController.instance.UpdateLifeCanvas();
        }
    }

    [Header("Speed")]
    public int SpeedPrice;
    public Text SpeedPriceText;
    public Text SpeedAmount;

    public void BuySpeed()
    {
        if (PlayerController.instance.speed < 6)
        {
            PlayerController.instance.health += 1;
            GameController.instance.plastic += SpeedPrice;
        }
    }

    public void SellSpeed()
    {
        if (PlayerController.instance.speed > 1)
        {
            PlayerController.instance.speed -= 1;
            GameController.instance.plastic -= SpeedPrice;
        }
    }
}
