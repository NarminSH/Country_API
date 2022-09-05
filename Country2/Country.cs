using System;

public class Country
{
    //public List<DataPair>? Code { get; set; }
    public List<DataPair>? Name { get; set; }
    public List<DataPair>? ISO { get; set; }
    public List<DataPair>? Capital { get; set; }
    public List<DataPair>? Currency { get; set; }
    public List<DataPair>? Continent { get; set; }
    public List<DataPair>? Phone { get; set; }

}


public class DataPair
{
    public string Key { get; set; }

    public string Value { get; set; }
}

