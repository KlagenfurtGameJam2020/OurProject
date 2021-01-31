using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBoxScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        //Center dialogue box

        transform.position = new Vector2(Screen.width / 2, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameObject.SetActive(false);
        }
    }

    public void ShowText(string text, Sprite sprite)
    {
        GameObject.Find("DialogueText").GetComponent<Text>().text = text;

        GameObject.Find("DialogueImage").GetComponent<Image>().sprite = sprite;

        gameObject.SetActive(true);
    }

    public void HideText()
    {
        gameObject.SetActive(false);

    }
}
