namespace StringLibrary;
public class UnitsConverter
{
    // to add conversion unit, one has to add formulas to and from base unit, than define references in both switch methods ("ToBaseUnit" and "FromBaseUnit")

    //length
    private double FootToMeter(double x) => x * 0.3048; // define conversion formula to/from base unit, x is input/base unit
    private double MeterToFoot(double x) => x / 0.3048;
    private double InchToMeter(double x) => x * 0.0254;
    private double MeterToInch(double x) => x / 0.0254;
    //data
    private double BitToByte(double x) => x * 8;
    private double ByteToBit(double x) => x / 8;
    //tempearature
    private double FahrenheitToCelsius (double x) => (x - 32) / 1.8;
    private double CelsiusToFahrenheit (double x) => (x * 1.8) + 32;

    private double ToBaseUnit(string measure, double value)
    {
        double x = 0;
        switch(measure){    // define which formula should be invoked for specific unit
            //length
            case "meter":   // do not forget, to define base unit for new type of conversion, should return value (without invoking conversion method)
                x = value;
                break;
            case "foot":
                x = FootToMeter(value);
                break;
            case "inch":
                x = InchToMeter(value);
                break;
            //data
            case "byte":
                x = value;
                break;
            case "bit":
                x = BitToByte(value);
                break;
            //temperature
            case "celsius":
                x = value;
                break;
            case "fahrenheit":
                x = FahrenheitToCelsius(value);
                break;
        }
        return x;
    }

    private double FromBaseUnit(string measure, double value)
    {
        double x = 0;
        switch(measure){    // define which formula should be invoked for specific unit
            //length
            case "meter":   // do not forget, to define base unit for new type of conversion, should return value (without invoking conversion method)
                x = value;
                break;
            case "foot":
                x = MeterToFoot(value);
                break;
            case "inch":
                x = MeterToInch(value);
                break;
            //data
            case "byte":
                x = value;
                break;
            case "bit":
                x = ByteToBit(value);
                break;
            //temperature
            case "celsius":
                x = value;
                break;
            case "fahrenheit":
                x = CelsiusToFahrenheit(value);
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
            case string a when a.Contains("milli"): return new [] { "mili", "-3" };
            case string a when a.Contains("centi"): return new [] { "centi", "-2" };
            case string a when a.Contains("deci"): return new [] { "deci", "-1" };

            // binary order of magnitude
            case string a when a.Contains("yobi"): return new [] { "yotta", "b8" };
            case string a when a.Contains("zebi"): return new [] { "zetta", "b7" };
            case string a when a.Contains("exbi"): return new [] { "exa", "b6" };
            case string a when a.Contains("pebi"): return new [] { "peta", "b5" };
            case string a when a.Contains("tebi"): return new [] { "tera", "b4" };
            case string a when a.Contains("gibi"): return new [] { "giga", "b3" };
            case string a when a.Contains("mebi"): return new [] { "mega", "b2" };
            case string a when a.Contains("kibi"): return new [] { "kilo", "b1" };
        }

        return new [] { "","0" };
    }

    public string Convert(string input, string output)  // input syntax is all lowercase, measures in singular form
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
            throw;  // or define another way to inform about incorrect input syntax
        }

        string[] inputPrefix = GetPrefix(inputMeasure);
        if(inputPrefix[0] != "")
        {
            inputMeasure = inputMeasure.Substring(inputPrefix[0].Length);
            if(inputPrefix[1].Contains("b"))    // check for binary order
            {
                inputPrefix[1] = inputPrefix[1].Substring(1);
                inputValue *= Math.Pow(1024,Int32.Parse(inputPrefix[1]));
            }
            else
                inputValue *= Math.Pow(10,Int32.Parse(inputPrefix[1]));
        }

        string[] outputPrefix = GetPrefix(output);
        if(outputPrefix[0] != "")
        {
            outputBase = output.Substring(outputPrefix[0].Length);
            outputValue = FromBaseUnit(outputBase, ToBaseUnit(inputMeasure, inputValue));
            if(outputPrefix[1].Contains("b"))    // check for binary order
            {
                outputPrefix[1] = outputPrefix[1].Substring(1);
                outputValue /= Math.Pow(1024,Int32.Parse(outputPrefix[1]));
            }
            else
                outputValue /= Math.Pow(10,Int32.Parse(outputPrefix[1]));
        }
        else
            outputValue = FromBaseUnit(outputBase, ToBaseUnit(inputMeasure, inputValue));

        return String.Format("{0} = {1:N2} {2}",input, outputValue, output);
    }
}
