using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPS : MonoBehaviour
{
    float deltaTime = 0.0f;
    float temps;

    void Start()
    {
    }

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
        temps = Time.time;
        float fps = 1.0f / deltaTime;

        GetComponent<Text>().text = fps.ToString();

    }

}