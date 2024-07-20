using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IConnection
{
    public void Connect(GameObject any);
    public void Disconnect();
}
