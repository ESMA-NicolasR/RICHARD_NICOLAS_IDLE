using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] class MajorTaskMilestone { public int milestone; public MajorTaskTemplate majorTaskTemplate; }

public class TaskManager : MonoBehaviour
{
    [SerializeField] private TaskCompleter _minorTaskCompleter1;
    [SerializeField] private TaskCompleter _minorTaskCompleter2;
    [SerializeField] private TaskCompleter _majorTaskCompleter;

    [SerializeField] private List<MajorTaskMilestone> _majorTaskProgression;
    private Queue<MajorTaskMilestone> _majorTaskQueue;
    [SerializeField] private WeightedList<MinorTaskTemplate> _minorTasksAvailable;
    
    // Start is called before the first frame update
    void Start()
    {
        _majorTaskQueue = new Queue<MajorTaskMilestone>(_majorTaskProgression);
        NextTask();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTask()
    {
        // Check if we've unlocked the next major task
        if (
            _majorTaskQueue.Peek().milestone
            <=
            GameManager.Instance.resourceManager.GetResourceAmount(ResourceTypeEnum.Seed)
            )
        {
            _minorTaskCompleter1.gameObject.SetActive(false);
            _minorTaskCompleter2.gameObject.SetActive(false);
            _majorTaskCompleter.gameObject.SetActive(true);
            
            MajorTask newTask = new MajorTask(_majorTaskQueue.Dequeue().majorTaskTemplate);
            _majorTaskCompleter.AssignTask(newTask);
        }
        else
        {
            _minorTaskCompleter1.gameObject.SetActive(true);
            _minorTaskCompleter2.gameObject.SetActive(true);
            _majorTaskCompleter.gameObject.SetActive(false);

            MinorTask newTask1 = new MinorTask(_minorTasksAvailable.GetRandomElement());
            MinorTask newTask2 = new MinorTask(_minorTasksAvailable.GetRandomElement());
            _minorTaskCompleter1.AssignTask(newTask1);
            _minorTaskCompleter2.AssignTask(newTask2);

        }
    }

}
