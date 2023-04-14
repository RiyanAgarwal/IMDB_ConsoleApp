namespace Assignment_2
{
    public class AdvanceCalculator : Calculator, IAdvanceCalculator
    {
        public override float GetResult()
        {
            return (base.GetResult() * (int)Math.Pow(10, 6));
        }
        public double Power(int a, int b)
        {
            this.SetResult(Convert.ToSingle(Math.Pow(a, b)));
            return Math.Pow(a, b);
        }
    }

}
