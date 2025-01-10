using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Announcer : MonoBehaviour
{
    // Display
    [SerializeField] private TextMeshProUGUI announcerText;
    
    // Gaemplay
    [SerializeField] private float timeBetweenAnnounces;

    private void Start()
    {
        StartCoroutine(AnnouncerCoroutine());
    }

    private IEnumerator AnnouncerCoroutine()
    {
        while (true)
        {
            announcerText.text = GameManager.Instance.flavorTextGenerator.GetRandomAnnouncer();
            yield return new WaitForSeconds(timeBetweenAnnounces);
        }
    }
}
