using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RomanKhodakovHomeWork
{
    public static class HomeWork5StaticMethod
    { // ����������� ����� ���������� ��� ������ ���������� �������� � ������
        public static int CountElemInStr(this string str)
        {
            return str.Length;
        }
    }
    public sealed class ExampleExtension
    {
        void ExampleCount()
        {
            string abc = "abc";
            Debug.Log(abc.CountElemInStr());
        }
    }
    // ���� ��������� List<T>.��������� ����������, ������� ��� ������ ������� ����������� � ������ ���������: ��� ����� �����;
    // * ��� ���������� ���������;
    // ** ��������� Linq.
    public sealed class ExampleCount
    {
        private IDictionary<T, int> CountUnicElems<T>(ICollection<T> list)
        {
            Dictionary<T, int> found = new Dictionary<T, int>();
            foreach (T val in list)
            {
                if (!found.ContainsKey(val))
                {
                    found.Add(val, 1);
                }
                else
                {
                    int i = found[val];
                    found.Add(val, ++i);
                }
            }
            return found; //�������� ��� ���������� ���������
        }
        //�������� ��������� � OrderBy � �������������� ������-��������� =>.
        Dictionary<string, int> dict = new Dictionary<string, int>()
        {
             {"four", 4 },
             {"two", 2 },
             {"one", 1 },
             {"three", 3 },
        };
        void DictOrderBy()
        {
            var d = dict.OrderBy(pair => pair.Value);
            foreach (var pair1 in d)
            {
                Debug.Log($"{pair1.Key} - {pair1.Value}");
            }
        }
    }
}
