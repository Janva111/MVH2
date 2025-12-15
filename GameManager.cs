using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    List<GameObject> targets = new();
    public GameObject Target { get; private set; }
    private GameObject oldTarget;


    private float _timer;
    public float maxTime = 10f;

    public static GameManager Instance { get; set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        FindTargets();
        SelectTarget();
        _timer = maxTime;
        UIManager.Instance.SetMaxValue(maxTime);
    }

    void FindTargets()
    {
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (var item in allObjects)
        {
            if (item.layer == 7)
            {
                targets.Add(item);
            }
        }
    }

    public void SelectTarget()
    {
        if (targets.Count == 0)
        {
            Debug.LogError("List Targets je prázdný");
            return;
        }

        if (targets.Count == 1)
        {
            Target = targets[0];
        }

        int x;

        do
        {
            x = Random.Range(0, targets.Count);
        } while (targets[x] == oldTarget);

        Target = targets[x];
        oldTarget = Target;
        ChangeMaxTime(-2);
        _timer = maxTime;
        UIManager.Instance.UpdateTargetText(Target.name);
    }


    private void Update()
    {
        _timer -= Time.deltaTime;
        UIManager.Instance.setSlider(_timer);

        if (_timer < 0)
        {
            
            SelectTarget();
        }

        if (maxTime <= 4) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void ChangeMaxTime(float ammount) 
    {
        maxTime += ammount;
        UIManager.Instance.SetMaxValue(maxTime);
    }
}
