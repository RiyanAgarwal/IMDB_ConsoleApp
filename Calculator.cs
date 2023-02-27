using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    public class Calculator : ICalculator
    {
        private float _result;

        public void SetResult(float result)
        {
            this._result = result;
        }
        public virtual float GetResult()
        {
            return _result;
        }
        public int Add(int a, int b)
        {
            var result = a + b;
            this.SetResult(Convert.ToSingle(result));
            return result;

        }
        public int Add(int a, int b, int c)
        {
            var result = a + b + c;
            this.SetResult(Convert.ToSingle(result));
            return result;
        }

        public float Add(float a, float b)
        {
            var result = a + b;
            this.SetResult(result);
            return result;
        }

    }
}
