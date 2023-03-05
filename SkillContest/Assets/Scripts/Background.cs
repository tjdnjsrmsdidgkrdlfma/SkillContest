using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] GameObject[] background_list;
    [SerializeField] float move_speed;

    float distance = 53.4f;

    void Update()
    {
        foreach(GameObject background in background_list)
        {
            background.transform.Translate(Vector2.down * move_speed * Time.deltaTime);

            if(background.transform.position.y < -distance)
            {
                Vector2 temp = background.transform.position;
                temp.y += distance * 2;
                background.transform.position = temp;
            }
        }
    }
}
