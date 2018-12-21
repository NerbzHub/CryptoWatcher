using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RetrieveData : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://www.coinspot.com.au/pubapi/latest");
        Debug.Log(www.ToString());
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}
