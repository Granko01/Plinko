using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHoldHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CoinsManager coinsManager;
    private bool isHolding = false;
    private float holdInterval = 0.05f;
    private float timer;

    public void OnPointerDown(PointerEventData eventData)
    {
        isHolding = true;
        timer = 0f;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isHolding = false;
        coinsManager.SaveCoins();
        coinsManager.SaveScore();
    }

    public void PointerDown()
    {
        OnPointerDown(null);
    }

    public void PointerUp()
    {
        OnPointerUp(null);
    }

    private void Update()
    {
        if (!isHolding || coinsManager == null || coinsManager.Score <= 0) return;

        if (timer <= 0f)
        {
            coinsManager.SaveCoinsFromScore();
            timer = holdInterval;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
