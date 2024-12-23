using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class MajorTaskMilestone { public long milestone; public MajorTaskTemplate majorTaskTemplate; }
[Serializable] public class MinorTaskMilestone { public long milestone; public WeightedList<MinorTaskTemplate> minorTaskTemplates; }

public class TaskManager : MonoBehaviour
{
    // UI Elements
    [SerializeField] private TaskCompleter _minorTaskCompleter1;
    [SerializeField] private TaskCompleter _minorTaskCompleter2;
    [SerializeField] private TaskCompleter _majorTaskCompleter;

    [SerializeField] private List<MajorTaskMilestone> _majorTaskProgression;
    private Queue<MajorTaskMilestone> _majorTaskQueue;
    // Following needs to be public or editor throws error
    public List<MinorTaskMilestone> _minorTaskProgression;
    private Queue<MinorTaskMilestone> _minorTaskQueue;
    private WeightedList<MinorTaskTemplate> _minorTasksAvailable;
    
    // Start is called before the first frame update
    void Start()
    {
        _majorTaskQueue = new Queue<MajorTaskMilestone>(_majorTaskProgression);
        _minorTaskQueue = new Queue<MinorTaskMilestone>(_minorTaskProgression);
        NextTask();
    }
    
    public void NextTask()
    {
        // Check if we've unlocked the next major task
        if (
            _majorTaskQueue.Count != 0 &&
            _majorTaskQueue.Peek().milestone
            <=
            GameManager.Instance.worldHungerManager.GetPeopleFedNb()
            )
        {
            // Create major task
            _minorTaskCompleter1.gameObject.SetActive(false);
            _minorTaskCompleter2.gameObject.SetActive(false);
            _majorTaskCompleter.gameObject.SetActive(true);
            
            MajorTask newTask = new MajorTask(_majorTaskQueue.Dequeue().majorTaskTemplate);
            _majorTaskCompleter.AssignTask(newTask);
        }
        else 
        {
            // Check if we've unlocked the next set of minor tasks
            if (_minorTaskQueue.Count != 0 &&
                _minorTaskQueue.Peek().milestone
                <=
                GameManager.Instance.worldHungerManager.GetPeopleFedNb())
            {
                _minorTasksAvailable = _minorTaskQueue.Dequeue().minorTaskTemplates;
            }
            // Create minor tasks
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
