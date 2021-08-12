using UnityEngine;
using UnityEngine.EventSystems;

public class LightSwich : MonoBehaviour, IPointerClickHandler
{
    private bool swich = true;
    public Light PointL;
    public float OnIntensity;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (swich){
            Rotator();
            PointL.intensity = 0;
            swich = false;
        }
        else{
            Rotator();
            PointL.intensity = OnIntensity;
            swich = true;
        }
    }

    private void Rotator()
    {
        //transform.localEulerAngles = new Vector3(transform.rotation.x, transform.rotation.z , -transform.rotation.y + 180f);
    }


    void Start()
    {
        if (PointL.intensity == 0)
            swich = false;
        else
            OnIntensity = PointL.intensity;
    }
}
