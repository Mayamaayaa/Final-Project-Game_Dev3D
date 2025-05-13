using UnityEngine;

public class CopyMeshColliderToAll : MonoBehaviour
{
    void Start()
    {
        foreach (Transform tree in transform)
        {
            // Look through the children of each tree
            MeshFilter[] meshFilters = tree.GetComponentsInChildren<MeshFilter>();

            foreach (MeshFilter mf in meshFilters)
            {
                GameObject meshObject = mf.gameObject;
                MeshCollider mc = meshObject.GetComponent<MeshCollider>();

                if (mc == null)
                {
                    mc = meshObject.AddComponent<MeshCollider>();
                }

                mc.sharedMesh = mf.sharedMesh;
                mc.convex = false;
            }
        }

        Debug.Log("🌟 MeshColliders added to all visible parts of your trees!");
    }
}