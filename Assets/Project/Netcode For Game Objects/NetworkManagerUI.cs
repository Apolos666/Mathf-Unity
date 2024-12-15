using Unity.Netcode;
using UnityEngine;

public class NetworkManagerUI : MonoBehaviour
{
    public void Host()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void Server()
    {
        NetworkManager.Singleton.StartServer();
    }
    
    public void Client()
    {
        NetworkManager.Singleton.StartClient();
    }
}