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
            GameController.plastic += HealthPrice;
            GameController.instance.UpdateLifeCanvas();
        }
    }

    public void SellHealth()
    {
        if (PlayerController.instance.health > 1)
        {
            PlayerController.instance.health -= 1;
            GameController.plastic -= HealthPrice;
            GameController.instance.UpdateLifeCanvas();
        }
    }

    [Header("Speed")]
    public int SpeedPrice;
    public Text SpeedPriceText;
    public Text SpeedAmount;

    public void BuySpeed()
    {
        if (PlayerController.instance.speed < 12)
        {
            PlayerController.instance.speed += 2;
            GameController.plastic += SpeedPrice;
            GameController.instance.UpdateSpeedCanvas();
        }
    }

    public void SellSpeed()
    {
        if (PlayerController.instance.speed > 2)
        {
            PlayerController.instance.speed -= 2;
            GameController.plastic -= SpeedPrice;
            GameController.instance.UpdateSpeedCanvas();
        }
    } 
    [Header("CoolDown")]
    public int CDPrice;
    public Text CDPriceText;
    public Text CDAmount;

    public void BuyCD()
    {
        if (PlayerController.instance.ShootCDBuys < 6)
        {
            PlayerController.instance.ShootCD -= 0.35f;
            PlayerController.instance.ShootCDBuys += 1;
            GameController.plastic += CDPrice;
            GameController.instance.UpdateCDCanvas();
        }
    }

    public void SellCD()
    {
        if (PlayerController.instance.ShootCDBuys < 1)
        {
            PlayerController.instance.ShootCD += 0.35f;
            PlayerController.instance.ShootCDBuys -= 1;
            GameController.plastic += CDPrice;
            GameController.instance.UpdateCDCanvas();
        }
    }
}
