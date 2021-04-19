using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mirror.Examples.Topdown
{
    public class NetworkManager_Topdown : NetworkManager
    {
        public Transform leftPlayerSpawn;
        public Transform rightPlayerSpawn;
        
        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            // add player at correct spawn position
            Transform start = numPlayers == 0 ? leftPlayerSpawn : rightPlayerSpawn;
            GameObject player = Instantiate(playerPrefab, start.position, start.rotation);
            NetworkServer.AddPlayerForConnection(conn, player);

        }

        // public override void OnServerDisconnect(NetworkConnection conn)
        // {
        //     // call base functionality (actually destroys the player)
        //     base.OnServerDisconnect(conn);
        // }
    }
}