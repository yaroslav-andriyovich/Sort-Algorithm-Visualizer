using System.Threading;
using Sort_Algorithm_Visualizer.Algorithms;

namespace Sort_Algorithm_Visualizer.Data
{
    public class AlgorithmParameters
    {
        public int[] data;
        public Delay delay;
        public SelectedCallback selectedCallback;
        public SwapCallback swapCallback;
        public CancellationToken cancellationToken;
    }
}