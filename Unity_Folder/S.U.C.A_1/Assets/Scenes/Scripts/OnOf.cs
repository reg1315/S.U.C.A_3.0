using UnityEngine;
using UnityEngine.EventSystems;

public class OnOf : MonoBehaviour, IPointerClickHandler
{
    public float onState;   //  значення світла при включеному стані
    private const float ofState = 0;     //    значення світла при виключеному стані

    private Light light;    //  зберігає світло лампочки
    private bool state;     //  зберігає значення перемикача
    private void Start()
    {
        light = GameObject.FindGameObjectWithTag("Light").GetComponent<Light>();

        if (light.intensity > ofState)
        {
            onState = light.intensity;
            state = true;
        }
        else
        {
            state = false;
            light.intensity = ofState;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (state)
            Of();
        else
            On();
    }   //  подія при нажиманні на виключач

    private void On()
    {
        state = true;
        light.intensity = onState;
        transform.Rotate(transform.forward, 180);
    }

    private void Of()
    {
        state = false;
        light.intensity = ofState;
        transform.Rotate(transform.forward, 180);
    }
}
