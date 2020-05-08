using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Shooter : NetworkBehaviour {
	public GameObject rocketPrefab;
	public Transform shootPoint;
    public float timeBetweenShots = 0.5f;  // Allow 3 shots per second

    private float timestamp;

    // Update is called once per frame
    void Update ()
	{

        //Only allow shooting if this is the local player object
        if (!isLocalPlayer)
			return;
	

		if (Time.time >= timestamp && (Input.GetButtonDown("Fire1"))) {
			Quaternion rocketRot = Quaternion.Euler(shootPoint.rotation.eulerAngles.x + 90, shootPoint.rotation.eulerAngles.y, shootPoint.rotation.eulerAngles.z);
			CmdSpawnRocket(shootPoint.position, rocketRot, shootPoint.forward * 40f);
            timestamp = Time.time + timeBetweenShots;
        }
	}
	
	
	[Command]
	private void CmdSpawnRocket(Vector3 shootPointPosition, Quaternion rocketRot, Vector3 velocity)
	
	{
		GameObject rocket = Instantiate(rocketPrefab, shootPointPosition, rocketRot);
		rocket.GetComponent<Rocket>().RocketVelocity = velocity;
		rocket.GetComponent<Rocket>().SpawnedBy = netId;
		NetworkServer.SpawnWithClientAuthority(rocket, connectionToClient);
	}
}
