using System.Text.RegularExpressions;
using UnityEngine;

public class FlavorTextGenerator : MonoBehaviour
{
    // Text files
    [SerializeField] private TextAsset _citiesFile;
    [SerializeField] private TextAsset _countriesFile;
    [SerializeField] private TextAsset _targetsFile;
    [SerializeField] private TextAsset _announcersFile;

    // Usable values
    private string[] _cities;
    private string[] _countries;
    private string[] _targets;
    private string[] _announcers;

    // REGEX IS THE ROOT OF ALL EVIL
    // https://stackoverflow.com/questions/20056306/match-linebreaks-n-or-r-n
    private const string REGEX_SEPARATOR = "\\r?\\n";


    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        var x = Regex.Split(_citiesFile.text, REGEX_SEPARATOR);
        _cities = x;
        x = Regex.Split(_countriesFile.text, REGEX_SEPARATOR);
        _countries = x;
        x = Regex.Split(_targetsFile.text, REGEX_SEPARATOR);
        _targets = x;
        x = Regex.Split(_announcersFile.text, REGEX_SEPARATOR);
        _announcers = x;
    }
    
    public string GetRandomCity()
    {
        return _cities[Random.Range(0, _cities.Length)];
    }
    
    public string GetRandomCountry()
    {
        return _countries[Random.Range(0, _countries.Length)];
    }
    
    public string GetRandomTarget()
    {
        return _targets[Random.Range(0, _targets.Length)];
    }
    
    public string GetRandomAnnouncer()
    {
        return _announcers[Random.Range(0, _announcers.Length)];
    }
}