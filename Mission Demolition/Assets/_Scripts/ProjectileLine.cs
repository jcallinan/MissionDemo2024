using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ RequireComponent(typeof(LineRenderer))]
public class ProjectileLine : MonoBehaviour
{
    private LineRenderer _line;
    private bool _drawing = true;
    private Projectile _projectile;
    // Start is called before the first frame update
    void Start()
    {
        _line = GetComponent<LineRenderer>();
        _line.positionCount = 1;
        _line.SetPosition(0, transform.position);

        _projectile = GetComponentInParent<Projectile>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_drawing)
        {
            _line.positionCount++;
            _line.SetPosition(_line.positionCount-1, transform.position);
            if (_projectile != null)
            {
                if ( !_projectile.awake)
                {
                    _drawing = false;
                    _projectile = null;
                }
            }

        }

    }
}
