using UnityEngine;

public interface IDrop
{
    int coordinates { get; }

    void OnDrop(GameObject gb);
}