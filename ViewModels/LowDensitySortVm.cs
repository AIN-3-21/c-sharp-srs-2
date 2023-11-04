using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Amir.ViewModels;
public class LowDensitySortVm : PageVm
{
    public LowDensitySortVm(IScreen hostScreen) : base(hostScreen)
    {
    }

    public override int[] Execute(int[] arr)
    {
        if (arr == null || arr.Length <= 1)
        {
            return Array.Empty<int>();
        }

        var n = arr.Length;
        var sorted = false;
        var operationsCount = 0;

        while (!sorted)
        {
            sorted = true;

            for (var i = 0; i < n - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    (arr[i], arr[i + 1]) = (arr[i + 1], arr[i]); 
                    sorted = false;
                    operationsCount += 3;
                }
                operationsCount++;
            }
            n--;

            if (sorted)
            {
                break; 
            }
        }

        var memoryAllocate = arr.Length * sizeof(int);

        OperationsCount = operationsCount;
        MemoryAlocate = memoryAllocate;

        return arr;
    }
}
