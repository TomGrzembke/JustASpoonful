using UnityEngine;

public interface IPickupable
{
    public void Pickup();
    public void Pickup(GameObject alternUIObj);
    public void Drop();
}