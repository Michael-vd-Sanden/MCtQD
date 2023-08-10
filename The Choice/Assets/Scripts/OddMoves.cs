using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OddMoves : MonoBehaviour
{
    public MoveCamera moveCamera;

    public void toHallway()
    {
        moveCamera.OddMove(new Vector3(80,0,0));
    }

    public void KamerKast()
    { moveCamera.OddMove(new Vector3(0,-12,0)); }

    public void Computer()
    { moveCamera.OddMove(new Vector3(0, -12, 0)); }

    public void KamerWires()
    { moveCamera.OddMove(new Vector3(0, -12, 0)); }

    public void toShower()
    {
        moveCamera.OddMove(new Vector3(20,12,0));
    }

    public void kitchenWires()
    { moveCamera.OddMove(new Vector3(0, 12, 0)); }

    public void toKitchen()
    { moveCamera.OddMove(new Vector3(60, 0, 0)); }

    public void cryptex()
    { moveCamera.OddMove(new Vector3(0, 12, 0)); }

    public void hallwayElectrical()
    { moveCamera.OddMove(new Vector3(-20, 0, 0)); }
}
