using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHoverOutline : MonoBehaviour
{
    private List<Outline> currentOutlines = new List<Outline>();

    void Update()
    {
        if (GameManager.Instance.waveStarted)
            return;

        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
        {
            ClearOutlines();
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        List<Outline> newOutlines = null;

        if (Physics.Raycast(ray, out hit))
        {
            Transform root = hit.collider.transform.root;

            Outline[] outlines = root.GetComponentsInChildren<Outline>();

            if (outlines.Length > 0)
                newOutlines = new List<Outline>(outlines);
        }

        if (!SameOutlines(newOutlines, currentOutlines))
        {
            ClearOutlines();

            if (newOutlines != null)
            {
                foreach (var o in newOutlines)
                {
                    o.enabled = true;
                    o.OutlineColor = Color.yellow;
                }

                currentOutlines = newOutlines;
            }
        }
    }

    void ClearOutlines()
    {
        foreach (var o in currentOutlines)
        {
            if (o != null)
                o.enabled = false;
        }

        currentOutlines.Clear();
    }

    bool SameOutlines(List<Outline> a, List<Outline> b)
    {
        if (a == null || b == null) return false;
        if (a.Count != b.Count) return false;

        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i])
                return false;
        }

        return true;
    }
}



