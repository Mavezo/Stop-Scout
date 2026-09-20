namespace StopScout.Infrastructure.Ztm;

/// <summary>
/// Official ZTM Gdańsk open-data endpoints. Milestone 1 must not call them.
/// Milestone 2: use the official CKAN stops feed from the assignment (stops.json)
/// if this exact URL ever changes.
/// </summary>
public static class ZtmEndpoints
{
    public const string Stops =
        "https://ckan.multimediagdansk.pl/dataset/c24dd515-823f-4ff9-8d4d-e6674ea90b15/resource/4c4025f0-01bf-41f4-b3f8-d856c3ab3ac5/download/stops.json";

    public const string DeparturesTemplate = "https://ckan2.multimediagdansk.pl/departures?stopId={0}";

    public static string Departures(int stopId) => string.Format(DeparturesTemplate, stopId);
}
