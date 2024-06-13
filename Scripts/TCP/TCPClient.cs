using System;
using System.Collections;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class TCPClient : MonoBehaviour
{
    [SerializeField]
    private string targetIp;
    [SerializeField]
    private int targetPort;

    private TcpClient client;
    private NetworkStream stream;


    public void SendMsg(string msg)=> StartCoroutine(SendMessage(msg));

    new IEnumerator SendMessage(string msg)
    {
        client = new TcpClient();
        var connect = client.BeginConnect(targetIp, targetPort, null, null);

        // �ȴ��������
        while (!connect.IsCompleted)
            yield return null;

        try
        {
            client.EndConnect(connect);
            Debug.Log("Connected to server.");
            stream = client.GetStream();

            // ���ͳ�ʼ��Ϣ
            StartCoroutine(SendMessageWithoutConnect(msg));
        }
        catch (Exception e)
        {
            Debug.Log("Failed to connect: " + e.Message);
        }
    }

    
    // ��װ������Ϣ�Ĺ���ΪЭ��
    IEnumerator SendMessageWithoutConnect(string message)
    {
        if (stream != null)
        {
            byte[] dataToSend = Encoding.UTF8.GetBytes(message);

            // �첽������Ϣ
            var asyncSend = stream.BeginWrite(dataToSend, 0, dataToSend.Length, null, null);
            while (!asyncSend.IsCompleted)
                yield return null;
            try
            {
                stream.EndWrite(asyncSend);

                Debug.Log("Sent: " + message);

                // ��ʼ������Ӧ
                StartCoroutine(ReceiveMessage());
            }
            catch (Exception e)
            {
                Debug.Log("Failed to send message: " + e.Message);
            }
        }
        else
        {
            Debug.Log("Stream is not available.");
        }
    }


    // ������Ϣ��Э��
    IEnumerator ReceiveMessage()
    {
        byte[] receivedBytes = new byte[1024];

        var asyncReceive = stream.BeginRead(receivedBytes, 0, receivedBytes.Length, null, null);
        while (!asyncReceive.IsCompleted)
            yield return null;
        try
        {
            int numberOfBytesRead = stream.EndRead(asyncReceive);
            if (numberOfBytesRead > 0)
            {
                string receivedMessage = Encoding.UTF8.GetString(receivedBytes, 0, numberOfBytesRead);
                Debug.Log("Received: " + receivedMessage);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Failed to receive message: " + e.Message);
        }
    }

    void OnApplicationQuit()
    {
        stream?.Close();
        client?.Close();
        Debug.Log("Connection closed.");
    }
}
