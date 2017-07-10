using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kata_roman_numbers.Entities
{
    public class Number
    {
        public int intValue { get; private set; }
        public string romanValue { get; private set; }
        public Number(int _intValue) { this.intValue = _intValue; }
        public Number(string _romanValue) { this.romanValue = _romanValue; }

        public void ConvertToRoman()
        {
            this.romanValue = ConvertToRoman(this.intValue);
        }
        public string ConvertToRoman(int _intValue)
        {
            string _romanValue = string.Empty;

            if ((_intValue / 1000) > 0)
            {
                _romanValue += ConvertThousandsToRoman(_intValue);
                _intValue = _intValue % 1000;
            }
            if ((_intValue / 100) > 0)
            {
                _romanValue += ConvertHundredsToRoman(_intValue);
                _intValue = _intValue % 100;
            }
            if ((_intValue / 10) > 0)
            {
                _romanValue += ConvertTensToRoman(_intValue);
                _intValue = _intValue % 10;
            }
            if (_intValue > 0)
            {
                _romanValue += ConvertUnitsToRoman(_intValue);
            }

            return _romanValue;
        }

        internal string ConvertUnitsToRoman(int _intValue)
        {
            string _romanValue = string.Empty;

            if ((_intValue / 5) > 0 && _intValue < 9)
            {
                _romanValue += "V";
                _intValue = _intValue % 5;
            }
            switch (_intValue)
            {
                case 1:
                case 2:
                case 3:
                    for (int i = 0; i < _intValue; i++) _romanValue += "I";
                    break;
                case 4:
                    _romanValue += "IV";
                    break;
                case 9:
                    _romanValue += "IX";
                    break;
            }

            return _romanValue;
        }
        internal string ConvertTensToRoman(int _intValue)
        {
            string _romanValue = string.Empty;

            if ((_intValue / 50) > 0 && _intValue < 90)
            {
                _romanValue += "L";
                _intValue = _intValue % 50;
            }
            switch (_intValue / 10)
            {
                case 1:
                case 2:
                case 3:
                    for (int i = 0; i < (_intValue / 10); i++) _romanValue += "X";
                    break;
                case 4:
                    _romanValue += "XL";
                    break;
                case 9:
                    _romanValue += "XC";
                    break;
            }

            return _romanValue;
        }
        internal string ConvertHundredsToRoman(int _intValue)
        {
            string _romanValue = string.Empty;

            if ((_intValue / 500) > 0 && _intValue < 900)
            {
                _romanValue += "D";
                _intValue = _intValue % 500;
            }
            switch (_intValue / 100)
            {
                case 1:
                case 2:
                case 3:
                    for (int i = 0; i < (_intValue / 100); i++) _romanValue += "C";
                    break;
                case 4:
                    _romanValue += "CD";
                    break;
                case 9:
                    _romanValue += "CM";
                    break;
            }

            return _romanValue;
        }
        internal string ConvertThousandsToRoman(int _intValue)
        {
            string _romanValue = string.Empty;

            if (_intValue > 4999)
            {
                int _intValue5000 = intValue - (_intValue % 5000);
                _romanValue += "[";
                _romanValue += ConvertToRoman(_intValue5000 / 1000);
                _romanValue += "]";
                _intValue = _intValue % 5000;
            }
            switch (_intValue / 1000)
            {
                case 1:
                case 2:
                case 3:
                    for (int i = 0; i < (_intValue / 1000); i++) _romanValue += "M";
                    break;
            }

            return _romanValue;
        }

        public void ConvertToInteger()
        {
            this.intValue = ConvertToInteger(this.romanValue);
        }
        public int ConvertToInteger(string _romanValue)
        {
            int _intValue = 0;
            _romanValue = _romanValue.ToUpper();

            if (_romanValue.Contains("[")){
                _intValue += ConvertMoreThousandsToInteger(_romanValue.Substring(0, _romanValue.IndexOf(']')));
                _romanValue = _romanValue.Substring(_romanValue.IndexOf(']') + 1);
            }
            System.Collections.Stack _stRomanNumber = new System.Collections.Stack(_romanValue.ToArray<char>());

            char _lastChar = char.MinValue;
            char _nowChar;
            while (_stRomanNumber.Count > 0)
            {
                _nowChar = (char)_stRomanNumber.Pop();

                switch (_nowChar)
                {
                    case 'I':
                        if (_lastChar != char.MinValue && _lastChar != 'I') _intValue--;
                        else _intValue++;
                        break;
                    case 'V':
                        _intValue += 5;
                        break;
                    case 'X':
                        if (_lastChar.Equals('L') || _lastChar.Equals('C')) _intValue -= 10;
                        else _intValue += 10;
                        break;
                    case 'L':
                        _intValue += 50;
                        break;
                    case 'C':
                        if (_lastChar.Equals('M') || _lastChar.Equals('D')) _intValue -= 100;
                        else _intValue += 100;
                        break;
                    case 'D':
                        _intValue += 500;
                        break;
                    case 'M':
                        _intValue += 1000;
                        break;
                }
                _lastChar = _nowChar;
            }

            return _intValue;
        }

        internal int ConvertMoreThousandsToInteger(string _romanValue)
        {
            int _intValue=0;

            _romanValue = _romanValue.Replace("[", "").Replace("]", "");

            _intValue = ConvertToInteger(_romanValue) * 1000;

            return _intValue;
        }
    }
}
