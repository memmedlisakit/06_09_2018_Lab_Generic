using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genrics_and_lambda.Models
{
    public class ComboItem
    {
        public string Text { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
