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

    private string[] Prefixes(){
        string[] ret = new string[2];
        return ret;
    }

    public string Convert(string input, string output)
    {
        string[] arr = new string[2];
        int inputValue = 0;
        string inputMeasure = "";
        try
        {
            arr = input.Split(" ");
            inputValue = Int32.Parse(arr[0]);
            inputMeasure = arr[1];
        }
        catch(Exception)
        {
            throw;
        }

        //add prefixes detection
        
        double val = FromSI(output, ToSI(inputMeasure, inputValue));

        return String.Format("{0} = {1} {2}",input, val.ToString(), output);
    }
}

