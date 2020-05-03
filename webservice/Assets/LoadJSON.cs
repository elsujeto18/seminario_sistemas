/*
 * Los creditos van para HenrikPoulsen https://github.com/HenrikPoulsen/SimpleJSON
 * se necesito SimpleJSON, ya que nos ayudara a hacer un parsing del JSON. 
 * esta fue la alternativa que se utilizo.
 */

using System.Collections;
using UnityEngine;
using SimpleJSON;
using UnityEngine.Networking;
using TMPro;

public class LoadJSON : MonoBehaviour
{

    public TMP_InputField inputTxt;
    public TMP_Text countryTxt;
    public TMP_Text currencyTxt;
    public TMP_Text cityTxt;
    public TMP_Text continentTxt;

    public void GetJsonData()
    {
        StartCoroutine(RequestWebService());
    }

    IEnumerator RequestWebService()
    {
        string getDataUrl = "http://www.geoplugin.net/json.gp?ip=" + inputTxt.text;
        print(getDataUrl);

        using (UnityWebRequest webData = UnityWebRequest.Get(getDataUrl))
        {

            yield return webData.SendWebRequest();
            if (webData.isNetworkError || webData.isHttpError)
            {
                print("---------------- ERROR ----------------");
                print(webData.error);
            }
            else
            {
                if (webData.isDone)
                {
                    JSONNode jsonData = JSON.Parse(System.Text.Encoding.UTF8.GetString(webData.downloadHandler.data));

                    if (jsonData == null)
                    {
                        print("---------------- NO DATA ----------------");
                    }
                    else
                    {
                        print("---------------- JSON DATA ----------------");
                        print("jsonData.Count:" + jsonData.Count);
                        countryTxt.text = jsonData["geoplugin_countryName"];
                        currencyTxt.text = jsonData["geoplugin_currencyCode"];
                        cityTxt.text = jsonData["geoplugin_city"];
                        continentTxt.text = jsonData["geoplugin_continentName"];
                    }
                }
            }
        }
    }
}

