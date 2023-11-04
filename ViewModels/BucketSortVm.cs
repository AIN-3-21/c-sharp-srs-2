using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Amir.ViewModels;
public class BucketSortVm : PageVm
{
    public BucketSortVm(IScreen hostScreen) : base(hostScreen)
    {
    }

    public override int[] Execute(int[] arr)
    {
        if (arr == null || arr.Length == 0)
        {
            OperationsCount = 0;
            MemoryAlocate = 0;
            ResultArray = string.Empty;
            return Array.Empty<int>();
        }

        var minValue = arr.Min();
        var maxValue = arr.Max();

        var range = maxValue - minValue + 1;
        var count = new int[range];
        var output = new int[arr.Length];

        for (var i = 0; i < arr.Length; i++)
        {
            count[arr[i] - minValue]++;
        }

        for (var i = 1; i < count.Length; i++)
        {
            count[i] += count[i - 1];
        }

        for (var i = arr.Length - 1; i >= 0; i--)
        {
            output[count[arr[i] - minValue] - 1] = arr[i];
            count[arr[i] - minValue]--;
        }

        OperationsCount = arr.Length * arr.Length; 
        MemoryAlocate = (range * sizeof(int)) + (arr.Length * sizeof(int)); 

        return output;
    }
}
