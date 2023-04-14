namespace Assignment_2
{
    public interface ICalculator
    {
        float Add(float a, float b);
        int Add(int a, int b);
        int Add(int a, int b, int c);
        float GetResult();
        void SetResult(float result);
    }
}