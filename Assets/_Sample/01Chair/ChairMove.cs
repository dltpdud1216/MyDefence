using UnityEngine;

public class ChairMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //의자를 이동하라
        Debug.Log("앞으로 이동하기");
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position += new Vector3(0, 0, 1) * Time.deltaTime;

    }
}
