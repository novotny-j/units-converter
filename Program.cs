internal class Program
{

    private static void Main(string[] args)
    {
        Func<double, double> FootToMeter = x => (double)(x * 0.3048); //x is input unit
        Func<double, double> MeterToFoot = x => (double)(x / 0.3048);
        Func<double, double> InchToMeter = x => (double)(x * 0.0254);
        Func<double, double> MeterToInch = x => (double)(x / 0.0254);

        string ConvertLength(string input, string output)
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
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            

            double x = 0;
            double val = 0;

            switch(inputMeasure){
                case "meter":
                    x = inputValue;
                    break;
                case "foot":
                    x = FootToMeter(inputValue);
                    break;
                case "inch":
                    x = InchToMeter(inputValue);
                    break;
            }

            switch(output){
                case "meter":
                    val = x;
                    break;
                case "foot":
                    val = MeterToFoot(x);
                    break;
                case "inch":
                    val = MeterToInch(x);
                    break;
            }

            return String.Format("{0} = {1} {2}",input, val.ToString(), output);
        }

        string input = "123 inch";
        string output = "foot";
        
        /*Console.Write("input (value unit): ");
        input = Console.ReadLine();
        Console.Write("output (unit): ");
        output = Console.ReadLine();*/
        
        Console.WriteLine(ConvertLength(input, output));
    }
}


//meters feet inches
//meter = foot * 0.3048
//foot = meter / 0.3048

//("1 meter", "feet") -> "3.28 feet"
//("3 kiloinches", "meter") -> "76.19 meter"

