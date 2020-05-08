using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityStandardAssets.Effects;

// This script is from UnityStandardAssets.Effect
// I modified this to make explosion impact to non-rigidbody objects.

public class ExplosionForce : NetworkBehaviour
{
    public float explosionForce = 20;

    private IEnumerator Start()
    {
        // wait one frame because some explosions instantiate debris which should then
        // be pushed by physics force
        yield return null;
        CmdDoKnockback();


        //Your code:
//        List<Rigidbody> rigidbodies = new List<Rigidbody>();
//        foreach (var col in cols)
//        {
//            if (col.attachedRigidbody != null && !rigidbodies.Contains(col.attachedRigidbody))
//            {
//                rigidbodies.Add(col.attachedRigidbody);
//            }
//            else if (col.transform.tag == "Player")
//            {
//                rigidbodies.Add(col.GetComponent<Rigidbody>());
//            }
//        }
//        foreach (var rb in rigidbodies)
//        {
//            if (rb.transform.tag == "Player")
//            {
//                ImpactReceiver impactReceiver = rb.transform.GetComponent<ImpactReceiver>();
//                Vector3 dir = rb.transform.position - transform.position;
//                float force = Mathf.Clamp((explosionForce) / 3, 0, 15);
//
//                impactReceiver.AddImpact(dir, force);
//            }
//            else
//            {
//                rb.AddExplosionForce(explosionForce * multiplier, transform.position, r, 1 * multiplier, ForceMode.Impulse);
//            }
//        }
    }

    [Command]
    private void CmdDoKnockback()
    {
        float multiplier = GetComponent<ParticleSystemMultiplier>().multiplier;

        float r = 5 * multiplier;
        Collider[] cols = Physics.OverlapSphere(transform.position, r);

        //Rocket Jumping pull (Pixelch3f's code):
        
        foreach (Collider collision in cols)
        {
            CPMPlayer player = collision.GetComponent<CPMPlayer>();
            if (player != null)
            {
                // Apply knockback force to player if they are in explosion radius
                player.RpcKnockback(player.transform.position - transform.position, explosionForce);
            }
        }
    }
}