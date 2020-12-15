using System;
using System.Collections.Generic;
using System.Text;

namespace NpgSqlTests
{
    public class TestModel
    {
        public Guid Id { get; set; }
        public List<string> PropOne { get; set; } = new List<string>();

        public List<int> PropTwo { get; set; } = new List<int>();

        public List<int> PropThree { get; set; } = new List<int>();
        public List<int> PropFour { get; set; } = new List<int>();
    }
}
