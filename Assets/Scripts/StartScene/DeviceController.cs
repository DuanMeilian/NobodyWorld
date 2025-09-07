using UnityEngine;

public class DeviceController : MonoBehaviour
{
    void Start()
    {
        //判断是否为安卓机
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("当前平台是Android");
        }
        else
        {
            Debug.Log("当前平台不是Android");
        }
    }
}
