using UnityEngine;

public class DeviceController : MonoBehaviour
{
    void Start()
    {
        //�ж��Ƿ�Ϊ��׿��
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("��ǰƽ̨��Android");
        }
        else
        {
            Debug.Log("��ǰƽ̨����Android");
        }
    }
}
