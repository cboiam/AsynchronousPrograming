using System.Threading.Tasks;

namespace SharedLibrary
{
    public static class Fibonacci
    {
        public static int GetNumberInSequence(this int sequenceNumber)
        {
            if (sequenceNumber <= 1)
            {
                return sequenceNumber;
            }

            return GetNumberInSequence(sequenceNumber - 1) + GetNumberInSequence(sequenceNumber - 2);
        }

        public static async Task<int> GetNumberInSequenceAsync(this int sequenceNumber)
        {
            if (sequenceNumber <= 1)
            {
                return sequenceNumber;
            }

            Task<int> number1Task = GetNumberInSequenceAsync(sequenceNumber - 1);
            Task<int> number2Task = GetNumberInSequenceAsync(sequenceNumber - 2);

            return await number1Task + await number2Task;
        }
    }
}
