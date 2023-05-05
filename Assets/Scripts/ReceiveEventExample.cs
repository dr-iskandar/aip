using ExitGames.Client.Photon;
using Photon.Realtime;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class ReceiveEventExample : MonoBehaviour
{
    public VideoPlayer vp;
    public GameObject idleImage;
    public VideoClip[] vc;

    [PunRPC]
    void ChatMessage(string index)
    {
        vp.clip = vc[int.Parse(index)];
        vp.GetComponent<CanvasGroup>().alpha = 1;
        idleImage.GetComponent<CanvasGroup>().alpha = 0;
        vp.Play();
    }

    [PunRPC]
    void StopMessage(string stop)
    {
        vp.Stop();
        vp.GetComponent<CanvasGroup>().alpha = 0;
        idleImage.GetComponent<CanvasGroup>().alpha = 1;
    }    
    

    public void RunRPC()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ChatMessage", RpcTarget.All, "0");
    }

    public void RunRPCTwo()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ChatMessage", RpcTarget.All, "1");
    }

    public void RunRPCVideo(string index)
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("ChatMessage", RpcTarget.All, index);
    }

    public void StopByRPC()
    {
        PhotonView photonView = PhotonView.Get(this);
        photonView.RPC("StopMessage", RpcTarget.All, "Stop");
    }
        
}