using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class FlavorTextGenerator : MonoBehaviour
{
    [SerializeField] private TextAsset _citiesFile;
    [SerializeField] private TextAsset _countriesFile;

    private string[] _cities;
    private string[] _countries;


    private void Start()
    {
        Init();
    }

    private void Init()
    {
        var x = Regex.Split(_citiesFile.text, ((char)10).ToString());
        _cities = x;
        x = Regex.Split(_countriesFile.text, ((char)10).ToString());
        _countries = x;
    }
    
    public string GetRandomCity()
    {
        return _cities[Random.Range(0, _cities.Length)];
    }
    
    public string GetRandomCountry()
    {
        return _countries[Random.Range(0, _countries.Length)];
    }
}