using UnityEngine;
public interface IGun {
    bool Fire();
    bool Reload();
    void LookAt(Vector3 pos);

}
