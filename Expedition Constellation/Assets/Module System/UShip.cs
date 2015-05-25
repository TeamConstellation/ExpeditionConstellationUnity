using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Every ship's overall data, such as thrust, attached modules, etc are stored here. Every ship has one "Ship" script.
/// </summary>
public class UShip : MonoBehaviour {

    UModule[][][] modules;

    //References:
    UModule cockpit;
    List<UEngineModule> engines;
    //End of references.

    Vector3 velocity;
    Vector3 angularVelocity; //Probably needs to be a quaternion

    Vector3 thrustPerSecond;
    Vector3 torquePerSecond; //Probably needs to be a quaternion

    void Start()
    {
        engines = new List<UEngineModule>();

        //TODO: Load ship data here!
    }

    /// <summary>
    /// Adds the input module to the x,y,z coordinate, if possible.
    /// </summary>
    /// <param name="x">X-Pos</param>
    /// <param name="y">Y-Pos</param>
    /// <param name="z">Z-Pos</param>
    /// <param name="module">Module to insert</param>
    /// <returns>True, if addition was successful. False otherwise.</returns>
    public bool addModule(int x, int y, int z, UModule module)
    {

        if (module is UEngineModule)
        {
            UEngineModule tempEngine = (UEngineModule)module;
            engines.Add(tempEngine);

            //TODO: Change engine parameters.
        }

        //TODO: Add modules to the array, if possible. Place the module. Then parent it to the cockpit.
        return false;
    }

    /// <summary>
    /// Removes the module at the input x,y,z coordinates.
    /// </summary>
    /// <param name="x">X-Pos</param>
    /// <param name="y">Y-Pos</param>
    /// <param name="z">Z-Pos</param>
    public void removeModule(int x, int y, int z)
    {
        //TODO: Remove Modules from the array.
    }
}
