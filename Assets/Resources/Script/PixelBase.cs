using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class PixelBase : MonoBehaviour
{

    private Vector3 cashPosition;
    private Vector2 cashSize;

    void LateUpdate()
    {
        cashPosition = transform.localPosition;
        transform.localPosition = new Vector3(
                        Mathf.RoundToInt(cashPosition.x / 5) * 5,
                        Mathf.RoundToInt(cashPosition.y / 5) * 5,
                        Mathf.RoundToInt(cashPosition.z / 5) * 5);
        cashSize = GetComponent<RectTransform>().sizeDelta;

        GetComponent<RectTransform>().sizeDelta = new Vector2(
        Mathf.RoundToInt(cashSize.x / 5)*5,
                Mathf.RoundToInt(cashSize.y / 5) * 5
        );
    }

    void OnRenderObject()
    {
        
        transform.localPosition = cashPosition;
        GetComponent<RectTransform>().sizeDelta = cashSize;
        
    }
}