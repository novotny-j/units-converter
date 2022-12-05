# units-converter

input syntax have following rules:
- input consists of two strings. first consists of value, followed by space followed by measure, second is target unit
- everything have to be lowercase, measures should be in singular form
- for decimal point you should use comma or dot based on your system localisationexample inputs: ("1 kilometer" , "meter"), ("-25 celsius" , "fahrenheit"), ("3.5 inch", "millimeter")

library supports common SI prefixes and also binary prefixes for data (IEC standard)
