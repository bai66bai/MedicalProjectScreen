using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class PipelineVideoCtrl : MonoBehaviour
{
    public VideoPlayer videoPlayer; // ��Ƶ���������
    private bool isPlaying = false; // ��ǰ����״̬

    void Start()
    {
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();
        }
        videoPlayer.loopPointReached += (vp) =>
        {
            videoPlayer.time = 0;
            isPlaying = false;
        };
        // ȷ����Ƶһ��ʼ����ͣ��
        videoPlayer.Pause();
        isPlaying = false;
    }

    public void TogglePlayPause()
    {
        if (isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
        isPlaying = !isPlaying;
    }


    public void CtrlStopVideo()
    {
        videoPlayer.Pause();
    }
}
