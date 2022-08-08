using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    Vector3 startPosi;
    float whenRepeat;

    void Start()
    {
        startPosi = transform.position;
        whenRepeat = GetComponent<BoxCollider>().size.x / 2;
    }

    void Update()
    {
        /* الخفلفية هي صورة بتتكون من صورتين ورا بعض متطبقتين.. ف مهمة
         * startPosi.x - whenRepeat
         * ان لما بداية الخلفية التانية يوصل لنقطة بداية الصورة الاول اول 
         * ما شغلنا اللعبة الصورة الاولا ترجع مكانها تاني
         */
        if (transform.position.x < startPosi.x - whenRepeat) 
        {
            transform.position = startPosi;
        }
    }
}
