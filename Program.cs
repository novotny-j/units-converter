internal class Program
{
    private static void Main(string[] args)
    {
        var converter = new UnitsConverter();

        string input = "1 meter";
        string output = "foot";
        
        /*Console.Write("input (value unit): ");
        input = Console.ReadLine();
        Console.Write("output (unit): ");
        output = Console.ReadLine();*/
        
        Console.WriteLine(converter.Convert(input, output));
    }
}

public class UnitsConverter
{
    private double FootToMeter(double x) => x * 0.3048; // define conversion formula to/from SI unit, x is input/SI unit
    private double MeterToFoot(double x) => x / 0.3048;
    private double InchToMeter(double x) => x * 0.0254;
    private double MeterToInch(double x) => x / 0.0254;

    private double ToSI(string measure, double value)
    {
        double x = 0;
        switch(measure){    // define which formula should be invoked for specific unit
            case "meter":   // do not forget, to define SI unit for new type of conversion, should return value (without invoking conversion method)
                x = value;
                break;
            case "foot":
                x = FootToMeter(value);
                break;
            case "inch":
                x = InchToMeter(value);
                break;
        }
        return x;
    }

    private double FromSI(string measure, double value)
    {
        double x = 0;
        switch(measure){    // define which formula should be invoked for specific unit
            case "meter":   // do not forget, to define SI unit for new type of conversion, should return value (without invoking conversion method)
                x = value;
                break;
            case "foot":
                x = MeterToFoot(value);
                break;
            case "inch":
                x = MeterToInch(value);
                break;
        }
        return x;
    }
    private string[] GetPrefix(string measure)
    {        
        switch (measure)
        {
            case string a when a.Contains("quetta"): return new [] { "quetta", "30" };
            case string a when a.Contains("ronna"): return new [] { "ronna", "27" };
            case string a when a.Contains("yotta"): return new [] { "yotta", "24" };
            case string a when a.Contains("zetta"): return new [] { "zetta", "21" };
            case string a when a.Contains("exa"): return new [] { "exa", "18" };
            case string a when a.Contains("peta"): return new [] { "peta", "15" };
            case string a when a.Contains("tera"): return new [] { "tera", "12" };
            case string a when a.Contains("giga"): return new [] { "giga", "9" };
            case string a when a.Contains("mega"): return new [] { "mega", "6" };
            case string a when a.Contains("kilo"): return new [] { "kilo", "3" };
            case string a when a.Contains("hecto"): return new [] { "hecto", "2" };
            case string a when a.Contains("deca"): return new [] { "deca", "1" };

            case string a when a.Contains("quecto"): return new [] { "quecto", "-30" };
            case string a when a.Contains("ronto"): return new [] { "ronto", "-27" };
            case string a when a.Contains("yocto"): return new [] { "yocto", "-24" };
            case string a when a.Contains("zepto"): return new [] { "zepto", "-21" };
            case string a when a.Contains("alto"): return new [] { "alto", "-18" };
            case string a when a.Contains("femto"): return new [] { "femto", "-15" };
            case string a when a.Contains("pico"): return new [] { "pico", "-12" };
            case string a when a.Contains("nano"): return new [] { "nano", "-9" };
            case string a when a.Contains("micro"): return new [] { "micro", "-6" };
            case string a when a.Contains("mili"): return new [] { "mili", "-3" };
            case string a when a.Contains("centi"): return new [] { "centi", "-2" };
            case string a when a.Contains("deci"): return new [] { "deci", "-1" };
        }

        return new [] { "","0" };
    }

    public string Convert(string input, string output)
    {
        string[] arr = new string[2];
        double inputValue = 0;
        double outputValue = 0;
        string inputMeasure = "";
        string outputBase = output;
        try
        {
            arr = input.Split(" ");
            inputValue = Double.Parse(arr[0]);
            inputMeasure = arr[1];
        }
        catch(Exception)
        {
            throw;
        }

        string[] inputPrefix = GetPrefix(inputMeasure);
        if (inputPrefix[0] != "")
        {
            inputMeasure = inputMeasure.Substring(inputPrefix[0].Length);
            inputValue *= Math.Pow(10,Int32.Parse(inputPrefix[1]));
        }

        string[] outputPrefix = GetPrefix(output);
        if (outputPrefix[0] != "")
        {
            outputBase = output.Substring(outputPrefix[0].Length);
            outputValue = FromBase(outputBase, ToBase(inputMeasure, inputValue));
            outputValue /= Math.Pow(10,Int32.Parse(outputPrefix[1]));
        }
        else
        {
            outputValue = FromBase(outputBase, ToBase(inputMeasure, inputValue));
        }

        return String.Format("{0} = {1:N2} {2}",input, outputValue, output);
    }
}

