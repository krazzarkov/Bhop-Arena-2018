using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Rocket : NetworkBehaviour
{
    public GameObject explosionPrefab;

    public float SelfExplosionTimer = 5;

    private float timer;

    //The set velocity, synchronised across all clients
    [SyncVar, HideInInspector] public Vector3 RocketVelocity;

    [SyncVar, HideInInspector] public NetworkInstanceId SpawnedBy;

    public override void OnStartClient()
    {
        GameObject player = ClientScene.FindLocalObject(SpawnedBy);
        Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        GetComponent<Rigidbody>().velocity = RocketVelocity;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > SelfExplosionTimer)
        {
            CmdHit();
            timer = 0;
        }
    }

    [Command]
    void CmdHit()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        GameObject explosion = Instantiate(explosionPrefab, transform.position, transform.rotation);
        NetworkServer.SpawnWithClientAuthority(explosion, CPMPlayer.LocalPlayer.gameObject);
        Destroy(gameObject, 0.1f);
        NetworkServer.Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other)
    {
        //Do the collision detection only in the server
        if (!isServer)
        {
            //If this is the client, just delete the object
            Destroy(this);
            return;
        }

        CmdHit();
    }
}