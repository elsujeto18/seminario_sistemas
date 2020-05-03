using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEditor;
using System.IO;





public class Video : MonoBehaviour
{
    public RawImage image;
    public VideoPlayer video;
    



    public void Video_onClicked() {
        StartCoroutine("PlayVideo");
    
    }

    IEnumerator PlayVideo()
    {
        video.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while(video.isPrepared)
        {
            yield return waitForSeconds;

            break;

        }

        image.texture = video.texture;
        video.Play();
       

    }









}
